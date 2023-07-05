using System.ComponentModel.DataAnnotations;
using TaskApi.Entities;

namespace TaskApi.Shared.DTOs
{
    public record DtoUser
    {
        public string Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string UrlImg { get; set; }
        public string Email { get; init; }
        public string Rol { get; set; }
        public bool Active { get; set; }
        //Navigational props
        public int? DepartmentId { get; set; }
        public DtoDepartment Department { get; set; }
        public ICollection<DtoWorkerTask> WorkerTasks { get; set; } = new List<DtoWorkerTask>();
    }

    public record DtoUserUpdate
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        public string FName { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string LName { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo puede introducir hasta {1} caracteres")]
        [EmailAddress(ErrorMessage = "Correo no válido")]
        public string Email { get; init; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Role { get; set; }

        //Navigational props
        public int? DepartmentId { get; set; }
        //public ICollection<DtoWorkerTask>? WorkerTasks { get; set; } = new List<DtoWorkerTask>();
    }

    public record DtoUserRegistration
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo puede introducir hasta {1} caracteres")]
        public string FName { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo puede introducir hasta {1} caracteres")]
        public string LName { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo puede introducir hasta {1} caracteres")]
        [EmailAddress(ErrorMessage = "Correo no válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Role { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Username { get; set; }

        //Navigational props
        public int? DepartmentId { get; set; }
    }

    public record DtoUserLogin
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Password { get; init; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo puede introducir hasta {1} caracteres")]
        [EmailAddress(ErrorMessage = "Correo no válido")]
        public string Email { get; init; }
    }

    public record TokenDto(string AccessToken, string RefreshToken);
}
