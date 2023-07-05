using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TaskApi.Entities;

namespace TaskApi.Infrastructure.Repositories
{
    public interface IWorkerTaskRepository
    {
        Task<IEnumerable<WorkerTask>> GetAll(string workerId, bool trackChanges);
        Task<WorkerTask> GetById(int id, bool trackChanges);
        void CreateObj(WorkerTask ojb);
        void DeleteObj(WorkerTask ojb);
        Task DeleteObjs(List<int> listId, bool trackChanges);
    }

    public class WorkerTaskRepository : RepositoryBase<WorkerTask>, IWorkerTaskRepository
    {
        public WorkerTaskRepository(ApplicationContext context) : base(context)
        {

        }
        public async Task<IEnumerable<WorkerTask>> GetAll(string workerId, bool trackChanges) => await FindByCondition(x => x.WorkerId == workerId, trackChanges).OrderBy(x => x.StartDate).ToListAsync();


        public async Task<WorkerTask> GetById(int id, bool trackChanges) => (await FindByCondition(x =>x.Id == id, trackChanges).SingleOrDefaultAsync())!;

        public void CreateObj(WorkerTask ojb) => Create(ojb);

        public void DeleteObj(WorkerTask ojb) => Delete(ojb);

        public async Task DeleteObjs(List<int> listId, bool trackChanges)
        {
            var res = await FindByCondition(x => listId.Any(e => e == x.Id), trackChanges).ToListAsync();

            foreach (var item in res)
            {
                DeleteObj(item);
            }
        }
    }
}
