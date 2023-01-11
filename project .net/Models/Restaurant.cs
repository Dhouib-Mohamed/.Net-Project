using System.ComponentModel.DataAnnotations;

namespace project_.net.Models
{
    public class Restaurant
    {
        
        [Key] public int ID { get; set; }
        [Required] public String Name { get; set; }
        public String Localization { get; set; }
        public int NbPlaces { get; set; }
        public String image { get; set; }
        public Category category { get; set; }

        public Restaurant( String name , String Localization  , String image )
        {
          //  ID = id;
            Name= name;
            this.Localization = Localization;
            this.image = image; 
           // this.NbPlaces = nbPlaces;
            //this.category = c;
        }

    }
}
