using AutoMapper;
using TaskApi.Entities;
using TaskApi.Shared.DTOs;

namespace TaskApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, DtoDepartment>();
            CreateMap<DtoDepartmentForInsertAndUpdate, Department>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<WorkerTask, DtoWorkerTask>();
            CreateMap<DtoWorkerTaskForInsertAndUpdate, WorkerTask>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<DtoWorkerTaskEnd, WorkerTask>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<DtoUserRegistration, User>()
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<User, DtoUser>();
            CreateMap<DtoUserUpdate, User>()
                .ForMember(x => x.Id, opt => opt.Ignore());

        }
    }
}
