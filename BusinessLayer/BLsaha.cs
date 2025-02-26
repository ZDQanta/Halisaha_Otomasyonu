using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;



namespace BusinessLayer
{
    public class BLsaha
    {
        public static int BLsahaekle(EntSaha saha)
        {
            if (saha.sahaadi == null && saha.aciklama == null)
            {
                return -1;
            }
            else
            {
                return DALSaha.sahaEkle(saha);


            }
        }
        public static int BLsahaguncelle(EntSaha saha)
        {
            if (saha.sahaadi == null && saha.id != null && saha.aciklama == null)
            {
                return -1;
            }
            else
            {
                return DALSaha.sahaGuncelle(saha);


            }
        }
        public static int BLsahaSil(int id)
        {
            if (id <= 0)
            {
                return -1; // Geçersiz ID
            }
            else
            {
                return DALSaha.sahaSil(id);
            }
        }
        public static List<EntSaha> sahaListele()
        {
            return DALSaha.sahaListele(); // Veritabanından sahaları getir
        }
       
             

    }
}
