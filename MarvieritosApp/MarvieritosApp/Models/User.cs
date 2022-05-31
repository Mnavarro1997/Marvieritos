using System.ComponentModel.DataAnnotations;

namespace MarvieritosApp.Models
{

    public class User
    {
        [Key]
        public int Id_user { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Date { get; set; }
        public string Bank_Account { get; set; }
        public int PhoneNumber { get; set; } 


    }

}
