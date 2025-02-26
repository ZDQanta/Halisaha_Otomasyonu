using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.ComponentModel.Design;
using System.Data.SqlClient;



namespace DataAccessLayer
{
    public class DALkayit
    {
        //Kayıtlar tablosuna kayıt ekleyen fonksiyon
        public static int kayitEkle(EntKayit p)
        {
            //Kayıtlar Tablosunun icine kayıt ekleyen komut
            OleDbCommand cmd = new OleDbCommand("insert into Kayıtlar (tc,adsoyad,mail,randevu_tarihi,randevu_saati,sahaid,fiyat,telno,kayit_tarih) " + "   values (@p1,@p2,@p3,@p5,@p6,@p7,@p8,@p9,@p10)", baglanti.conn);

            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }

            cmd.Parameters.AddWithValue("@p1", p.tc);
            cmd.Parameters.AddWithValue("@p2", p.adsoyad);
            cmd.Parameters.AddWithValue("@p3", p.mail);
            cmd.Parameters.AddWithValue("@p5", p.randevu_tarih);
            cmd.Parameters.AddWithValue("@p6", p.randevu_saati);
            cmd.Parameters.AddWithValue("@p7", p.sahaid);
            cmd.Parameters.AddWithValue("@p8", p.fiyat);
            cmd.Parameters.AddWithValue("@p9", p.telno);
            cmd.Parameters.AddWithValue("@p10", p.kayit_Tarih);



            try
            {
                return cmd.ExecuteNonQuery(); // sorgu çalıştırılır
            }
            catch
            {
                return 0;
            }
        }

        //randevu ve randevu saati verilen tüm kayıtların çekildiği fonksiyondur.
        public static List<EntKayit> kayitlariGetir(string tarih, string saat)
        {
            List<EntKayit> kayitListesi = new List<EntKayit>();
            //Kayıtlar tablosundan randevu tarihi ve randevu saatleri verilen kayıtın çekildiği komut
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Kayıtlar WHERE randevu_tarihi = @tarih AND randevu_saati = @saat", baglanti.conn);
            try
            {
                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }

                cmd.Parameters.AddWithValue("@tarih", tarih);
                cmd.Parameters.AddWithValue("@saat", saat);

                OleDbDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    EntKayit kayit = new EntKayit();
                    kayit.id = int.Parse(dr["id"].ToString());
                    kayit.tc = dr["tc"].ToString();
                    kayit.adsoyad = dr["adsoyad"].ToString();
                    kayit.mail = dr["mail"].ToString();
                    kayit.randevu_tarih = dr["randevu_tarihi"].ToString();
                    kayit.randevu_saati = dr["randevu_saati"].ToString();
                    kayit.sahaid = dr["sahaid"].ToString();
                    kayit.fiyat = dr["fiyat"].ToString();
                    kayit.telno = dr["telno"].ToString();
                    kayit.kayit_Tarih = dr["kayit_tarih"].ToString();
                    kayitListesi.Add(kayit);
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                // Hataları burada yakalayın
                Console.WriteLine("Hata: " + ex.Message);
            }
            finally
            {
                // Bağlantıyı mutlaka kapatın
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
            }


