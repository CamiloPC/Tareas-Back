using TaskApi.Infrastructure.Repositories;
using TaskApi.Entities;
using TaskApi.Logger;
using AutoMapper;
using TaskApi.Shared.DTOs;
using TaskApi.Entities.ErrorModel;
using TaskApi.Infrastructure.Services.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http.HttpResults;

namespace TaskApi.Infrastructure.Services
{
    public interface IWorkerTaskService
    {
        Task<IEnumerable<DtoWorkerTask>> GetAll(string workerId, bool trackChanges);
        Task<DtoWorkerTask> GetById(string workerId, int id, bool trackChanges);
        Task<DtoWorkerTask> CreateObj(DtoWorkerTaskForInsertAndUpdate ojb);
        Task DeleteObj(string workerId, int id, bool trackChanges);
        Task UpdateObj(string workerId, int id, DtoWorkerTaskForInsertAndUpdate ojb, bool trackChanges);
        Task EndTaskObj(string workerId, int id, DtoWorkerTaskEnd ojb, bool trackChanges);
        Task DeleteObjs(string workerId, IEnumerable<DtoWorkerTask> dtoWorkerTasks, bool trackChanges);
    }

    internal sealed class WorkerTaskService : IWorkerTaskService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        UserManager<User> _userManager;

        public WorkerTaskService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, UserManager<User> userManager)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IEnumerable<DtoWorkerTask>> GetAll(string workerId, bool trackChanges)
        {
            var worker = await _userManager.FindByIdAsync(workerId);

            if (worker is null)
                throw new UserNotFoundException(workerId);

            var res =
            await _repository.WorkerTaskRepository.GetAll(workerId, trackChanges);

            var resDto = _mapper.Map<IEnumerable<DtoWorkerTask>>(res);
            return resDto;
        }

        public async Task<DtoWorkerTask> GetById(string workerId, int id, bool trackChanges)
        {
            var worker = await _userManager.FindByIdAsync(workerId);

            if (worker is null)
                throw new UserNotFoundException(workerId);

            var res = await _repository.WorkerTaskRepository.GetById(id, trackChanges);
            if (res is null)
                throw new ObjectNotFoundException(id);

            var resDto = _mapper.Map<DtoWorkerTask>(res);
            return resDto;
        }

        public async Task<DtoWorkerTask> CreateObj(DtoWorkerTaskForInsertAndUpdate ojb)
        {
            ojb.isComplete = false;
            if (!ValidDate(ojb.StartDate.Value,ojb.EndDate.Value))
                throw new MaxDateRangeBadRequestException();

            var entity = _mapper.Map<WorkerTask>(ojb);

            _repository.WorkerTaskRepository.CreateObj(entity);

            await _repository.SaveAsync();
            
            var res = _mapper.Map<DtoWorkerTask>(entity);

            return res;
        }

        public async Task DeleteObj(string workerId, int id, bool trackChanges)
        {
            var worker = await _userManager.FindByIdAsync(workerId);

            if (worker is null)
                throw new UserNotFoundException(workerId);
            var res = await _repository.WorkerTaskRepository.GetById(id, trackChanges);
            if (res is null)
                throw new ObjectNotFoundException(id);
            _repository.WorkerTaskRepository.DeleteObj(res);
            await _repository.SaveAsync();
        }

        public async Task UpdateObj(string workerId, int id, DtoWorkerTaskForInsertAndUpdate ojb, bool trackChanges)
        {
            if (!ValidDate(ojb.StartDate.Value, ojb.EndDate.Value))
                throw new MaxDateRangeBadRequestException();

            var worker = await _userManager.FindByIdAsync(workerId);

            if (worker is null)
                throw new UserNotFoundException(workerId);
            var res = await _repository.WorkerTaskRepository.GetById(id, trackChanges);
            if (res is null)
                throw new ObjectNotFoundException(id);

            _mapper.Map(ojb, res);
            await _repository.SaveAsync();
        }
        public async Task EndTaskObj(string workerId, int id, DtoWorkerTaskEnd ojb, bool trackChanges)
        {
            var worker = await _userManager.FindByIdAsync(workerId);

            if (worker is null)
                throw new UserNotFoundException(workerId);
            var res = await _repository.WorkerTaskRepository.GetById(id, trackChanges);
            if (res is null)
                throw new ObjectNotFoundException(id);

            _mapper.Map(ojb, res);
            await _repository.SaveAsync();
        }

        public async Task DeleteObjs(string workerId, IEnumerable<DtoWorkerTask> dtoWorkerTasks, bool trackChanges)
        {
            var worker = await _userManager.FindByIdAsync(workerId);

            if (worker is null)
                throw new UserNotFoundException(workerId);
            if (dtoWorkerTasks is null)
                throw new EmptyDeleteListException();

            var idList = dtoWorkerTasks.WorkerTaskConvertToIdList();

            await _repository.WorkerTaskRepository.DeleteObjs(idList, trackChanges);
            await _repository.SaveAsync();
        }

        private bool ValidDate(DateTime start, DateTime end) {
            return start < end;
        }
    }
}