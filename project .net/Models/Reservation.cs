using project_.net.Models.project_.net.Models;

namespace project_.net.Models
{
    public class Reservation
    {
        
            public int ID { get; set; }
            public DateTime date { get; set; }
            public int nbPlacesRes { get; set; }
            public Client client { get; set; }
            public Restaurant restaurant { get; set; }
        }
    
}
