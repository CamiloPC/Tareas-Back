using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TaskApi.Infrastructure.Repositories
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }

    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationContext DataContext;
        public RepositoryBase(ApplicationContext dataContext) => DataContext = dataContext;
        public IQueryable<T> FindAll(bool trackChanges) => !trackChanges ? DataContext.Set<T>()
            .AsNoTracking() : DataContext.Set<T>();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ? DataContext.Set<T>().Where(expression)
            .AsNoTracking() : DataContext.Set<T>().Where(expression);
        public void Create(T entity) => DataContext.Set<T>().Add(entity);
        public void Update(T entity) => DataContext.Set<T>().Update(entity);
        public void Delete(T entity) => DataContext.Set<T>().Remove(entity);
    }
}
