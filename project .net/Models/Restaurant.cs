using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_.net.Models
{
    public class Restaurant
    {
        
        [Key] public int Id { get; set; }
        [Required] public String Name { get; set; }
        public String Localization { get; set; }
        public String image { get; set; }
        public int NbPlaces { get; set; }
         
        public List<Category> categories { get; set; }

      
    }
}
