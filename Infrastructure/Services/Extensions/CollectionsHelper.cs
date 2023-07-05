using TaskApi.Entities;
using TaskApi.Shared.DTOs;

namespace TaskApi.Infrastructure.Services.Extensions
{
    public static class CollectionsHelper
    {
        public static List<int> WorkerTaskConvertToIdList(this IEnumerable<DtoWorkerTask> toDelList)
        {
            var res = new List<int>();

            foreach (var item in toDelList)
            {
                res.Add(item.Id.GetValueOrDefault());
            }

            return res;
        }

        public static List<int> DepartmentsConvertToIdList(this IEnumerable<DtoDepartment> toDelList)
        {
            var res = new List<int>();

            foreach (var item in toDelList)
            {
                res.Add(item.Id.GetValueOrDefault());
            }

            return res;
        }

        public static List<string> UsersConvertToIdList(this IEnumerable<User> toDelList)
        {
            var res = new List<string>();

            foreach (var item in toDelList)
            {
                res.Add(item.Id);
            }

            return res;
        }
    }
}