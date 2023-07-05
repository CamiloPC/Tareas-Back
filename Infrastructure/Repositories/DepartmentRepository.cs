using Microsoft.EntityFrameworkCore;
using TaskApi.Entities;
using TaskApi.Infrastructure.Repositories.Extensions;
using TaskApi.Shared.RequestFeatures;
using System.Linq.Dynamic.Core;

namespace TaskApi.Infrastructure.Repositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAll(bool trackChanges);
        Task<Department> GetById(int id, bool trackChanges);
        void CreateObj(Department ojb);
        void DeleteObj(Department ojb);
        Task DeleteObjs(List<int> listId, bool trackChanges);
    }

    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Department>> GetAll(bool trackChanges) => await FindAll(trackChanges).ToListAsync();


        public async Task<Department> GetById(int id, bool trackChanges) =>
            (await FindByCondition(x => x.Id == id, trackChanges).SingleOrDefaultAsync())!;
        public void CreateObj(Department ojb) => Create(ojb);
        public void DeleteObj(Department ojb) => Delete(ojb);

        public async Task DeleteObjs(List<int> listId, bool trackChanges)
        {
            var res = await FindByCondition(x=> listId.Any(e => e == x.Id), trackChanges).ToListAsync();

            foreach (var item in res)
            {
                DeleteObj(item);
            }
        }
    }
}
