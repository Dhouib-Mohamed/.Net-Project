using System.ComponentModel.DataAnnotations;

namespace project_.net.Models
{
    public class Plat
    {
        [Key] public int plat_Id { get; set; }
        [Required] public String plat_name { get; set; }
        public String ingrediants { get; set; }
        public String image_plat{ get; set; }
         
     
    }
}
