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
using System.Windows.Forms.DataVisualization.Charting;

namespace HalıSaha
{
    public partial class frmGrafikBilgileri : Form
    {
        public frmGrafikBilgileri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //ekranın kenarında gizlenmiş labellera bugünden itibaren önümüzdeki 7 günün tarih bilgileri atanır.
        private void frmGrafikBilgileri_Load(object sender, EventArgs e)
        {
            bilgiGetir();

            label2.Text = DateTime.Today.ToShortDateString().ToString();
            label3.Text = DateTime.Today.AddDays(1).ToShortDateString().ToString();
            label4.Text = DateTime.Today.AddDays(2).ToShortDateString().ToString();
            label5.Text = DateTime.Today.AddDays(3).ToShortDateString().ToString();
            label6.Text = DateTime.Today.AddDays(4).ToShortDateString().ToString();
            label7.Text = DateTime.Today.AddDays(5).ToShortDateString().ToString();
            label8.Text = DateTime.Today.AddDays(6).ToShortDateString().ToString();
        }


        //Saha listesini buton olarak getir.
        private void bilgiGetir()
        {
            pnl_sahalistesi.Controls.Clear(); // Sahalar için butonları temizle

            List<EntSaha> sahaListesi = BLsaha.sahaListele(); // Sahaların listesini al
            int y = 0;

            // Sahalar için butonları oluşturuyoruz
            foreach (EntSaha saha in sahaListesi)
            {
                Button btn = new Button
                {
                    Text = saha.sahaadi,
                    Tag = saha.id,
                    Width = 122,
                    Height = 60,
                    BackColor = ColorTranslator.FromHtml("#025E73"),
                    ForeColor = Color.Lime,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    Location = new Point(0, y) // Butonları yerleştiriyoruz
                };

                btn.Click += Btn_Click; // Buton tıklandığında event handler
                pnl_sahalistesi.Controls.Add(btn); // Butonu panele ekliyoruz
                y += btn.Height + 5; // Butonların aralarına boşluk bırakıyoruz
            }
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            try
            {
                // Grafik serilerini temizle
                chart1.Series.Clear();

                // Tıklanan butonu al
                Button btn = (Button)sender;
                label9.Text = btn.Tag.ToString();

                // Tıklanan butonun bulunduğu paneldeki diğer butonların rengini kontrol et ve varsayılan renge döndür
                foreach (Control item in btn.Parent.Controls)
                {
                    if (item is Button) // Eğer kontrol bir buton ise
                    {
                        ((Button)item).BackColor = ColorTranslator.FromHtml("#025E73"); // Varsayılan renk
                    }
                }

                // Seçilen butonun rengini değiştir
                btn.BackColor = Color.Orange;

                // Veri sorgulama
                //kayıtsayısı getir fonksiyonuna sahaid ve tarih ile gideriz içinde kaç kayıt olduğunu gun1'den 7 ye kadar olan int değerlere atılır. sonuçta sorgulama oradan yapılır.
                int gun1Sayi = kayıtSayGetir(label9.Text, label2.Text);
                int gun2Sayi = kayıtSayGetir(label9.Text, label3.Text);
                int gun3Sayi = kayıtSayGetir(label9.Text, label4.Text);
                int gun4Sayi = kayıtSayGetir(label9.Text, label5.Text);
                int gun5Sayi = kayıtSayGetir(label9.Text, label6.Text);
                int gun6Sayi = kayıtSayGetir(label9.Text, label7.Text);
                int gun7Sayi = kayıtSayGetir(label9.Text, label8.Text);

                // Eğer tüm günlerin toplam kaydı sıfırsa grafiği güncelleme
                if (gun1Sayi + gun2Sayi + gun3Sayi + gun4Sayi + gun5Sayi + gun6Sayi + gun7Sayi == 0)
                {
                    MessageBox.Show("Seçilen saha için kayıt bulunmamaktadır.");
                    return;
                }

                // Grafik serisi ekleme
                var series = new Series("Randevu Sayısı");
                series.ChartType = SeriesChartType.Column;

                // Verileri ekle
                series.Points.AddXY(DateTime.Today.ToShortDateString(), gun1Sayi);
                series.Points.AddXY(DateTime.Today.AddDays(1).ToShortDateString(), gun2Sayi);
                series.Points.AddXY(DateTime.Today.AddDays(2).ToShortDateString(), gun3Sayi);
                series.Points.AddXY(DateTime.Today.AddDays(3).ToShortDateString(), gun4Sayi);
                series.Points.AddXY(DateTime.Today.AddDays(4).ToShortDateString(), gun5Sayi);
                series.Points.AddXY(DateTime.Today.AddDays(5).ToShortDateString(), gun6Sayi);
                series.Points.AddXY(DateTime.Today.AddDays(6).ToShortDateString(), gun7Sayi);

                chart1.Series.Add(series);

                chart1.ChartAreas[0].AxisY.Minimum = 0; // Minimum değer
                chart1.ChartAreas[0].AxisY.Maximum = 14; // Maksimum değer
                chart1.ChartAreas[0].AxisY.Interval = 1; // İsteğe bağlı: Y eksenindeki aralık
            }

            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        //sahaid ve randevu tarihi bilgileriyle o güne ait kaç adet kayıt olduğu bilgisini veren fonksiyon
        public int kayıtSayGetir(string sahaid, string randevu_tarihi)
        {

            List<EntKayit> kayitListesi = BLkayit.grafilBilgiGetir(randevu_tarihi, sahaid);

            if (kayitListesi == null || kayitListesi.Count == 0)
            {
                //eğer çekilen kayıt sayısı 0 ise 0 döndür.
                return 0;
            }
            else
            {
                int kayıtSayisi = kayitListesi.Count;
                //kayıt listesi'nin eleman sayısını return eder.

                return kayıtSayisi;
            }


        }

    }
}