            return kayitListesi;
        }

        //Tarih ve sahaid bilgileri verilen tüm kayıtların çekildiği fonksiyondur.
        public static List<EntKayit> grafikBilgileriGetir(string tarih, string sahaid)
        {
            List<EntKayit> kayitListesi = new List<EntKayit>();
            //Kayıt tablosundan tarih ve sahaid  bilgileri verilen kayıtları getirilen sorgu.
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Kayıtlar WHERE randevu_tarihi = @tarih AND sahaid = @sahaid", baglanti.conn);
            try
            {
                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }
                //arama parametrelerine fonksiyon parametrelerinin atandığı komut satırları
                cmd.Parameters.AddWithValue("@tarih", tarih);
                cmd.Parameters.AddWithValue("@sahaid", sahaid);

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EntKayit kayit = new EntKayit();
                    kayit.id = int.Parse(reader["id"].ToString());
                    kayit.tc = reader["tc"].ToString();
                    kayit.adsoyad = reader["adsoyad"].ToString();
                    kayit.mail = reader["mail"].ToString();
                    kayit.randevu_tarih = reader["randevu_tarihi"].ToString();
                    kayit.randevu_saati = reader["randevu_saati"].ToString();
                    kayit.sahaid = reader["sahaid"].ToString();
                    kayit.fiyat = reader["fiyat"].ToString();
                    kayit.telno = reader["telno"].ToString();
                    kayit.kayit_Tarih = reader["kayit_tarih"].ToString();
                    kayitListesi.Add(kayit);
                }

            }
            catch (Exception ex)
            {
                // Hataları burada yakalayın
                Console.WriteLine("Hata: " + ex.Message);
            }
            finally
            {
                // Bağlantıyı mutlaka kapatın
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
            }
            return kayitListesi;
        }

        //Kayıtlar tablosundan saat,tarih ve sahaid bilgileri aynı olan kayıtrın çekildiği fonksiyondur.
        public static EntKayit mevcutkayit(string tarih, string saat, string sahaid)
        {
            EntKayit mevcutkayit = new EntKayit();

            //parametrede verilen değerleri karşılayan kayıt bilgisini çeken sorgu.
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Kayıtlar WHERE randevu_tarihi = @tarih AND randevu_saati = @saat AND sahaid = @sahaid", baglanti.conn);
            try
            {
                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }

                //arama parametrelerine fonksiyon parametrelerinin atandığı komut satırları

                cmd.Parameters.AddWithValue("@tarih", tarih);
                cmd.Parameters.AddWithValue("@saat", saat);
                cmd.Parameters.AddWithValue("@sahaid", sahaid);

                OleDbDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    mevcutkayit.id = Convert.ToInt16(dr["id"]);
                    mevcutkayit.sahaid = dr["sahaid"].ToString();
                    mevcutkayit.mail = dr["mail"].ToString();
                    mevcutkayit.tc = dr["tc"].ToString();
                    mevcutkayit.adsoyad = dr["adsoyad"].ToString();
                    mevcutkayit.randevu_saati = dr["randevu_saati"].ToString();
                    mevcutkayit.randevu_tarih = dr["randevu_tarihi"].ToString();
                    mevcutkayit.fiyat = dr["fiyat"].ToString();
                    mevcutkayit.telno = dr["telno"].ToString();
                    mevcutkayit.kayit_Tarih = dr["kayit_tarihi"].ToString();

                }

                dr.Close();
            }
            catch (Exception ex)
            {
                // Hataları burada yakalayın
                Console.WriteLine("Hata: " + ex.Message);
            }
            finally
            {
                // Bağlantıyı mutlaka kapatın
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
            }

            return mevcutkayit;
        }

        //Tüm kayıtların getirildiği fonksiyon
        public static List<EntKayit> kayitlariListele()
        {
            List<EntKayit> kayitlar = new List<EntKayit>();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Kayıtlar", baglanti.conn);

            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }

            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                EntKayit k = new EntKayit
                {
                    id = int.Parse(dr["id"].ToString()),
                    tc = dr["tc"].ToString(),
                    adsoyad = dr["adsoyad"].ToString(),
                    mail = dr["mail"].ToString(),
                    randevu_tarih = dr["randevu_tarihi"].ToString(),
                    randevu_saati = dr["randevu_saati"].ToString(),
                    sahaid = dr["sahaid"].ToString(),
                    fiyat = dr["fiyat"].ToString(),
                    telno = dr["telno"].ToString(),
                    kayit_Tarih = dr["kayit_tarih"].ToString()
                };
                kayitlar.Add(k);
            }

            dr.Close();
            cmd.Connection.Close();
            return kayitlar;
        }

        //kayıtların güncellendiği fonksiyon
        public static int kayitGuncelle(EntKayit p)
        {
            OleDbCommand cmd = new OleDbCommand("UPDATE Kayıtlar SET  adsoyad = @p2, mail = @p3, tc = @p4, fiyat = @p5, telno = @p6 WHERE id = @p7",
        baglanti.conn);

            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }

            cmd.Parameters.AddWithValue("@p2", p.adsoyad);
            cmd.Parameters.AddWithValue("@p3", p.mail);
            cmd.Parameters.AddWithValue("@p4", p.tc);
            cmd.Parameters.AddWithValue("@p5", p.fiyat);
            cmd.Parameters.AddWithValue("@p6", p.telno);
            cmd.Parameters.AddWithValue("@p7", p.id);

            try
            {
                return cmd.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        //id bilgisi verilen kayıtın silindiği fonksiyondur.
        public static int kayitSil(int id)
        {
            using (OleDbCommand cmd = new OleDbCommand("DELETE FROM Kayıtlar WHERE id = @id", baglanti.conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    baglanti.conn.Open();
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata: " + ex.Message);
                    return 0;
                }
                finally
                {
                    baglanti.conn.Close();
                }
            }
        }

       


    }
}
