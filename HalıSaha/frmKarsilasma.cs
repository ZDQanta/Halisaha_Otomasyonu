using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalıSaha
{
    public partial class frmKarsilasma : Form
    {
        public frmKarsilasma()
        {
            InitializeComponent();
        }
        string sahaAdi;
        string mailAciklama;

        // Karşılaşma tarihi şeçimi
        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            karsilasma_tarih.Text = btn.Text;
            karsilasmatarih.Text = btn.Text;

        
            // Butonların bulunduğu paneldeki diğer butonların renklerini kontrol et ve varsayılan renge döndür
            foreach (Control item in btn.Parent.Controls)
            {
                if (item is Button) // Eğer kontrol bir buton ise
                {
                    ((Button)item).BackColor = Color.Lime; // Varsayılan renk
                }
            }

            // Seçilen butonun rengini değiştir
            btn.BackColor = Color.Orange;

            // Eğer karşılaşma tarihi ve saati seçilmişse saha bilgilerini göster
            if (karsilasmatarih.Text != "null" && karsilasmasaat.Text != "null")
            {
                bilgiGetir();
            }


        }

        private void frmKarsilasma_Load(object sender, EventArgs e)
        {
            //haftalık olarak saha kiralama yapılır günümüz tarihi baz alınır 
            string sonTarih = button7.Text;
            DateTime bugun = DateTime.Now;
            button1.Text = bugun.ToShortDateString();
            button2.Text = bugun.AddDays(1).ToShortDateString();
            button3.Text = bugun.AddDays(2).ToShortDateString();
            button4.Text = bugun.AddDays(3).ToShortDateString();
            button5.Text = bugun.AddDays(4).ToShortDateString();
            button6.Text = bugun.AddDays(5).ToShortDateString();
            button7.Text = bugun.AddDays(6).ToShortDateString();

            karsilasmatarih.Text = "null";
            karsilasmasaat.Text = "null";
            lbl_secilensaha.Text = "8";
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Saat butonlarının şeçimi 
        private void button14_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            karsilasma_saati.Text = btn.Text;
            karsilasmasaat.Text = btn.Text;

            // Butonların bulunduğu paneli kontrol edelim
            foreach (Control item in karsilasma_saati.Controls)
            {
                if (item is Button) // Eğer kontrol bir buton ise
                {
                    // Butonun rengini varsayılan renge çevir
                    ((Button)item).BackColor = Color.FromArgb(64, 64, 64);
                }

            }

            if (karsilasmatarih.Text != "null" && karsilasmasaat.Text != "null")
            {
                bilgiGetir();
            }
            // Seçilen butonun rengini değiştir
            btn.BackColor = Color.Orange;
        }
        // Mevcut Sahaları buton olarak getirir 
        private void bilgiGetir()
        {
            sahaListePanel.Controls.Clear(); // Paneli temizle

            // İş katmanından sahaları getir
            List<EntSaha> sahaListesi = BLsaha.sahaListele();
            // İş katmanından saha kayıtlarını getirir.
            List<EntKayit> mevcutKayitlar = BLkayit.kayitlariGetir(karsilasmatarih.Text, karsilasmasaat.Text);
            int y = 0;
            int butonSayisi = 0;  // Her satırda 3 buton olacak
            int x = 0;
            foreach (EntSaha saha in sahaListesi)
            {
                Button btn = new Button();
                btn.Text = saha.sahaadi + "\n" + saha.id; // Saha adını butona yazdır
                btn.Tag = saha.id; // Saha ID'sini tag olarak ata
                btn.Width = 170;
                btn.Height = 80;
                btn.BackColor = ColorTranslator.FromHtml("#025E73");
                btn.ForeColor = Color.Lime;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Cursor = Cursors.Hand;

                // Seçilen tarih ve saatte bu saha rezerve edilmiş mi kontrol et
                bool sahaRezerveEdilmis = mevcutKayitlar.Any(k => k.sahaid == saha.id.ToString());

                if (sahaRezerveEdilmis)
                {
                    // Eğer saha rezerve edildiyse, buton kırmızı ve tıklanamaz hale gelir
                    btn.BackColor = Color.Red;
                    btn.Enabled = false;  // Tıklanamaz
                }


                btn.Location = new Point(x, y);

                butonSayisi++;

                // Eğer 6 buton dizildiyse, yeni satıra geç
                if (butonSayisi % 6 == 0)
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

                btn.Click += btn_Click;
            }

        }
        //Saha butonunun click'i
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            lbl_secilensaha.Text = btn.Tag.ToString();
            string text = btn.Text;
            sahaAdi = text.Split('\n')[0];


            foreach (Control item in sahaListePanel.Controls)
            {
                if (item is Button) // Eğer kontrol bir buton ise
                {
                    // Butonun rengini kontrol et ve eğer kırmızı değilse değiştirilmesini sağla
                    if (((Button)item).BackColor != Color.Red)
                    {
                        ((Button)item).BackColor = ColorTranslator.FromHtml("#025E73");
                    }
                }
            }

            // Sadece tıklanan butonun rengini turuncu yap
            btn.BackColor = Color.Orange;
        }

        private void btn_secimionayla_Click(object sender, EventArgs e)
        {
            if (txt_tc.Text != "" && txt_adsoyad.Text != "" && txt_mail.Text != "" && txt_tel.Text != "" && karsilasmatarih.Text != "null" && karsilasmasaat.Text != "null")
            {
                lbl_adsoyad.Text = txt_adsoyad.Text;
                lbl_mail.Text = txt_mail.Text;
                lbl_tel.Text = txt_tel.Text;
                lbl_tc.Text = txt_tc.Text;

                bilgi_panel.Visible = false;
                pnl_islem_onaylama.Visible = true;
                label1.Text = "İŞLEM ONAYLAMA EKRANI";

                mailAciklama = "Sayın " + lbl_adsoyad.Text + " " + " \n " + karsilasma_tarih.Text + " günü, " + karsilasma_saati.Text + " saatinde, " + sahaAdi + " sahasında randevunuz alınmıştır.\n İyi Günler...";

                txt_aciklama.Text = mailAciklama;
            }
            else
            {
                MessageBox.Show("Lütfen Boş alanları doldurunuz !");
            }


        }

        private void btn_geriDön_Click(object sender, EventArgs e)
        {
            bilgi_panel.Visible = true;
            pnl_islem_onaylama.Visible = false;
        }

        private void btn_islemTamamla_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            lbl_kayit_tarih.Text = time.ToString();
            
            //Kayıt bilgileri gerekli yerlerden alındığından entKayıt tipindeki kayıt içine bilgileri atar 

            EntKayit kayit = new EntKayit();
            kayit.tc = txt_tc.Text;
            kayit.adsoyad = txt_adsoyad.Text.ToUpper();
            kayit.mail = txt_mail.Text;
            kayit.randevu_tarih = karsilasmatarih.Text;
            kayit.randevu_saati = karsilasmasaat.Text;
            kayit.sahaid = lbl_secilensaha.Text;
            kayit.fiyat = txt_tutar.Text;
            kayit.telno = lbl_tel.Text;
            kayit.kayit_Tarih = lbl_kayit_tarih.Text;

            BLkayit.BLkayitekle(kayit);
            mailgonder(kayit.mail);

            MessageBox.Show("Kayıt Tamamlandı");

            //formu yeniden başlatma

            var openForms = Application.OpenForms.Cast<Form>().ToList();

            foreach (Form item in openForms)
            {
                if (item.GetType().Name == "frmKarsilasma")
                {
                    item.Close();
                    item.Controls.Clear(); // Gerekliyse kullanın
                }
            }

            frmKarsilasma kre = new frmKarsilasma();
            kre.ShowDialog();

            // Mevcut formu kapat
        }
        // Bu gmail için geçerlidir 
        private void mailgonder(string mail)
        {
            if (string.IsNullOrWhiteSpace(lbl_mail.Text))
            {
                MessageBox.Show("Lütfen alıcı e-posta adresini girin.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_aciklama.Text))
            {
                MessageBox.Show("Lütfen açıklama kısmını doldurun.");
                return;
            }

            try
            {
                SmtpClient smtp = new SmtpClient()
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    Credentials = new NetworkCredential("gorselproglama@gmail.com", "mxai ahgs nfcf etlo")

                };

                MailMessage mailMessage = new MailMessage()
                {
                    From = new MailAddress("gorselproglama@gmail.com"),
                    Subject = "Randevu Bilgilendirme",
                    Body = txt_aciklama.Text

                };
                mailMessage.To.Add(mail);

                smtp.Send(mailMessage);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Mail gönderilirken bir hata oluştu: " + ex.Message);
            }
        }

        private void txt_tc_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece rakam girişine izin ver
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }

        }

        private void txt_tc_TextChanged(object sender, EventArgs e)
        {
            // Maksimum 11 karaktere izin ver
            if (txt_tc.Text.Length > 11)
            {
                txt_tc.Text = txt_tc.Text.Substring(0, 11);
                txt_tc.SelectionStart = txt_tc.Text.Length; // İmleci sonuna getir
            }
        }

        private void txt_tel_TextChanged(object sender, EventArgs e)
        {
            // Maksimum 13 karakter olacak şekilde 
            string text = txt_tel.Text.Replace(" ", "");
            if (text.Length > 11)
                text = text.Substring(0, 11);

            // Format: "XXXX XXX XX XX"
            if (text.Length > 4)
                text = text.Insert(4, " ");
            if (text.Length > 8)
                text = text.Insert(8, " ");
            if (text.Length > 11)
                text = text.Insert(11, " ");

            txt_tel.Text = text;
            txt_tel.SelectionStart = txt_tel.Text.Length;
        }

        private void txt_tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Yalnızca rakam ve boşluk girişine izin ver
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Harfi veya özel karakteri engelle
            }
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        // hatalı mail girişinde hata mesajı gönderir ve uygun formatta mail girilmedikçe mesaj gelmeye devam eder
        private void txt_mail_Leave(object sender, EventArgs e)
        {
            if (!IsValidEmail(txt_mail.Text))
            {
                MessageBox.Show("Lütfen geçerli bir e-posta adresi giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_mail.Focus();
            }
        }
        // tutar girildğinde btn_islemTamamla enabled olur  
        private void txt_tutar_TextChanged(object sender, EventArgs e)
        {
            btn_islemTamamla.Enabled = !string.IsNullOrWhiteSpace(txt_tutar.Text);

        }
    }
}
