using BusinessLayer;
using DataAccessLayer;
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
    public partial class frmSahaDuzenleme : Form
    {
        public frmSahaDuzenleme()
        {
            InitializeComponent();  
        }
        // comboboxdan  bir saha şeçildiğinde sil butonu visible ı true olur
        private void button3_Click(object sender, EventArgs e)
        {
            //şeçilen sahanın id'sı selectedSahaId ye atanır
            int selectedSahaId = (sec_combo.SelectedItem as dynamic).id;

            

            DialogResult dialogResult = MessageBox.Show("Bu sahayı silmek istediğinize emin misiniz?", "Saha Silme", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int sonuc = BLsaha.BLsahaSil(selectedSahaId);

                if (sonuc > 0)
                {
                    MessageBox.Show("Halı saha başarıyla silindi.");
                    sec_combo.Items.Clear();
                    frmSahaDuzenleme_Load(sender, e);
                    Application.Restart();
                }
                else
                {
                    MessageBox.Show("Silme işlemi sırasında bir hata oluştu.");
                }
            }   
        }

        private void frmSahaDuzenleme_Load(object sender, EventArgs e)
        {
            List<EntSaha> sahalar = DALSaha.sahaListesiGetir();
            foreach (var saha in sahalar)
            {
                sec_combo.Items.Add(new { saha.id, saha.sahaadi });
            }
            // Sil butonunu gizle
            button3.Visible = false;

            sec_combo.DisplayMember = "sahaadi";
            sec_combo.ValueMember = "id";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Seçili halı saha bilgilerini güncelle
            EntSaha guncellenenSaha = new EntSaha
            {
                id = (sec_combo.SelectedItem as dynamic).id,
                sahaadi = txt_sahaadi.Text,
                sahaturu = lbl_sahaturu.Text,
                cimturu = lbl_cimturu.Text,
                aciklama = txtacıklama.Text
            };

            int sonuc = BLsaha.BLsahaguncelle(guncellenenSaha);

            if (sonuc > 0)
            {
                MessageBox.Show("Halı saha başarıyla güncellendi.");
                
            }
            else
            {
                MessageBox.Show("Güncelleme sırasında bir hata oluştu.");
            }
        }

        private void sec_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ComboBox'tan seçilen halı saha bilgilerini getir
            int selectedSahaId = (sec_combo.SelectedItem as dynamic).id;
            EntSaha secilenSaha = DALSaha.sahaBilgiGetir(selectedSahaId);

            if (secilenSaha != null)
            {
                button3.Visible = true;
                txt_sahaadi.Text = secilenSaha.sahaadi;
                lbl_sahaturu.Text = secilenSaha.sahaturu;
                lbl_cimturu.Text = secilenSaha.cimturu;
                txtacıklama.Text = secilenSaha.aciklama;
            }
            else
            {
                button3.Visible = false;

            }
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
    }
}
