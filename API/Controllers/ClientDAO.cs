using Microsoft.AspNetCore.SignalR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API.Controllers
{
    public class ClientDAO
    {

        public static Client Get(int id)
        {
            if (Data.listeClient == null || !Data.listeClient.Any())
                throw new InvalidOperationException("La liste des clients est vide ou non initialisée.");

            Client c = Data.listeClient.FirstOrDefault(c => c.Id == id);

            if (c == null)
                throw new KeyNotFoundException($"Aucun client trouvé avec l'id {id}.");

            return c;
        }

        public static void Update(Client client)
        {
            {
                Data.c.Adresse = client.Adresse;
                Data.c.CodePostal = client.CodePostal;
                Data.c.Ville = client.Ville;
            }
        }
    }
}
