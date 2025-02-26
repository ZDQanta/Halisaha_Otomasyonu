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
    public partial class frmAnaEkran : Form
    {
        public frmAnaEkran()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmSecimEkrani frm = new frmSecimEkrani(); 
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmSahaListele frmshl = new frmSahaListele();   
            frmshl.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmGrafikBilgileri frmanaliz = new frmGrafikBilgileri();
            frmanaliz.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmKayitlariListele frmkayitlistele = new frmKayitlariListele();
            frmkayitlistele.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmKarsilasma frmkarsilasma = new frmKarsilasma();
            frmkarsilasma.Show();
        }


        private void bilgiGetir()
        {

            pnl_sahalistesi.Controls.Clear(); // Paneli temizle

            // İş katmanından sahaları getir
            List<EntSaha> sahaListesi = BLsaha.sahaListele();
            int y = 0;
            int butonSayisi = 0;  // Her satırda 3 buton olacak
            int x = 0;
            foreach (EntSaha saha in sahaListesi)
            {
                Button btn = new Button();
                btn.Text = saha.sahaadi; // Saha adını butona yazdır
                btn.Tag = saha.id; // Saha ID'sini tag olarak ata
                btn.Width = 292;
                btn.Height = 80;
                btn.BackColor = ColorTranslator.FromHtml("#025E73");
                btn.ForeColor = Color.Lime;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Cursor = Cursors.Hand;
                
               


                btn.Location = new Point(x, y);

                butonSayisi++;

                // Eğer 1 buton dizildiyse, yeni satıra geç
                if (butonSayisi % 1 == 0)
                {
                    x = 0;  // Satır doldu, x'i sıfırla
                    y += btn.Height + 10;  // Yeni satıra geç (buton yüksekliği + boşluk)
                }
                btn.Click += btn_Click;

                // Butonu panele ekle
                pnl_sahalistesi.Controls.Add(btn);
            }
        }
        string sahaid;

        //Halısaha isimlerine tıklandığında paneller resetlenir ve tıklanan halısaha kayıtları ekrana getirilir.
        private void btn_Click(object sender, EventArgs e)
        {
            birinciPanel.Controls.Clear();
            ikinciPanel.Controls.Clear();
            üçüncüPanel.Controls.Clear();
            dördüncüPanel.Controls.Clear();
            beşinciPanel.Controls.Clear();
            altıncıPanel.Controls.Clear();
            yedinciPanel.Controls.Clear();

            Button btn = (Button)sender;
            sahaid = btn.Tag.ToString();
            MevcutKayıtlariGetir();

            // Bulunduğu paneldeki diğer butonların rengini kontrol et ve varsayılan renge döndür
            foreach (Control item in btn.Parent.Controls)
            {
                if (item is Button) // Eğer kontrol bir buton ise
                {
                    ((Button)item).BackColor = ColorTranslator.FromHtml("#025E73"); // Varsayılan renk
                }
            }

            // Seçilen butonun rengini değiştir
            btn.BackColor = Color.Orange;


        }

        //DataAccessLayer'deki mevcut kayıt fonksiyonuna seçilen tarih,saat ve sahaid bilgileri ile gidre ve eğer o bilgilerle uyuşan veri çekilir.o kayıtları karşılayan şablonumuzn rengide kırmızıya çevrilir.
        private void musaitlik(string tarih, string saat, UserControl sablon, string sahaid)
        {

            EntKayit mevcutkayit = BLkayit.mevuctkayit(tarih, saat, sahaid);

            if (mevcutkayit.randevu_tarih == tarih && mevcutkayit.randevu_saati == saat)
            {
                sablon.BackColor = Color.Red;
                sablon.ForeColor = Color.White;

            }
            else
            {
                sablon.BackColor = ColorTranslator.FromHtml("#038C17");
                sablon.ForeColor = Color.White;
            }

        }

        void MevcutKayıtlariGetir()
        {

            //labellara gün ismi verme
            //Bugünden başlayarak önümüzdeki 7 günün tarih ve gün bilgileri labellere aktarılır.
            label2.Text = DateTime.Today.ToShortDateString() + "\n" + DateTime.Today.ToString("dddd");
            label3.Text = DateTime.Today.AddDays(1).ToShortDateString() + "\n" + DateTime.Today.AddDays(1).ToString("dddd");
            label4.Text = DateTime.Today.AddDays(2).ToShortDateString() + "\n" + DateTime.Today.AddDays(2).ToString("dddd");
            label5.Text = DateTime.Today.AddDays(3).ToShortDateString() + "\n" + DateTime.Today.AddDays(3).ToString("dddd");
            label6.Text = DateTime.Today.AddDays(4).ToShortDateString() + "\n" + DateTime.Today.AddDays(4).ToString("dddd");
            label7.Text = DateTime.Today.AddDays(5).ToShortDateString() + "\n" + DateTime.Today.AddDays(5).ToString("dddd");
            label8.Text = DateTime.Today.AddDays(6).ToShortDateString() + "\n" + DateTime.Today.AddDays(6).ToString("dddd");


            DateTime tarih = DateTime.Today; // Bugünün tarihi için gösterim yapacak



            for (int i = 10; i < 24; i++)
            {
                //birinci gün
                //Birinci günün müsaitlik şablonları oluşturulur. 

                sahaKontrol sablon = new sahaKontrol();
                birinciPanel.Controls.Add(sablon);
                sablon.label1.Text = i.ToString() + ":00 - " + (i + 1).ToString() + ":00";
                sablon.lblTarih.Text = DateTime.Today.ToShortDateString();
                musaitlik(sablon.lblTarih.Text, sablon.label1.Text, sablon, sahaid);



            }
            for (int i = 10; i < 24; i++)
            {
                //ikinci gün

                sahaKontrol sablon = new sahaKontrol();
                ikinciPanel.Controls.Add(sablon);
                sablon.label1.Text = i.ToString() + ":00 - " + (i + 1).ToString() + ":00";
                sablon.lblTarih.Text = DateTime.Today.AddDays(1).ToShortDateString();
                musaitlik(sablon.lblTarih.Text, sablon.label1.Text, sablon, sahaid);
            }
            for (int i = 10; i < 24; i++)
            {
                //üçüncü gün

                sahaKontrol sablon = new sahaKontrol();
                üçüncüPanel.Controls.Add(sablon);
                sablon.label1.Text = i.ToString() + ":00 - " + (i + 1).ToString() + ":00";
                sablon.lblTarih.Text = DateTime.Today.AddDays(2).ToShortDateString();
                musaitlik(sablon.lblTarih.Text, sablon.label1.Text, sablon, sahaid);

            }
            for (int i = 10; i < 24; i++)
            {
                //dördüncü gün

                sahaKontrol sablon = new sahaKontrol();
                dördüncüPanel.Controls.Add(sablon);
                sablon.label1.Text = i.ToString() + ":00 - " + (i + 1).ToString() + ":00";
                sablon.lblTarih.Text = DateTime.Today.AddDays(3).ToShortDateString();
                musaitlik(sablon.lblTarih.Text, sablon.label1.Text, sablon, sahaid);
            }
            for (int i = 10; i < 24; i++)
            {
                //beşinci gün

                sahaKontrol sablon = new sahaKontrol();
                beşinciPanel.Controls.Add(sablon);
                sablon.label1.Text = i.ToString() + ":00 - " + (i + 1).ToString() + ":00";
                sablon.lblTarih.Text = DateTime.Today.AddDays(4).ToShortDateString();
                musaitlik(sablon.lblTarih.Text, sablon.label1.Text, sablon, sahaid);
            }
            for (int i = 10; i < 24; i++)
            {
                //altıncı gün

                sahaKontrol sablon = new sahaKontrol();
                altıncıPanel.Controls.Add(sablon);
                sablon.label1.Text = i.ToString() + ":00 - " + (i + 1).ToString() + ":00";
                sablon.lblTarih.Text = DateTime.Today.AddDays(5).ToShortDateString();
                musaitlik(sablon.lblTarih.Text, sablon.label1.Text, sablon, sahaid);
            }
            for (int i = 10; i < 24; i++)
            {
                sahaKontrol sablon = new sahaKontrol();
                yedinciPanel.Controls.Add(sablon);
                sablon.label1.Text = i.ToString() + ":00 - " + (i + 1).ToString() + ":00";
                sablon.lblTarih.Text = DateTime.Today.AddDays(6).ToShortDateString();
                musaitlik(sablon.lblTarih.Text, sablon.label1.Text, sablon, sahaid);


            }
        }

        private void frmAnaEkran_Load(object sender, EventArgs e)
        {            
            //program ilk açıldığında labellere gün bilgilerini atar.
            bilgiGetir();


            label2.Text = DateTime.Today.ToShortDateString() + "\n" + DateTime.Today.ToString("dddd");
            label3.Text = DateTime.Today.AddDays(1).ToShortDateString() + "\n" + DateTime.Today.AddDays(1).ToString("dddd");
            label4.Text = DateTime.Today.AddDays(2).ToShortDateString() + "\n" + DateTime.Today.AddDays(2).ToString("dddd");
            label5.Text = DateTime.Today.AddDays(3).ToShortDateString() + "\n" + DateTime.Today.AddDays(3).ToString("dddd");
            label6.Text = DateTime.Today.AddDays(4).ToShortDateString() + "\n" + DateTime.Today.AddDays(4).ToString("dddd");
            label7.Text = DateTime.Today.AddDays(5).ToShortDateString() + "\n" + DateTime.Today.AddDays(5).ToString("dddd");
            label8.Text = DateTime.Today.AddDays(6).ToShortDateString() + "\n" + DateTime.Today.AddDays(6).ToString("dddd");
        }
    }
}
