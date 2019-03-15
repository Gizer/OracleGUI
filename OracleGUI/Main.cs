using System;
using System.Linq;
using System.Windows.Forms;

namespace OracleGUI
{
    public partial class Main : Form
    {
        Tuple<string, string>[] users =	//Deklaracje możliwych użytkowników
                {
                    new Tuple<string, string>("user", "abc"),
                    new Tuple<string, string>("worker", "abc"),
                    new Tuple<string, string>("manager", "abc"),
                };

        public Main()
        {
            InitializeComponent();	//Inicjalizacja komponentów
        }

        private void btn_Login_Click(object sender, EventArgs e)	//Kliknięcie "Zaloguj"
        {
            string user = tb_Login.Text;	//Przechowanie "Login"
            string pwd = tb_pwd.Text;	//Przechowanie "Hasło"
            Tuple<string, string> login = new Tuple<string, string>(user, pwd); //Utworzenie nowej pary <Login, Hasło>
            if (users.Contains(login))	//Sprawdzenie czy istnieje taka para w zdefiniowanych użytkownikach
            {
                if (user == "user")
                {
                    User userWin = new User();	//Jeśli zalogował się user, otwiera panel dla user'a
                    userWin.Visible = true;
                }
                else if (user == "worker")
                {
                    Worker workerWin = new Worker();	//Jeśli zalogował się worker, otwiera panel dla worker'a
                    workerWin.Visible = true;
                }
                else
                {
                    Manager managerWin = new Manager();	//Jeśli zalogował się manager, otwiera panel dla managera
                    managerWin.Visible = true;
                }
            }
            else
                MessageBox.Show("\nNiepoprawne dane");	//Nie poprawne dane
        }
    }
}
