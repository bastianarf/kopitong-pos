using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace pointofsales1bas
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("server=localhost; database=posvbnet_kopitong; username=root; password=root;");
        int count;

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username, password;
            username = textuser.Text;
            password = textpass.Text;

            count = count + 1;
            if (count > 3)
            {
                MessageBox.Show("Username dan Password telah melakukan tiga kali kesalahan, Maaf anda ter-Blocked");
                Application.Exit();
            }
            else if (username == "" && password == "")
            {
                label3.Text = "Username dan Password tidak boleh kosong";
            }
            else
            {
                string query = "SELECT * from login WHERE username = '" + username + "' && password = '" + password + "' ";
                MySqlDataAdapter data = new MySqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                data.Fill(dt);

                if(dt.Rows.Count == 1)
                {
                    main utama = new main();
                    this.Hide();
                    utama.Show();
                }
                else
                {
                    label3.Text = "Coba Lagi";
                    textuser.Clear();
                    textpass.Clear();
                    textuser.Focus();
                }
            }   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = "";
        }
    }
}
