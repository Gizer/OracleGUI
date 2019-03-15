using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace OracleGUI
{
    public partial class Manager : Form
    {
        DBConnect db = new DBConnect();
        DataTable dt = new DataTable();
        OracleDataReader dr;
        bool worker = false;	//Zmienne determinujące co zostało wciśnięte
        bool crash = false;
        bool tams = false;
        bool rozklad = false;
        bool przystanki = false;
        bool zajezdnie = false;
        bool grafik = false;
        public Manager()
        {
            InitializeComponent();
            this.Name = "Manager Panel";
            if (db.Connect())
            {
                dr = db.Cmd("SELECT * FROM pracownicy"); 	//Domyślny widok
                dt.Load(dr);
                dgv_manager.DataSource = dt;
                worker = true;
            }
            db.Disconnect();
        }

        private void btn_change_Click(object sender, EventArgs e)	//Przycisk "Zamień"
        {
            if (dgv_manager.SelectedCells == null || crash)	//Nie można edytować kiedy nie ma wybranej komórki oraz kiedy wybierzemy tabelę wypadki
            {

            }

            else
            {
                string dpn = dgv_manager.Columns[dgv_manager.CurrentCell.ColumnIndex].DataPropertyName;	//Zmienne służące do przechowania informacji dotyczących zmiany konkretnego rekordu
                string change = tb_change.Text;
                string id = dgv_manager.Rows[dgv_manager.CurrentCell.RowIndex].Cells[0].Value.ToString();
                if (worker)	//Sprawdzanie która tabela jest aktualnie wybrana
                {
                    if (db.Connect())
                    {
                        dgv_manager.DataSource = null;	//Resetowanie DGV
                        dgv_manager.Rows.Clear();	//Resetowanie DGV
                        dgv_manager.Refresh();		//Resetowanie DGV                                                              
                        dr = null;
                        DataTable dt = new DataTable();
                        dr = db.Cmd("UPDATE pracownicy SET " + dpn + " = '" + change + "' WHERE id_pracownika = '" + id + "'"); //Modyfikacja rekordu
                        dr = db.Cmd("SELECT * FROM pracownicy"); 	//Odświeżenie widoku, analogicznie pozostałe if'y
                        dt.Load(dr);
                        dgv_manager.DataSource = dt;
                    }
                    db.Disconnect();
                }
                else if (tams)
                {
                    if (db.Connect())
                    {
                        dgv_manager.DataSource = null;
                        dgv_manager.Rows.Clear();
                        dgv_manager.Refresh();
                        dr = null;
                        DataTable dt = new DataTable();
                        dr = db.Cmd("UPDATE pojazdy SET " + dpn + " = '" + change + "' WHERE id_pojazdu = '" + id + "'");
                        dr = db.Cmd("SELECT * FROM pojazdy");
                        dt.Load(dr);
                        dgv_manager.DataSource = dt;
                    }
                    db.Disconnect();
                }
                else if (rozklad)
                {
                    if (db.Connect())
                    {
                        dgv_manager.DataSource = null;
                        dgv_manager.Rows.Clear();
                        dgv_manager.Refresh();
                        dr = null;
                        DataTable dt = new DataTable();
                        dr = db.Cmd("UPDATE rozklad SET " + dpn + " = '" + change + "' WHERE id_wpisu = '" + id + "'");
                        dr = db.Cmd("SELECT * FROM rozklad");
                        dt.Load(dr);
                        dgv_manager.DataSource = dt;
                    }
                    db.Disconnect();
                }
                else if (przystanki)
                {


                    if (db.Connect())
                    {
                        dgv_manager.DataSource = null;
                        dgv_manager.Rows.Clear();
                        dgv_manager.Refresh();
                        dr = null;
                        DataTable dt = new DataTable();
                        dr = db.Cmd("UPDATE przystanki SET " + dpn + " = '" + change + "' WHERE id_przystanku = '" + id + "'");
                        dr = db.Cmd("SELECT * FROM przystanki");
                        dt.Load(dr);
                        dgv_manager.DataSource = dt;
                    }
                    db.Disconnect();
                }
                else if (zajezdnie)
                {
                    if (db.Connect())
                    {
                        dgv_manager.DataSource = null;
                        dgv_manager.Rows.Clear();
                        dgv_manager.Refresh();
                        dr = null;
                        DataTable dt = new DataTable();
                        dr = db.Cmd("UPDATE zajezdnie SET " + dpn + " = '" + change + "' WHERE id_zajezdni = '" + id + "'");
                        dr = db.Cmd("SELECT * FROM zajezdnie");
                        dt.Load(dr);
                        dgv_manager.DataSource = dt;
                    }
                    db.Disconnect();
                }
                else if (grafik)
                {
                    if (db.Connect())
                    {
                        dgv_manager.DataSource = null;
                        dgv_manager.Rows.Clear();
                        dgv_manager.Refresh();
                        dr = null;
                        DataTable dt = new DataTable();
                        dr = db.Cmd("UPDATE grafik SET " + dpn + " = '" + change + "' WHERE id_grafik = '" + id + "'");
                        dr = db.Cmd("SELECT * FROM grafik");
                        dt.Load(dr);
                        dgv_manager.DataSource = dt;
                    }
                    db.Disconnect();
                }
            }
        }

        private void btn_workers_Click(object sender, EventArgs e) 	//Przyciski odpowiadające konkretnej tabeli
        {
            if (db.Connect())
            {
                dgv_manager.DataSource = null;
                dgv_manager.Rows.Clear();
                dgv_manager.Refresh();
                dr = null;
                DataTable dt = new DataTable();
                dr = db.Cmd("SELECT * FROM pracownicy");
                dt.Load(dr);
                dgv_manager.DataSource = dt;
                worker = true;	//Ustawianie która tabela jest wyświetlana, analogicznie pozostałe buttony
                crash = false;
                tams = false;
                rozklad = false;
                przystanki = false;
                zajezdnie = false;
                grafik = false;
            }
            db.Disconnect();
        }

        private void btn_crash_Click(object sender, EventArgs e)
        {
            if (db.Connect())
            {
                dgv_manager.DataSource = null;
                dgv_manager.Rows.Clear();
                dgv_manager.Refresh();
                dr = null;
                DataTable dt = new DataTable();
                dr = db.Cmd("SELECT * FROM wypadki_dane");
                dt.Load(dr);
                dgv_manager.DataSource = dt;
                worker = false;
                crash = true;
                tams = false;
                rozklad = false;
                przystanki = false;
                zajezdnie = false;
                grafik = false;
            }
            db.Disconnect();
        }

        private void btn_trams_Click(object sender, EventArgs e)
        {
            if (db.Connect())
            {
                dgv_manager.DataSource = null;
                dgv_manager.Rows.Clear();
                dgv_manager.Refresh();
                dr = null;
                DataTable dt = new DataTable();
                dr = db.Cmd("SELECT * FROM pojazdy");
                dt.Load(dr);
                dgv_manager.DataSource = dt;
                worker = false;
                crash = false;
                tams = true;
                rozklad = false;
                przystanki = false;
                zajezdnie = false;
                grafik = false;
            }
            db.Disconnect();
        }

        private void btn_rozk_Click(object sender, EventArgs e)
        {
            if (db.Connect())
            {
                dgv_manager.DataSource = null;
                dgv_manager.Rows.Clear();
                dgv_manager.Refresh();
                dr = null;
                DataTable dt = new DataTable();
                dr = db.Cmd("SELECT * FROM rozklad");
                dt.Load(dr);
                dgv_manager.DataSource = dt;
                worker = false;
                crash = false;
                tams = false;
                rozklad = true;
                przystanki = false;
                zajezdnie = false;
                grafik = false;
            }
            db.Disconnect();
        }



        private void btn_zaj_Click(object sender, EventArgs e)
        {
            if (db.Connect())
            {
                dgv_manager.DataSource = null;
                dgv_manager.Rows.Clear();
                dgv_manager.Refresh();
                dr = null;
                DataTable dt = new DataTable();
                dr = db.Cmd("SELECT * FROM zajezdnie");
                dt.Load(dr);
                dgv_manager.DataSource = dt;
                worker = false;
                crash = false;
                tams = false;
                rozklad = false;
                przystanki = false;
                zajezdnie = true;
                grafik = false;
            }
            db.Disconnect();
        }

        private void btn_st_Click(object sender, EventArgs e)
        {
            if (db.Connect())
            {
                dgv_manager.DataSource = null;
                dgv_manager.Rows.Clear();
                dgv_manager.Refresh();
                dr = null;
                DataTable dt = new DataTable();
                dr = db.Cmd("SELECT * FROM przystanki");
                dt.Load(dr);
                dgv_manager.DataSource = dt;
                worker = false;
                crash = false;
                tams = false;
                rozklad = false;
                przystanki = true;
                zajezdnie = false;
                grafik = false;
            }
            db.Disconnect();
        }

        private void btn_sch_Click(object sender, EventArgs e)
        {
            if (db.Connect())
            {
                dgv_manager.DataSource = null;
                dgv_manager.Rows.Clear();
                dgv_manager.Refresh();
                dr = null;
                DataTable dt = new DataTable();
                dr = db.Cmd("SELECT * FROM grafik");
                dt.Load(dr);
                dgv_manager.DataSource = dt;
                worker = false;
                crash = false;
                tams = false;
                rozklad = false;
                przystanki = false;
                zajezdnie = false;
                grafik = true;
            }
            db.Disconnect();
        }



        private void btn_own_Click(object sender, EventArgs e)	//Przycisk "Wykonaj"
        {
            if (db.Connect())
            {
                dr = null;
                try
                {
                    dr = db.Cmd(tb_own.Text);	//Próba wykonania własnej komendy
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            db.Disconnect();
        }
    }
}
