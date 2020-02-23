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
    public partial class items : Form
    {
        public items()
        {
            InitializeComponent();
        }
        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }
        }
        MySqlConnection con = new MySqlConnection("server=localhost; database=posvbnet_kopitong; username=root; password=root;");
        string query = "SELECT barcode, nama_item, deskripsi_item, harga_item FROM items";


        private void tableload()
        {
            MySqlDataAdapter data = new MySqlDataAdapter(query, con);
            DataTable ds = new DataTable();
            data.Fill(ds);
            dataGridView1.DataSource = ds;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void items_Load(object sender, EventArgs e)
        {
            con.Open();
            tableload();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Apakah anda yakin keluar dari program ini?", "KopiTong", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (exit == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (exit == DialogResult.No)
            {
                this.Show();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            main utama = new main();
            this.Hide();
            utama.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            itemsadd tambah = new itemsadd();
            tambah.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            tableload();
            dataGridView1.Update();
            dataGridView1.Refresh();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MySqlCommand com = new MySqlCommand();
            com.Connection = con;
            //  string selectedrow = dataGridView1.SelectedRows[].Cells[].Value.ToString();
            DialogResult hapus = MessageBox.Show("Apakah anda yakin akan menghapus item ini?", "Remove Items", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hapus == DialogResult.Yes)
            {
                com.CommandText = "DELETE FROM items WHERE barcode = " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                com.ExecuteNonQuery();
                MessageBox.Show("Item telah dihapus", "Item", MessageBoxButtons.OK);
            }
            else
            {
                items.ActiveForm.Show();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            itemsedit edit = new itemsedit();
            edit.Show();

        }
    }
}
