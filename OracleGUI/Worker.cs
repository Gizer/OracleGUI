using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace OracleGUI
{
    public partial class Worker : Form
    {
        DBConnect db = new DBConnect();
        DataTable dt = new DataTable();
        OracleDataReader dr;
        public Worker()
        {
            InitializeComponent();
            if (db.Connect())
            {
                dgv_worker.Rows.Clear();
                dgv_worker.Refresh();
                dr = db.Cmd("SELECT * FROM pracownicy WHERE id_pracownika = 'AAAAE'");  //Domyślny widok
                dt.Load(dr);
                dgv_worker.DataSource = dt;
            }
            db.Disconnect();
        }

        private void btn_info_Click(object sender, EventArgs e)                         //Przycisk "O mnie"
        {
            if (db.Connect())
            {
                dgv_worker.DataSource = null;
                dgv_worker.Rows.Clear();
                dgv_worker.Refresh();
                dr = null;
                DataTable dt = new DataTable();
                dr = db.Cmd("SELECT * FROM pracownicy WHERE id_pracownika = 'AAAAE'");  //Zwraca 

                informacje o zalogowanym pracowniku
                dt.Load(dr);
                dgv_worker.DataSource = dt;
            }
            db.Disconnect();
        }

        private void btn_sch_Click(object sender, EventArgs e)                          //Przycisk "Grafik"
        {
            if (db.Connect())
            {
                dgv_worker.DataSource = null;
                dgv_worker.Rows.Clear();
                dgv_worker.Refresh();
                dr = null;
                DataTable dt = new DataTable();
                dr = db.Cmd("SELECT * FROM grafiki_zajzdnie WHERE id_pracownika = 'AAAAE'"); //Zwraca informacje o grafiku danego pracownika
                dt.Load(dr);
                dgv_worker.DataSource = dt;
            }
            db.Disconnect();
        }
    }
}
