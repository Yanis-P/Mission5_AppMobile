namespace API
{
    public class Quantite
    {
        private Reservation reservation;
        private Traversee traversee;

        public Quantite(Reservation reservation, Traversee traversee)
        {
            this.reservation = reservation;
            this.traversee = traversee;
        }
    }
}
