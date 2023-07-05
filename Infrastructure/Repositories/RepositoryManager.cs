namespace TaskApi.Infrastructure.Repositories
{
    public interface IRepositoryManager
    {
        IWorkerTaskRepository WorkerTaskRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        Task SaveAsync();
    }

    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationContext _dataContext;
        private readonly Lazy<IWorkerTaskRepository> _workerTaskRepository;
        private readonly Lazy<IDepartmentRepository> _departmentRepository;

        public RepositoryManager(ApplicationContext dataContext)
        {
            _dataContext = dataContext;
            _workerTaskRepository = new Lazy<IWorkerTaskRepository>(() => new WorkerTaskRepository(dataContext));
            _departmentRepository = new Lazy<IDepartmentRepository>(() => new DepartmentRepository(dataContext));
        }

        public IWorkerTaskRepository WorkerTaskRepository => _workerTaskRepository.Value;

        public IDepartmentRepository DepartmentRepository => _departmentRepository.Value;

        public async Task SaveAsync() => await _dataContext.SaveChangesAsync();

    }
}
