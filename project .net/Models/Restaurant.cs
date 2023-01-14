using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace project_.net.Models
{
    public class Restaurant
    {
        
        [Key] public int Id { get; set; }
        [Required] public String Name { get; set; }
        public String Localization { get; set; }
        public String image { get; set; }
        public int NbPlaces { get; set; }

        public String getCategories()
        {
            List<String> cat = new List<string>(); 
            categories.ForEach( category => { cat.Add(category.Name); });
            return String.Join(",",cat);
        }
         
        public List<Category> categories { get; set; }

        public Restaurant( String name, String localization ,String image, int nbPlaces) {
            categories = new List<Category>();
            Name= name;
            Localization=localization;
            NbPlaces= nbPlaces;
            this.image= image;
        }
    }
}
