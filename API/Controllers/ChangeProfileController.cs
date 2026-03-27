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
        private readonly ILogger<ProfileController> _logger;

        public ProfileController(ILogger<ProfileController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetProfile")]
        public List<Client> Get()
        {
            return Data.listeClient;

        }


        [HttpPost(Name = "SetProfile")]
        public bool Set(int id, string nom, string adresse, string codePostal, string ville)
        {
            Client? client = Data.listeClient.FirstOrDefault(c => c.Id == id);

            if (codePostal.Length == 5 && Regex.IsMatch(codePostal, @"^[0-9]+$"))
            {
                string req = $"update client SET codePostal = {codePostal}, SET adresse = {adresse}, SET ville = {ville} where id = {Data.c.Id}";
                Data.c.Adresse = adresse;
                Data.c.CodePostal = codePostal;
                Data.c.Ville = ville;
                return true;
            }
            return false;
        }
    }
}
