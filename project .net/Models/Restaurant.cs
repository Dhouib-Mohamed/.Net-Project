using System.ComponentModel.DataAnnotations;

namespace project_.net.Models
{
    public class Restaurant
    {
        
        [Key] public int Id { get; set; }
        [Required] public String Name { get; set; }
        public String Localization { get; set; }
        public String image { get; set; }

        public Restaurant( int id, String name , String Localization  , String image )
        {
            Id = id;
            Name= name;
            this.Localization = Localization;
            this.image = image; 
        }

    }
}
