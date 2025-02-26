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
    public partial class frmSahaListele : Form
    {
        public frmSahaListele()
        {
            InitializeComponent();
        }

        private void frmSahaListele_Load(object sender, EventArgs e)
        {
            bilgiGetir();
        }
        private void bilgiGetir()
        {
            sahaListePanel.Controls.Clear(); // Paneli temizle

            // İş katmanından sahaları getir
            List<EntSaha> sahaListesi = BLsaha.sahaListele();
            int y = 0;
            int butonSayisi = 0;  // Her satırda 3 buton olacak
            int x = 0;
            foreach (EntSaha saha in sahaListesi)
            {
                Button btn = new Button();
                btn.Text = saha.sahaadi + "\n" + saha.id; // Saha adını butona yazdır
                btn.Tag = saha.id; // Saha ID'sini tag olarak ata
                btn.Width = 195;
                btn.Height = 100;
                btn.BackColor = ColorTranslator.FromHtml("#025E73");
                btn.ForeColor = Color.Lime;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Cursor = Cursors.Hand;


                btn.Location = new Point(x, y);

                butonSayisi++;

                // Eğer 3 buton dizildiyse, yeni satıra geç
                if (butonSayisi % 3 == 0)
                {
                    x = 0;  // Satır doldu, x'i sıfırla
                    y += btn.Height + 10;  // Yeni satıra geç (buton yüksekliği + boşluk)
                }
                else
                {
                    x += btn.Width + 10;  // Yan yana dizilme (buton genişliği + boşluk)
                }
                // Butonu panele ekle
                sahaListePanel.Controls.Add(btn);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        }
    }
