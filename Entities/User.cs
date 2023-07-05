
using Microsoft.AspNetCore.Identity;

namespace TaskApi.Entities
{
    public class User : IdentityUser
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public bool Active { get; set; }
        public string RefreshToken { get; set; }
        public string UrlImg { get; set; }
        //Navigational props
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<WorkerTask> WorkerTasks { get; set; } = new List<WorkerTask>();

    }
}
