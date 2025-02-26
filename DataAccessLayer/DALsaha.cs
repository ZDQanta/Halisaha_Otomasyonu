using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;
using System.Security.Cryptography;


namespace DataAccessLayer
{
    public class DALSaha
    {

        // Yeni saha kaydı ekleyen fonksiyondur.
        public static int sahaEkle(EntSaha p)
        {
            OleDbCommand cmd = new OleDbCommand("insert into Sahalar (sahaadi,sahaturu,cimturu,aciklama) values (@p1,@p2,@p3,@p5)", baglanti.conn);

            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }

            cmd.Parameters.AddWithValue("@p1", p.sahaadi);
            cmd.Parameters.AddWithValue("@p2", p.sahaturu);
            cmd.Parameters.AddWithValue("@p3", p.cimturu);
            cmd.Parameters.AddWithValue("@p5", p.aciklama);

            try
            {
                return cmd.ExecuteNonQuery(); // sorgu çalıştırılır
            }
            catch
            {
                return 0;
            }
        }
        // Verilen id'ye sahip saha kaydını güncelleyen fonksiyondur.
        public static int sahaGuncelle(EntSaha p)
        {
            OleDbCommand cmd2 = new OleDbCommand("update Sahalar set sahaadi = @p1,sahaturu = @p2,cimturu = @p3,aciklama = @p5 where id = @p4", baglanti.conn);

            if (cmd2.Connection.State != ConnectionState.Open)
            {
                cmd2.Connection.Open();
            }

            cmd2.Parameters.AddWithValue("@p1", p.sahaadi);
            cmd2.Parameters.AddWithValue("@p2", p.sahaturu);
            cmd2.Parameters.AddWithValue("@p3", p.cimturu);
            cmd2.Parameters.AddWithValue("@p5", p.aciklama);
            cmd2.Parameters.AddWithValue("@p4", p.id);
            return cmd2.ExecuteNonQuery();

        }
        // Tüm saha kayıtlarını liste olarak getiren fonksiyondur
        public static List<EntSaha> sahaListesiGetir()
        {
            List<EntSaha> sahaListesi = new List<EntSaha>();
            OleDbCommand cmd = new OleDbCommand("select id, sahaadi FROM Sahalar ", baglanti.conn);

            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }

            OleDbDataReader okuyucu = cmd.ExecuteReader();
            while (okuyucu.Read())
            {
                EntSaha saha = new EntSaha
                {
                    id = okuyucu.GetInt32(0),
                    sahaadi = okuyucu.GetString(1)
                };
                sahaListesi.Add(saha);
            }
            cmd.Connection.Close();
            return sahaListesi;
        }
        // Belirtilen ID'ye sahip saha bilgisini getirir.
        public static EntSaha sahaBilgiGetir(int id)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Sahalar WHERE id=@id", baglanti.conn);
            cmd.Parameters.AddWithValue("@id", id);

            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }

            OleDbDataReader okuyucu = cmd.ExecuteReader();
            EntSaha saha = null;
            if (okuyucu.Read())
            {
                saha = new EntSaha
                {
                    id = okuyucu.GetInt32(0),
                    sahaadi = okuyucu.GetString(1).ToUpper(),
                    sahaturu = okuyucu.GetString(2),
                    cimturu = okuyucu.GetString(3),
                    aciklama = okuyucu.GetString(4)
                };
            }
            cmd.Connection.Close();
            return saha;
        }
        // Belirtilen ID'ye sahip saha kaydını siler.
        public static int sahaSil(int id)
        {
            OleDbCommand cmd = new OleDbCommand("DELETE FROM Sahalar WHERE id=@id", baglanti.conn);
            cmd.Parameters.AddWithValue("@id", id);

            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }

            try
            {
                return cmd.ExecuteNonQuery(); // Silinen satır sayısı döner
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        // Sahalar tablosundaki tüm saha kayıtlarını liste olarak getirir.
        public static List<EntSaha> sahaListele()
        {
            List<EntSaha> sahaListesi = new List<EntSaha>();

            
               
                OleDbCommand komut = new OleDbCommand("SELECT * FROM Sahalar ORDER BY sahaadi ASC", baglanti.conn);

            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            OleDbDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    EntSaha saha = new EntSaha
                    {
                        id = Convert.ToInt32(oku["id"]),
                        sahaadi = oku["sahaadi"].ToString()
                    };

                    sahaListesi.Add(saha);
                }

                oku.Close();
                
            

            return sahaListesi;
        }

      
    }
}
