using System.ComponentModel.DataAnnotations;

namespace MarvieritosApp.Models
{

    public class User
    {
        [Key]
        public int Id_user { get; set; }
        public string Name { get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordHash { get; set; }

        [Required]
        public string Email { get; set; }
        public string Date { get; set; }
        public string Bank_Account { get; set; }
        public int PhoneNumber { get; set; } 


    }

}
