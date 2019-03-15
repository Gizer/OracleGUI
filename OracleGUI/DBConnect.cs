using System;
using Oracle.ManagedDataAccess.Client;

namespace OracleGUI
{
    class DBConnect	//Klasa DBConnect ułatwiająca komunikację z bazą danych
    {
        private static OracleConnection conn;

        public bool Connect() 	//Nawiązanie połączenia
        {
            if (conn == null || conn.State != System.Data.ConnectionState.Open)
            {
                string oradb = "Data Source=156.17.43.90;User Id=pwr_17_18_L_016236011;Password=pwr_17_18_L_016236011;";    //Dane serwera

                conn = new OracleConnection(oradb);	//Connection

                conn.Open();	//Otwarcie Connection
                if (conn.State == System.Data.ConnectionState.Open)	//Sprawdzenie czy się udało
                    return true;
                else
                    return false;
            }
            else
                return true;
        }

        public bool Disconnect()	//Rozłączanie z serwerem
        {
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
                conn.Dispose();
                if (conn.State == System.Data.ConnectionState.Closed)
                    return true;
                else
                    return false;
            }
            else
                return true;
        }

        public OracleDataReader Cmd(string cd)	//Wykonywanie wpisanych komend
        {
            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;

            cmd.CommandText = cd;
            cmd.CommandType = System.Data.CommandType.Text;
            OracleDataReader dr;
            try
            {
                dr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine("\nNie poprawna komenda");
                return null;
            }
            return dr;
        }
    }
}
