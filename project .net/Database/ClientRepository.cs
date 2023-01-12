using project_.net.Models;

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
    }
}
