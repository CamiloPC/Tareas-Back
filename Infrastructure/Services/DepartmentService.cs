using AutoMapper;
using TaskApi.Entities.ErrorModel;
using TaskApi.Entities;
using TaskApi.Infrastructure.Repositories;
using TaskApi.Logger;
using TaskApi.Shared.DTOs;
using TaskApi.Infrastructure.Services.Extensions;

namespace TaskApi.Infrastructure.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DtoDepartment>> GetAll(bool trackChanges);
        Task<DtoDepartment> GetById(int id, bool trackChanges);
        Task<DtoDepartment> CreateObj(DtoDepartmentForInsertAndUpdate ojb);
        Task DeleteObj(int id, bool trackChanges);
        Task UpdateObj(int id, DtoDepartmentForInsertAndUpdate obj, bool trackChanges);

        Task DeleteObjs(IEnumerable<DtoDepartment> dtoDepartments, bool trackChanges);
    }

    internal sealed class DepartmentService : IDepartmentService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public DepartmentService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DtoDepartment>> GetAll(bool trackChanges)
        {
            var res =
            await _repository.DepartmentRepository.GetAll(trackChanges);

            var resDto = _mapper.Map<IEnumerable<DtoDepartment>>(res);
            return resDto;
        }

        public async Task<DtoDepartment> GetById(int id, bool trackChanges)
        {
            var res = await _repository.DepartmentRepository.GetById(id, trackChanges);

            if (res is null)
                throw new ObjectNotFoundException(id);

            var resDto = _mapper.Map<DtoDepartment>(res);
            return resDto;
        }

        public async Task<DtoDepartment> CreateObj(DtoDepartmentForInsertAndUpdate ojb)
        {

            var entity = _mapper.Map<Department>(ojb);

            _repository.DepartmentRepository.CreateObj(entity);
            await _repository.SaveAsync();

            var res = _mapper.Map<DtoDepartment>(entity);
            return res;
        }

        public async Task DeleteObj(int id, bool trackChanges)
        {
            var res = await _repository.DepartmentRepository.GetById(id, trackChanges);
            if (res is null)
                throw new ObjectNotFoundException(id);
            _repository.DepartmentRepository.DeleteObj(res);
            await _repository.SaveAsync();
        }

        public async Task UpdateObj(int id, DtoDepartmentForInsertAndUpdate ojb, bool trackChanges)
        {
            var res = await _repository.DepartmentRepository.GetById(id, trackChanges);
            if (res is null)
                throw new ObjectNotFoundException(id);
            _mapper.Map(ojb, res);
            await _repository.SaveAsync();
        }

        public async Task DeleteObjs(IEnumerable<DtoDepartment> dtoDepartments, bool trackChanges)
        {
            if (dtoDepartments is null)
                throw new EmptyDeleteListException();

            var idList = dtoDepartments.DepartmentsConvertToIdList();

            await _repository.DepartmentRepository.DeleteObjs(idList, trackChanges);
            await _repository.SaveAsync();
        }
    }
}