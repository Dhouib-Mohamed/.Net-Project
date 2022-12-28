using System.ComponentModel.DataAnnotations;

namespace project_.net.Models
{
    public class Category
    {
        [Key]public int Id { get; set; }
        public String Name { get; set; }
        public List<Restaurant> Restaurants { get; set; }

       
    }
}
