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
    public partial class itemsadd : Form
    {
        public itemsadd()
        {
            InitializeComponent();
           
        }
        MySqlConnection con = new MySqlConnection("server=localhost; database=posvbnet_kopitong; username=root; password=root;");

        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (txtbarcode.Text == "" || txtname.Text == "" || txtdesc.Text == "" || txtprice.Text == "")
            {
                MessageBox.Show("Anda belum mengisikan semua kolom");
            }
            else
            {
                DialogResult yakin = MessageBox.Show("Apakah anda sudah yakin dengan isian anda?", "Add Items", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (yakin == DialogResult.Yes)
                {
                    MySqlCommand com = new MySqlCommand();
                    com.Connection = con;
                    com.CommandText = "INSERT INTO items(barcode,nama_item,deskripsi_item,harga_item) values(@barcode,@namaitem,@deskitem,@hargaitem)";
                    com.Parameters.AddWithValue("@barcode", txtbarcode.Text);
                    com.Parameters.AddWithValue("@namaitem", txtname.Text);
                    com.Parameters.AddWithValue("@deskitem", txtdesc.Text);
                    com.Parameters.AddWithValue("@hargaitem", txtprice.Text);

                    con.Open();
                    com.ExecuteNonQuery();
                    MessageBox.Show("Item telah ditambahkan", "Add Items", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    itemsadd.ActiveForm.Hide();
                }
                else
                {
                    itemsadd.ActiveForm.Show();
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            itemsadd.ActiveForm.Hide();
            items.ActiveForm.Show();
        }

        private void itemsadd_Load(object sender, EventArgs e)
        {
            txtbarcode.Focus();
        }
    }
}
