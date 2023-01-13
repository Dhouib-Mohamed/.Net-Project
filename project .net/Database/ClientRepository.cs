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
        //public List<Client> getClients()
       // {
         //   return context.Client.ToList();
       // }
        public Client getClientByid(int id)
        {
            Client client = (Client)context.Client.Where(r => r.ID == id);
            return (client);
        }
        public void deleteClient(int id)
        {
            Client client = getClientByid(id);
            context.Client.Remove(client);
            context.SaveChanges();
        }

    }
}
