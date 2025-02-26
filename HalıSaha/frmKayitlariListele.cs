using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;

namespace HalıSaha
{
    public partial class frmKayitlariListele : Form
    {
        public frmKayitlariListele()
        {
            InitializeComponent();
        }
        private BindingSource bs = new BindingSource(); // Form seviyesinde tanımlandı
        private List<EntKayit> kayitlar = new List<EntKayit>(); // Veri kaynağı

        private void frmKayitlariListele_Load(object sender, EventArgs e)
        {
            // Arka plan rengi
            dataGridView1.BackgroundColor = Color.LightGray;

            // Satırların renk ayarları
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;

            // Başlıkların stil ayarları
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);

            // Hücre kenarlıkları
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            try
            {
                // İş katmanından kayıtları al
                kayitlar = BLkayit.kayitlariListele();

                // BindingSource ile bağlama
                bs.DataSource = kayitlar;
                dataGridView1.DataSource = bs;

                dataGridView1.Columns["id"].HeaderText = "ID";
                dataGridView1.Columns["sahaid"].HeaderText = "SAHA";
                dataGridView1.Columns["adsoyad"].HeaderText = "Ad Soyad";
                dataGridView1.Columns["mail"].HeaderText = "E-Posta";
                dataGridView1.Columns["tc"].HeaderText = "T.C. Kimlik No";
                dataGridView1.Columns["fiyat"].HeaderText = "Fiyat";
                dataGridView1.Columns["telno"].HeaderText = "Telefon Numarası";
                dataGridView1.Columns["randevu_tarih"].HeaderText = "Randevu Tarihi";
                dataGridView1.Columns["randevu_saati"].HeaderText = "Randevu Saati";
                dataGridView1.Columns["kayit_Tarih"].HeaderText = "Kayıt Tarihi";

                // Sadece düzenlenebilir sütunları açık bırak
                dataGridView1.Columns["adsoyad"].ReadOnly = false;
                dataGridView1.Columns["mail"].ReadOnly = false;
                dataGridView1.Columns["tc"].ReadOnly = false;
                dataGridView1.Columns["fiyat"].ReadOnly = false;
                dataGridView1.Columns["telno"].ReadOnly = false;

                // Diğer sütunları salt okunur yap
                dataGridView1.Columns["sahaid"].ReadOnly = true;
                dataGridView1.Columns["id"].ReadOnly = true;
                dataGridView1.Columns["randevu_tarih"].ReadOnly = true;
                dataGridView1.Columns["randevu_saati"].ReadOnly = true;
                dataGridView1.Columns["kayit_Tarih"].ReadOnly = true;

                dataGridView1.Columns["adsoyad"].Width = 200; // Ad Soyad sütunu genişliği
                dataGridView1.Columns["mail"].Width = 200; // E-Posta sütunu genişliği

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    // Düzenlenen satırı al
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    // Sadece izin verilen sütunları güncelle
                    EntKayit kayit = new EntKayit
                    {
                        id = Convert.ToInt32(row.Cells["id"].Value),
                        adsoyad = row.Cells["adsoyad"].Value?.ToString(),
                        mail = row.Cells["mail"].Value?.ToString(),
                        tc = row.Cells["tc"].Value?.ToString(),
                        fiyat = row.Cells["fiyat"].Value?.ToString(),
                        telno = row.Cells["telno"].Value?.ToString()
                    };

                    // Güncelleme işlemi
                    int result = BLkayit.BLkayitGuncelle(kayit);

                    // Eğer güncelleme başarılıysa, veri kaynağını yeniden yükleyin
                    if (result > 0)
                    {
                        MessageBox.Show("Kayıt başarıyla güncellendi.");

                        // Güncel kayıtlardan veri çek ve BindingSource'a ata
                        kayitlar = BLkayit.kayitlariListele();
                        bs.DataSource = kayitlar;  // Yeni veri kaynağını BindingSource'a ata
                        dataGridView1.DataSource = bs; // DataGridView'e yeni kaynağı atama
                    }
                    else
                    {
                        MessageBox.Show("Kayıt güncellenirken bir hata oluştu.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string seciliSahaId = dataGridView1.Rows[e.RowIndex].Cells["sahaid"].Value.ToString();
                MessageBox.Show($"Seçilen saha ID: {seciliSahaId}");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Arama metni
            string filterText = textBox1.Text.ToLower();

            // BindingSource üzerindeki veriyi filtrele
            bs.DataSource = kayitlar
                .Where(k => k.adsoyad.ToLower().Contains(filterText))
                .ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExportToPdf()
        {
            // Kullanıcının masaüstü yolunu alıyoruz
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // PDF dosyasının tam yolunu belirliyoruz
            string pdfFilePath = Path.Combine(desktopPath, "output.pdf");

            // PDF dokümanı oluşturuyoruz
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Filtrelenmiş Veri";

            // Sayfa oluşturuyoruz
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Font ve stil
            XFont font = new XFont("Arial", 8, XFontStyle.Regular);

            // Başlıklar (İstenmeyen sütunları atlıyoruz: ID, SahaID, Kayıt Tarihi)
            double yPosition = 15;
            double xPosition = 15;

            // DataGridView'deki tüm sütunları kontrol ediyoruz
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                // Eğer sütun adı ID, SahaID veya Kayıt Tarihi ise atlıyoruz
                if (column.HeaderText == "ID" || column.HeaderText == "SAHA" || column.HeaderText == "Kayıt Tarihi")
                    continue;

                double columnWidth = 110; // Varsayılan genişlik
                if (column.HeaderText == "E-Posta")
                {
                    columnWidth = 150; // **Mail sütununa özel genişlik ayarı**
                }
                else if (column.HeaderText == "Randevu Tarihi" ||
                column.HeaderText == "Randevu Saati" ||
                column.HeaderText == "Fiyat")
                {
                    columnWidth = 70; // **Randevu Tarihi, Saati ve Fiyat için genişlik**
                }
                // Başlıkları yazıyoruz
                gfx.DrawString(column.HeaderText, font, XBrushes.Black, xPosition, yPosition);
                xPosition += 110; // Her başlık için genişlik
            }

            yPosition += 15; // Başlıkların altına biraz boşluk bırakıyoruz
            xPosition = 15; // X pozisyonunu sıfırlıyoruz

            // Verileri (sadece istenen sütunlar) tablo şeklinde çizelim
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Visible) // Yalnızca görünür satırlar
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        // Eğer sütun adı ID, SahaID veya Kayıt Tarihi ise atlıyoruz
                        if (dataGridView1.Columns[cell.ColumnIndex].HeaderText == "ID" ||
                            dataGridView1.Columns[cell.ColumnIndex].HeaderText == "SAHA" ||
                            dataGridView1.Columns[cell.ColumnIndex].HeaderText == "Kayıt Tarihi")
                            continue;

                        double columnWidth = 110; // 60Varsayılan genişlik
                        if (dataGridView1.Columns[cell.ColumnIndex].HeaderText == "E-Posta")
                        {
                            columnWidth = 150; // **Mail sütununa özel genişlik ayarı**
                            xPosition += 10;
                        }
                        else if (dataGridView1.Columns[cell.ColumnIndex].HeaderText == "Randevu Tarihi" ||
                        dataGridView1.Columns[cell.ColumnIndex].HeaderText == "Randevu Saati" ||
                        dataGridView1.Columns[cell.ColumnIndex].HeaderText == "Fiyat")
                        {
                            columnWidth = 70; // **Randevu Tarihi, Saati ve Fiyat için genişlik ayarı**
                        }
                        // Hücre verilerini yazıyoruz
                        gfx.DrawString(cell.Value?.ToString() ?? "", font, XBrushes.Black, xPosition, yPosition);
                        xPosition += 110; // Her hücre için genişlik
                    }
                    yPosition += 20; // Sonraki satıra geçiş
                    xPosition = 10; // X pozisyonunu sıfırlıyoruz
                }
            }

            // PDF dosyasını kaydediyoruz
            document.Save(pdfFilePath);
            MessageBox.Show($"PDF dosyası masaüstüne kaydedildi: {pdfFilePath}");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExportToPdf();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string seciliSahaId = dataGridView1.Rows[e.RowIndex].Cells["sahaid"].Value.ToString();
                MessageBox.Show($"Seçilen saha ID: {seciliSahaId}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçili satırı al
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int selectedId = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["id"].Value);

                // Silme işlemini onayla
                DialogResult dialogResult = MessageBox.Show("Bu kaydı silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    // Veritabanından silme işlemi
                    int result = BLkayit.kayitSil(selectedId);
                    if (result > 0)
                    {
                        // DataGridView'den kaldır
                        dataGridView1.Rows.RemoveAt(selectedRowIndex);
                        MessageBox.Show("Kayıt başarıyla silindi.");
                    }
                    else
                    {
                        MessageBox.Show("Kayıt silinemedi.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir kayıt seçin.");
            }
        }
    }
}
