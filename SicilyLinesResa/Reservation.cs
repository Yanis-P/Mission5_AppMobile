using System.Runtime.CompilerServices;

namespace SicilyLinesResa
{
    public class Reservation
    {
        int id;
        DateTime date;
        int idTraversee;        //Client client;
        int idClient;
        int idType;

        public Reservation(int id, DateTime date, int idTraversee, int idClient, int idType)
        {
            this.id = id;
            this.date = date;
            this.idTraversee = idTraversee;
            this.idClient = idClient;
            this.idType = idType;
        }

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public int IdClient { get => idClient; set => idClient = value; }
        public int IdTraversee { get => idTraversee; set => idTraversee = value; }
        public int IdType { get => idType; set => idType = value; }
    }
}

