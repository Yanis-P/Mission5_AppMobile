namespace API
{
    public class Type
    {
        int id;
        string libelle;
        int tarif;

        public Type(int id, string libelle, int tarif)
        {
            this.id = id;
            this.libelle = libelle;
            this.tarif = tarif;
        }

        public int Id { get => id; set => id = value; }
        public string Libelle { get => libelle; set => libelle = value; }
        public int Tarif { get => tarif; set => tarif = value; }
    }
}
