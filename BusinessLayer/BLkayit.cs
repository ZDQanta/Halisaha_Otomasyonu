using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer
{
    public class BLkayit
    {
        public static int BLkayitekle(EntKayit kayit)
        {
            if (kayit.tc == null && kayit.adsoyad == null && kayit.mail == null && kayit.randevu_saati == null && kayit.randevu_tarih == null && kayit.sahaid == null && kayit.telno == null)
            {
                return -1;
            }
            else
            {
                return DALkayit.kayitEkle(kayit);

            }
        }

        public static List<EntKayit> kayitlariGetir(string tarih, string saat)
        {
            return DALkayit.kayitlariGetir(tarih, saat); // Veritabanından çekilen kayıtlar iş katmanına döndürülür
        }

        public static EntKayit mevuctkayit(string tarih, string saat, string sahaid)
        {
            return DALkayit.mevcutkayit(tarih, saat, sahaid); // Veritabanından çekilen kayıtlar iş katmanına döndürülür
        }

        public static List<EntKayit> grafilBilgiGetir(string tarih, string sahaid)
        {
            return DALkayit.grafikBilgileriGetir(tarih, sahaid); // Veritabanından çekilen kayıtlar iş katmanına döndürülür
        }

        public static List<EntKayit> kayitlariListele()
        {
            return DALkayit.kayitlariListele();
        }
        public static int BLkayitGuncelle(EntKayit kayit)
        {
            // Güncelleme işlemi için temel doğrulamalar
            if (kayit.tc == null || kayit.adsoyad == null || kayit.mail == null || kayit.id <= 0)
            {
                return -1; // Eksik veya hatalı veri
            }
            else
            {
                return DALkayit.kayitGuncelle(kayit);
            }
        }

        public static string SahaAdiGetir(string sahaid)
        {
            throw new NotImplementedException();
        }

        public static int kayitSil(int id)
        {
            return DALkayit.kayitSil(id);
        }

        // 7 Günlük Randevuları Alacak Fonksiyon
       

    }
}
