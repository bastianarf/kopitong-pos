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
    public partial class itemsedit : Form
    {
        public itemsedit()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("server=localhost; database=posvbnet_kopitong; username=root; password=root;");
        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }
        }
        private void txtbarcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void itemsedit_Load(object sender, EventArgs e)
        {
            MySqlCommand qur = new MySqlCommand();
            qur.Connection = con;
            qur.CommandText = "SELECT barcode, nama_item, deskripsi_item, harga_item FROM items WHERE barcode = "+ dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            qur.ExecuteNonQuery();
            MySqlDataAdapter data = new MySqlDataAdapter(qur);
            DataTable ds = new DataTable();
            data.Fill(ds);
            foreach (DataRow dr in ds.Rows)
            {
                txtbarcode.Text = dr["barcode"].ToString();
                txtname.Text = dr["nama_item"].ToString();
                txtdesc.Text = dr["deskripsi_item"].ToString();
                txtprice.Text = dr["harga_item"].ToString();
            }
        }
    }
}
