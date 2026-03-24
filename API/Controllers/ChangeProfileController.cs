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
        Client c = new Client("admin", "admin", "0600000000", "10 rue oui oui, 94000");

        private readonly ILogger<ProfileController> _logger;

        public ProfileController(ILogger<ProfileController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetProfile")]
        public Client Get()
        {
            return c;
        }


        [HttpPost(Name = "SetProfile")]
        public bool Set(string numero, string adresse)
        {
            if (numero.Length == 10 && Regex.IsMatch(numero, @"^[0-9]+$"))
            {
                string req = $"update client set numero = {numero}, set adresse = {adresse} where nom = {c.Nom} AND where prenom = {c.Prenom}";
                c.Numero = numero;
                c.Adresse = adresse;
                return true;
            }
            return false;
        }
    }
}
