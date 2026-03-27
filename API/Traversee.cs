namespace API
{
    public class Traversee
    {
        int id;
        int idBateau;
        int idLiaison;
        DateTime heureDepart;
        DateTime duree;

        public Traversee(int id, int idBateau, int idLiaison, DateTime heureDepart, DateTime duree)
        {
            this.id = id;
            this.idBateau = idBateau;
            this.idLiaison = idLiaison;
            this.HeureDepart = heureDepart;
            this.Duree = duree;
        }

        public int Id { get => id; set => id = value; }
        public int IdBateau { get => idBateau; set => idBateau = value; }
        public int IdLiaison { get => idLiaison; set => idLiaison = value; }
        public DateTime HeureDepart { get => heureDepart; set => heureDepart = value; }
        public DateTime Duree { get => duree; set => duree = value; }
    }
}
