using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalıSaha
{
    public partial class frmSecimEkrani : Form
    {
        public frmSecimEkrani()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmSahaDuzenleme frmsahaduzenle = new frmSahaDuzenleme();
            frmsahaduzenle.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmSahaKayıtEkrani frmsahakayit = new frmSahaKayıtEkrani();
            frmsahakayit.Show();
        }
    }
}
