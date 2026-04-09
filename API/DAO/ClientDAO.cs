using MySql.Data.MySqlClient;

namespace API.DAO
{
    public class ClientDAO
    {
        private static string provider = "localhost";

        private static string dataBase = "sicilylinestest";

        private static string uid = "root";

        private static string mdp = "";



        private static ConnexionSql maConnexionSql;


        private MySqlCommand Ocom;


        public static Client getClient(int idClient)
        {
            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                
                maConnexionSql.openConnection();
                 
                Client c = null;

                MySqlCommand cmd = maConnexionSql.reqExec($"SELECT * FROM client WHERE idClient = {idClient}");

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nom = reader.GetString(1);
                        string adresse = reader.GetString(2);
                        string codePostale = reader.GetString(3);
                        string ville = reader.GetString(4);

                        c = new Client(id, nom, adresse, codePostale, ville, new List<Reservation>());
                    }
                    
                }

                

                maConnexionSql.closeConnection();

                return c;
            }
            catch (Exception ex)
            {
                return new Client(00, "ERROR", "ERROR", "ERROR", ex.ToString(), new List<Reservation>());
                
            }
        }


        public static bool updateClient(int idClient, string adresse, string codePostal, string ville)
        {
            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                maConnexionSql.openConnection();

                MySqlCommand cmd = maConnexionSql.reqExec($"update client SET adresse = '{adresse}', codePostale = '{codePostal}', ville = '{ville}' where idClient = {idClient}");

                cmd.ExecuteNonQuery();

                maConnexionSql.closeConnection();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;

            }
        }







    }
}
