using System.ComponentModel.DataAnnotations.Schema;

namespace API
{
    public class Client
    {
        private string nom;
        private string prenom;
        private string numero;
        private string adresse;

        // cp , ville

        public Client(string nom, string prenom, string numero, string adresse)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.numero = numero;
            this.adresse = adresse;
        }

        //private string mail;

        public string Nom { get => nom;}
        public string Prenom { get => prenom;}
        public string Numero { get => numero; set => numero = value; }
        public string Adresse { get => adresse; set => adresse = value; }

    }
}
