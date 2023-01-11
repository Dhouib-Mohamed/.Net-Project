using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace project_.net.Models
{
    public class Client
    {
        [Key]
        [Display(Name="ID")]
        public int ID { get; set; }


        [Required(ErrorMessage = "Please enter you full name")]
        [Display(Name = "FullName")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"/^[a-zA-Z0-9_.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$/gm", ErrorMessage = "E-mail id is not valid")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]
        [RegularExpression(@"^([a-zA-Z0-9@*#]{8,15})$", ErrorMessage = "Password must contain: Minimum 8 characters")]
        public string password { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Entered phone format is not valid.")]
        public string phoneNumber { get; set; }

        public Client()
        {
            ID = 0;
            Name = "";
            this.email = "";
            password = "";
            this.phoneNumber = "";
        }
        public Client(string name, string email, string pwd,string phoneNumber)
        {
            Name = name;
            this.email = email;
            password = pwd;
            this.phoneNumber = phoneNumber;
            
        }
    }
}
