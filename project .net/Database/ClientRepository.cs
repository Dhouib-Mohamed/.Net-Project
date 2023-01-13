using project_.net.Models;
using System.Xml;

namespace project_.net.Database
{
    public class ClientRepository
    {
        Context context;
        public ClientRepository()
        {
            context = Context.getInstance();

        }
        public void add(Client client)
        {
            context.Client.Add(client);
            context.SaveChanges();

        }
        public List<Client> getClients()
        {
            return context.Client.ToList();
        }
        public Client getClientById(int id)
        {
            Client? client = context.Client.Find(id);
            return (client);
        }
        public void deleteClient(int id)
        {
            Client client = getClientById(id);
            context.Client.Remove(client);
            context.SaveChanges();
        }
        public void addReservation(int clientId,int restaurantId,DateTime date,int nb)
        {
            Client client = getClientById(clientId);
            RestaurantRepository restaurantRepository= new RestaurantRepository();
            Restaurant restaurant = restaurantRepository.getRestaurantById(restaurantId);
            Reservation reservation = new Reservation(date,nb);
            reservation.client = client;
            reservation.restaurant=restaurant;
            context.Reservation.Add(reservation);
            context.SaveChanges();
        }

    }
}
