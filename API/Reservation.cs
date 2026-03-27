using System.Runtime.CompilerServices;

namespace API
{
    public class Reservation
    {
        int id;
        DateTime date;
        int idTraversee;        //Client client;
        int idClient;

        public Reservation(int id, DateTime date, int idTraversee, int idClient)
        {
            this.id = id;
            this.date = date;
            this.idTraversee = idTraversee;
            this.idClient = idClient;
        }

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public int IdClient { get => idClient; set => idClient = value; }
        public int IdTraversee { get => idTraversee; set => idTraversee = value; }
    }
}
