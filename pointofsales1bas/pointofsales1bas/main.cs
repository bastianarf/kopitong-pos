using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pointofsales1bas
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = DateTime.Now.ToLongDateString();
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }


        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            items newitem = new items();
            this.Hide();
            newitem.Show();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            users newuser = new users();
            this.Hide();
            newuser.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
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
    }
}
