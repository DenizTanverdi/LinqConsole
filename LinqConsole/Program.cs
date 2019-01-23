using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            #region diziLinq
            var dizi = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
              //1.Yöntem
              var tek = from tk in dizi where tk % 2 == 1 select tk;
              //2.Yöntem
              var tekler = dizi.Where(I => I % 2 == 1);
            /*  foreach (var item in tekler)
              {
                  Console.WriteLine(item);

              }*/
            #endregion
            #region ListLinq
            List<Ogrenci> Ogrenci = new List<Ogrenci>();
            Ogrenci o = new Ogrenci() { Adi = "deniz", Soyadi = " ", no = 1 };
            Ogrenci.Add(o);
             o = new Ogrenci() { Adi = "d", Soyadi = "eniz", no = 2 };
            Ogrenci.Add(o);
            o = new Ogrenci() { Adi = "de", Soyadi = "niz", no = 3 };
            Ogrenci.Add(o);
            o = new Ogrenci() { Adi = "den", Soyadi = "iz", no = 4 };
            Ogrenci.Add(o);
            //  var query = from og in Ogrenci select new { og.Adi, og.Soyadi };
            /*  foreach (var item in query)
              {
                  Console.WriteLine(item.Adi+" "+item.Soyadi);

              }*/
            #endregion
            #region DataTableLinq
            DataTable tbl = new DataTable();
            tbl = getCustomer();
            var query = from t in tbl.AsEnumerable() select  t;
            foreach (var item in query)
            {
                Console.WriteLine(item.Field<string>("CompanyName"));
            }
            #endregion
            Console.ReadLine();
        }
        public static DataTable getCustomer()
        {
            DataTable tbl = new DataTable();
            string cnstr = "Data Source=SEM-BILGISAYAR;Initial Catalog=NORTHWND2;User ID=test2;Password=test2";
            SqlConnection con = new SqlConnection(cnstr);
            SqlCommand cmd = new SqlCommand("Select * from Customers", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            tbl.Load(rdr);
            return tbl;

        }
        class Ogrenci
        {
            public string Adi { get; set; }
            public string Soyadi { get; set; }
            public int no { get; set; }

        }
    }
}
