namespace API
{
    public class Liaison
    {
        int id;
        int idPortDepart;
        int idPortArrivee;

        public Liaison(int id, int idPortDepart, int idPortArrivee)
        {
            this.id = id;
            this.idPortDepart = idPortDepart;
            this.idPortArrivee = idPortArrivee;
        }

        public int Id { get => id; set => id = value; }
        public int PortDepart { get => idPortDepart; set => idPortDepart = value; }
        public int PortArrivee { get => idPortArrivee; set => idPortArrivee = value; }
    }
}
