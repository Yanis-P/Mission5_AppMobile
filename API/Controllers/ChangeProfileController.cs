using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {

     //   List<Client> clients = new List<Client>();

       // Client c = new Client("admin", "admin", "0600000000", "10 rue oui oui, 94000");


        private readonly ILogger<ProfileController> _logger;

        public ProfileController(ILogger<ProfileController> logger)
        {
            _logger = logger;
         //   clients.Add(new Client("admin", "admin", "0600000000", "10 rue oui oui, 94000"));
           // clients.Add(new Client("non", "non", "0600000006", "10 rue non oui, 94000"));

        }

        [HttpGet(Name = "GetProfile")]
        public List<Client> Get()
        {

            return Data.listeClient;

           // return clients;

        }


        [HttpPost(Name = "SetProfile")]

        public bool Set(int id, string adresse, string codePostal, string ville)
        {
            Client? client = Data.listeClient.FirstOrDefault(c => c.Id == id);

            if (codePostal.Length == 5 && Regex.IsMatch(codePostal, @"^[0-9]+$"))
            {
                string req = $"update client SET codePostal = {codePostal}, SET adresse = {adresse}, SET ville = {ville} where id = {Data.c.Id}";
                Data.c.Adresse = adresse;
                Data.c.CodePostal = codePostal;
                Data.c.Ville = ville;

 /*       public bool Set(string nom, string prenom, string numero, string adresse)
        {
            // Recherche du client correspondant dans la liste
            Client? client = clients.FirstOrDefault(c => c.Nom == nom && c.Prenom == prenom);

            if (numero.Length == 10 && Regex.IsMatch(numero, @"^[0-9]+$"))
            {
                string req = $"UPDATE client SET numero = '{numero}', adresse = '{adresse}' WHERE nom = '{client.Nom}' AND prenom = '{client.Prenom}'";

                //client.Numero = numero;
                //client.Adresse = adresse;*/

                return true;
            }
            return false;
        }
    }
}
