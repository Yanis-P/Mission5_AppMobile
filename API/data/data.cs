using API;
using static System.Runtime.InteropServices.JavaScript.JSType;


static class Data
{
    public static List<Client> listeClient = new List<Client>();

    public static Liaison liaison = new Liaison(1, 1, 2);
    public static Liaison liaison1 = new Liaison(2, 1, 3);
    public static Liaison liaison2 = new Liaison(3, 1, 4);
    public static Liaison liaison3 = new Liaison(4, 1, 5);

    public static Traversee traversee = new Traversee(1, 1,liaison.Id, DateTime.Now, new DateTime(2026, 06, 25));
    public static Traversee traversee1 = new Traversee(2, 2,liaison1.Id, DateTime.Now, new DateTime(2026, 07, 12));
    public static Traversee traversee2 = new Traversee(3, 3, liaison2.Id, DateTime.Now, new DateTime(2026, 09, 05));
    public static Traversee traversee3 = new Traversee(4, 4, liaison3.Id, DateTime.Now, new DateTime(2026, 10, 02));


    public static List<Reservation> listeReservations = new List<Reservation>();

    public static Client c = new Client(1, "admin", "5 rue du berry", "94550", "Chevilly-Larue", listeReservations);


    public static Reservation reservation = new Reservation(1, DateTime.Now, traversee.Id, c.Id);
    public static Reservation reservation1 = new Reservation(2, DateTime.Now, traversee1.Id, c.Id);
    public static Reservation reservation2 = new Reservation(3, DateTime.Now, traversee2.Id, c.Id);
    public static Reservation reservation3 = new Reservation(4, DateTime.Now, traversee3.Id, c.Id);


    static Data()
    {
        listeReservations.Add(reservation);
        listeReservations.Add(reservation1);
        listeReservations.Add(reservation2);
        listeReservations.Add(reservation3);

        listeClient.Add(c);
    }


};
