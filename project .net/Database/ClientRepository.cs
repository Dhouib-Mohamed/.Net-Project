using project_.net.Models;
using System.Xml;

namespace project_.net.Database
{
    public class ClientRepository
    {
        Context context = Context.getInstance();
        public ClientRepository()
        {
            context = Context.getInstance();

        }
        public void addClient(Client c)
        {
            context.Client.Add(c);
            context.SaveChanges();

        }
        public IEnumerable<Client> allClients()
        {
            return context.Set<Client>().ToList();

        }

    }
}