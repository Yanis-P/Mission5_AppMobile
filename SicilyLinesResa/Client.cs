using System.ComponentModel.DataAnnotations.Schema;

namespace SicilyLinesResa
{
    public class Client
    {
        private int id;
        private string nom;
        private string mdp;
        private string adresse;
        private string codePostal;
        private string ville;
        //private List<Reservation> listeReservation;

        // cp , ville

        public Client(int id, string nom, string mdp, string adresse, string codePostal, string ville/*, List<Reservation> listeReservation*/)
        {
            this.id = id;
            this.nom = nom;
            this.Mdp = mdp;
            this.adresse = adresse;
            this.codePostal = codePostal;
            this.ville = ville;
      //      this.ListeReservation = listeReservation;
        }

        //private string mail;

        public int Id { get => id; }
        public string Nom { get => nom; }
        public string Mdp { get => mdp; set => mdp = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string CodePostal { get => codePostal; set => codePostal = value; }
        public string Ville { get => ville; set => ville = value; }
        
        // public List<Reservation> ListeReservation { get => listeReservation; set => listeReservation = value; }
    }
}
