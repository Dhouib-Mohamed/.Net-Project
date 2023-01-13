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
        public void editClient(Client client)
        {
            context.Client.Update(client);
            context.SaveChanges();
        }

        public bool SignUp(Client c)
        {
            if (context.Client.Where(client => client.email==c.email).ToList().Count==0)
            {
                add(c);
                return true;
            }

            return false;
        }
        public int SignIn(Client c)
        {
            List<Client> clients = context.Client
                .Where(client => (client.email == c.email && client.password == c.password)).ToList();
            if (clients.Count!=0)
            {
                return clients[0].Id;
            }

            return -1;
        }
        public List<Client> getClients()
        {
            return context.Client.ToList();
        }
        public Client getClientById(int id)
        {
            Client client = context.Client.Find(id);
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
