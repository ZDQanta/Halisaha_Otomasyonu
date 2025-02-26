using BusinessLayer;
using EntityLayer;
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
    public partial class frmSahaKayıtEkrani : Form
    {
        public frmSahaKayıtEkrani()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RB_DOGAL_CheckedChanged(object sender, EventArgs e)
        {
            lbl_cimturu.Text = "DOĞAL";
            RB_DOGAL.ForeColor = Color.Red;
            rb_yapay.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void rb_yapay_CheckedChanged(object sender, EventArgs e)
        {
            lbl_cimturu.Text = "YAPAY";
            rb_yapay.ForeColor = Color.Red;
            RB_DOGAL.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void rb_acik_CheckedChanged(object sender, EventArgs e)
        {
            lbl_sahaturu.Text = "AÇIK";
            rb_acik.ForeColor = Color.Red;
            rb_kapali.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void rb_kapali_CheckedChanged(object sender, EventArgs e)
        {
            lbl_sahaturu.Text = "KAPALI";
            rb_kapali.ForeColor = Color.Red;
            rb_acik.ForeColor = Color.FromArgb(64, 64, 64);
        }

        void temizlememetodu()
        {
            txt_sahaadi.Text = "";
            txtacıklama.Text = "";
            rb_acik.Checked = true;
            RB_DOGAL.Checked = true;
            txt_sahaadi.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_sahaadi.Text != "" && txtacıklama.Text != "")
            {
                EntSaha saha = new EntSaha();
                saha.sahaadi = txt_sahaadi.Text.ToUpper();
                saha.sahaturu = lbl_sahaturu.Text;
                saha.cimturu = lbl_cimturu.Text;
                saha.aciklama = txtacıklama.Text;

                BLsaha.BLsahaekle(saha);
                MessageBox.Show("Kayıt Tamamlandı");

                temizlememetodu();

                //Entsaha tipinde bir saha tanımlanır ve kullanıcıdan alınan veriler bu nesneye doldurulur.
                //bussines katmanına gidilir ve blsaha adında nesne oluşturulur.
                //bu nesnenin içinde blSaha ekle fonksiyonu vardır.
                //dataaccess'e uygun olup olmadığı kontrol edilir.
                //sonucunda dalsaha adındaki dal katmanına gidilir ve ekleme fonksiyonu çalıştırılır.
                //nesne veritabanına eklenir.
                Application.Restart();



            }
            else
            {
                //Saha adının boş olduğunu bildirir
                MessageBox.Show("Lütfen Boş Alanları Doldurunuz");

            }
        }
    }
}
