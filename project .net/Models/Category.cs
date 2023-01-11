using System.ComponentModel.DataAnnotations;

namespace project_.net.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
