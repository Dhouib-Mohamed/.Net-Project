using System.ComponentModel.DataAnnotations;

namespace project_.net.Models
{
    public class Restaurant
    {
        
        [Key] public int Id { get; set; }
        [Required] public String Name { get; set; }
        public String Localisation { get; set; }
        public String speciality { get; set; }
        public List<Plat> Plats { get; set; }
        public String img { get; set; }

    }
}
