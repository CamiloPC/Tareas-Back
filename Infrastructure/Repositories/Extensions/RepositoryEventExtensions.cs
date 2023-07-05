//using TaskApi.Entities;
//using System.Linq.Dynamic.Core;
//using System.Reflection;
//using System.Text;

//namespace TaskApi.Infrastructure.Repositories.Extensions
//{
//    public static class RepositoryEventExtensions
//    {
//        public static IQueryable<Event> FilterEvents(this IQueryable<Event>
//            collection, DateTime? minDate, DateTime? maxDate) =>
//            collection.Where(e => (e.StartDate >= minDate && e.StartDate <= maxDate));
//        public static IQueryable<Event> Search(this IQueryable<Event> collection,
//        string? searchTerm)
//        {
//            if (string.IsNullOrWhiteSpace(searchTerm))
//                return collection;

//            var lowerCaseTerm = searchTerm.Trim().ToLower();

//            return collection.Where(e => e.Name!.ToLower().Contains(lowerCaseTerm)
//            || e.Description!.ToLower().Contains(lowerCaseTerm));
//        }

//        public static IQueryable<Event> Sort(this IQueryable<Event> collection, string? orderByQueryString)
//        {
//            if (string.IsNullOrWhiteSpace(orderByQueryString))
//                return collection.OrderBy(e => e.StartDate);
//            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Event>(orderByQueryString);
//            if (string.IsNullOrWhiteSpace(orderQuery))
//                return collection.OrderBy(e => e.StartDate);
//            return collection.OrderBy(orderQuery);
//        }
//    }
//}
