using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Ödevi
{
    public partial class girisForm : Form
    {
        public girisForm()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {


        }
        private void gozIcon_MouseHover(object sender, MouseEventArgs e)
        {
            sifreText.PasswordChar = '\0';
        }

        private void gozIcon_MouseLeave(object sender, EventArgs e)
        {
            sifreText.PasswordChar = '*';
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void gozIcon_MouseHover(object sender, EventArgs e)
        {
            sifreText.PasswordChar = '\0';
        }

        private void gozIcon_MouseLeave_1(object sender, EventArgs e)
        {
            sifreText.PasswordChar = '*';
        }

        private void girisYap_Click(object sender, EventArgs e)
        {


            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }
    }
}
