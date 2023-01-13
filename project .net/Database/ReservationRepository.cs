using project_.net.Models;

namespace project_.net.Database
{
    public class ReservationRepository
    {
        Context context = Context.getInstance();
        public Reservation getReservationByClientId(int id)
        {   
            ClientRepository rep = new ClientRepository();
            Client c = rep.getClientById(id);
            Reservation reservation =(Reservation) context.Reservation.Where(a => a.client == c);
            return reservation;
        }
    }
}
