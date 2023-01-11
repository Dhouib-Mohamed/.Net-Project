namespace project_.net.Models
{
    public class Reservation
    {
        
            public int Id { get; set; }
            public DateTime date { get; set; }
            public int nbPlacesRes { get; set; }
            public Client? client { get; set; }
            public Restaurant? restaurant { get; set; }
   
        public Reservation(DateTime date, int nbPlacesRes)
        {
            this.date = date;
            this.nbPlacesRes = nbPlacesRes;
        }
    }
    
}
