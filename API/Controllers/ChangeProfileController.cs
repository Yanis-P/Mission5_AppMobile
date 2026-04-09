using API.DAO;
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
        public Client Get(int idClient)
        {
            return ClientDAO.getClient(idClient);

        }



        [HttpPut(Name = "SetProfile")]
        public bool Set(int id, string adresse, string codePostal, string ville)
        {
            //Client? client = Data.listeClient.FirstOrDefault(c => c.Id == id);

            string invalidChar = Regex.Replace(adresse, @"^[A-Za-zÀ-ÖØ-öø-ÿ ,.-]+$", "[E]");
            string invalidChar2 = Regex.Replace(codePostal, @"^[0-9]", "[E]");

            Console.WriteLine($"Erreur Adresse : {invalidChar}");
            Console.WriteLine($"Erreur Code Postal : {invalidChar2}");

            //if (codePostal.Length == 5 && Regex.IsMatch(codePostal.Trim(), @"^[0-9]+$") && Regex.IsMatch(adresse, @"^[A-Za-zÀ-ÖØ-öø-ÿ ,.-]+$") && Regex.IsMatch(ville, @"^[A-Za-zÀ-ÖØ-öø-ÿ ,.-]+$"))
            //{
            return ClientDAO.updateClient(id, adresse, codePostal, ville);
            //}
            return false;
        }
    }
}
