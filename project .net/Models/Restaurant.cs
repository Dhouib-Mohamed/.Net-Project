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
        [ForeignKey("ID")] public int category { get; set; }
        //public virtual Category category_id { get; set; }

        public Restaurant( int id, String name , String Localization  , String image , int NbPlaces , int category)
        {
            Id = id;
            Name= name;
            this.Localization = Localization;
            this.image = image; 
           NbPlaces= NbPlaces;
           this.category=category;
        }

    }
}
