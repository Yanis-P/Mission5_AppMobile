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




        public static List<Reservation> getReservations(int idClient)
        {
            List<Reservation> listReservation = new List<Reservation>();

            Reservation reservation = null;

            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                maConnexionSql.openConnection();

                MySqlCommand cmd = maConnexionSql.reqExec($"SELECT * FROM reservation WHERE idclient = {idClient}");

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int num = reader.GetInt32(3);
                        DateTime date = reader.GetDateTime(5);
                        int idTraversee = reader.GetInt32(1);
                        int idCli = reader.GetInt32(2);
                        int idType = reader.GetInt32(4);

                        reservation = new Reservation(num, date, idTraversee, idClient, idType);

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
