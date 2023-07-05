
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using TaskApi.Entities;
using TaskApi.Entities.ConfigModels;
using TaskApi.Infrastructure.Repositories;
using TaskApi.Logger;

namespace TaskApi.Infrastructure.Services
{
    public interface IServiceManager
    {
        IDepartmentService DepartmentService { get; }
        IUserService UserService { get; }
        IWorkerTaskService WorkerTaskService { get; }
        IAuthenticationService AuthenticationService { get; }
        IFileService FileService { get; }
    }

    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IDepartmentService> _departmentService;
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IWorkerTaskService> _workerTaskService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IFileService> _filesService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper,
            UserManager<User> userManager, IOptionsSnapshot<JwtConfiguration> configuration)
        {
            _departmentService = new Lazy<IDepartmentService>(() => new DepartmentService(repositoryManager, logger, mapper));
            _userService = new Lazy<IUserService>(() =>
                new UserService(logger, mapper, userManager));
            _workerTaskService = new Lazy<IWorkerTaskService>(() => new WorkerTaskService(repositoryManager, logger, mapper,userManager));
            _authenticationService = new Lazy<IAuthenticationService>(() =>
                new AuthenticationService(logger, mapper, userManager, configuration));
            _filesService = new Lazy<IFileService>(() => new FileService());
        }

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public IDepartmentService DepartmentService => _departmentService.Value;
        public IUserService UserService => _userService.Value;
        public IWorkerTaskService WorkerTaskService => _workerTaskService.Value;
        public IFileService FileService => _filesService.Value;

    }
}