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
    }
}
