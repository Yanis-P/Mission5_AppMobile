using MySql.Data.MySqlClient;

namespace API.DAO
{
    public class ReservationDAO
    {
        private static string provider = "localhost";

        private static string dataBase = "sicilylinestest";

        private static string uid = "root";

        private static string mdp = "";



        private static ConnexionSql maConnexionSql;


        private MySqlCommand Ocom;


        private static int getType(int idReservation)
        {
            int idType = 0;
            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                maConnexionSql.openConnection();

                MySqlCommand cmd = maConnexionSql.reqExec($"SELECT idtype from quantitee where idreservation = {idReservation}");

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        idType = reader.GetInt32(0);
                    }
                }

               
                return idType;
            }
            catch (Exception e)
            {
                Console.WriteLine($"[DEBUG] [RESERVATION_DAO] {e.ToString()}");
                return 404;
            }
        }


        public static List<Reservation> getReservations(int idClient)
        {
            List<Reservation> listReservation = new List<Reservation>();

            int id = 0, idTraversee = 0, idCli = 0, idType = 0;
            DateTime date = DateTime.Now;

            Reservation reservation = null;

            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                maConnexionSql.openConnection();

                //MySqlCommand cmd = maConnexionSql.reqExec($"SELECT * FROM reservation WHERE idclient = {idClient}");
                MySqlCommand cmd = maConnexionSql.reqExec($"SELECT r.IDRESERVATION, r.IDCLIENT, r.NUMTRAVERSEE, r.DATERESERVATION, q.IDTYPE" +
                                                         $" FROM reservation r" +
                                                         $" INNER JOIN quantitee q ON r.IDRESERVATION = q.IDRESERVATION" +
                                                         $" WHERE r.idclient = {idClient}");

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);
                        idCli = reader.GetInt32(1);
                        idTraversee = reader.GetInt32(2);
                        date = reader.GetDateTime(3);
                        idType = reader.GetInt32(4);


                        reservation = new Reservation(id, date, idTraversee, idClient, idType);

                        listReservation.Add(reservation);
                    }
                }

                return listReservation;
            }
            catch (Exception e)
            {
                Console.WriteLine($"[DEBUG] [RESERVATION_DAO] {e.ToString()}");
                return listReservation;
            }

        }
    }
}
