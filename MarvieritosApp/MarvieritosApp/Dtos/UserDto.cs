using System.ComponentModel.DataAnnotations;

namespace MarvieritosApp.Dtos
{
    public class UserDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Tiene que ser una contraseña entre 4-8 caracteres.")]
        public string Password { get; set; }
        
    }
}
