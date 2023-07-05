using System.ComponentModel.DataAnnotations;
using TaskApi.Entities;

namespace TaskApi.Shared.DTOs
{
    public record DtoWorkerTask : DtoBase
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool isComplete { get; set; }
        //nav props
        public string WorkerId { get; set; }
    }

    public record DtoWorkerTaskEnd(bool isComplete);

    public record DtoWorkerTaskForInsertAndUpdate
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(200, ErrorMessage = "Solo puede introducir hasta {1} caracteres")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo puede introducir hasta {1} caracteres")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public DateTime? StartDate { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public DateTime? EndDate { get; set; }
        public bool isComplete { get; set; }
        //nav props
        [Required(ErrorMessage = "La tarea debe estar asignada a un trabajador")]
        public string WorkerId { get; set; }
        
    }
}

