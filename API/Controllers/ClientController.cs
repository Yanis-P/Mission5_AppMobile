using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class ClientController : ControllerBase
    {

     //   List<Client> clients = new List<Client>();

       // Client c = new Client("admin", "admin", "0600000000", "10 rue oui oui, 94000");


        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;

        }

        [HttpGet(Name = "GetClients")]
        public List<Client> Get()
        {
            return Data.listeClient;
        }

        [HttpGet("{id}", Name = "GetClientById")]
        public Client Get(int id)
        {
            return ClientDAO.Get(id);
        }

        [HttpPut("{id}", Name = "PutProfile")]
        public void Put(Client c) {

            ClientDAO.Update(c);
        }



        /*
        [HttpPut(Name = "PutProfile")]

        public bool Set(int id, string adresse, string codePostal, string ville)
        {
            Client? client = Data.listeClient.FirstOrDefault(c => c.Id == id);

            if (codePostal.Length == 5)
            {
                //string req = $"update client SET codePostal = {codePostal}, SET adresse = {adresse}, SET ville = {ville} where id = {Data.c.Id}";
                Data.c.Adresse = adresse;
                Data.c.CodePostal = codePostal;
                Data.c.Ville = ville;

                return true;
            }
            return false;
        }*/

        /*[HttpPut]
        public IActionResult UpdateProfile([FromBody] UpdateProfileDto data)
        {
            if (data == null)
                return BadRequest("Données invalides");

            if (string.IsNullOrEmpty(data.Adresse) ||
                string.IsNullOrEmpty(data.CodePostal) ||
                string.IsNullOrEmpty(data.Ville))
            {
                return BadRequest("Champs obligatoires manquants");
            }

            Client? client = Data.listeClient.FirstOrDefault(c => c.Id == data.Id);

            if (client == null)
                return NotFound("Client introuvable");

            if (data.CodePostal.Length == 5)
            {
                client.Adresse = data.Adresse;
                client.CodePostal = data.CodePostal;
                client.Ville = data.Ville;

                return Ok();
            }
            return BadRequest("Code postal invalide");
        }*/
    }

   /* {
        public int Id { get; set; }
        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
    }*/
}
