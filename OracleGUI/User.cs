using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace OracleGUI
{
    public partial class User : Form
    {
        DBConnect db = new DBConnect();         //Instancja klasy DBConnect ułatwiająca wykonywanie działań na bazie danych
        DataTable dt = new DataTable();         //Instancja klasy DataTable przechowująca otrzymane z zapytania dane
        OracleDataReader dr;                    //Reader 
        public User()
        {
            InitializeComponent();              //Inicjalizacja komponentów
            if (db.Connect())                   //Jeśli udało się nawiązać połączenie lub jest ono już aktywne
            {
                dr = db.Cmd("SELECT nazwa, numer_linii , czas FROM rozklad, przystanki, pojazdy WHERE rozklad.id_przystanku = przystanki.id_przystanku AND pojazdy.id_pojazdu = rozklad.id_pojazdu");   //Komenda SQL
                dt.Load(dr);                    //Wczytanie do DataTable wyniku zapytania
                dgv_user.DataSource = dt;       //Ustawienie źródła DataGridView na DataTable
            }
            db.Disconnect();                    //Rozłączenie
        }
    }
}
