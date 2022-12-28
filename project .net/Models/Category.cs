using System.ComponentModel.DataAnnotations;

namespace project_.net.Models
{
    public class Category
    {
        [Key]public int Id { get; set; }
        public String Name { get; set; }

        public Category(int id, String name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
