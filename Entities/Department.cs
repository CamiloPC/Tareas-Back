using System.ComponentModel.DataAnnotations;

namespace TaskApi.Entities;
public class Department : BaseEntity
{
    public string Name { get; set; }
    public bool Active { get; set; }

    //navigational props
    public ICollection<User> Workers { get; set; } = new List<User>();
}