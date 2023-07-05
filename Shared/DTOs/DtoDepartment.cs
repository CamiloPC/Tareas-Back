using System.ComponentModel.DataAnnotations;
using TaskApi.Entities;

namespace TaskApi.Shared.DTOs
{
    public record DtoDepartment : DtoBase
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        //navigational props
        public ICollection<DtoUser> Workers { get; set; } = new List<DtoUser>();
    }

    public record DtoDepartmentForInsertAndUpdate
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo puede introducir hasta {1} caracteres")]
        public string Name { get; set; }
        
        public bool Active { get; set; }
        //navigational props
        public ICollection<DtoUser> Workers { get; set; } = new List<DtoUser>();
    }    
}
