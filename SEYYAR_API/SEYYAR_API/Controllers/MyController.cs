using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace SEYYAR_API.Controllers
{
    [Route("api")]
    [ApiController]
    public class MyController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public MyController(IConfiguration config)
        {
            this.configuration = config;
        }


        [HttpGet("seyyarOlustur/{isim}/{sifre}")]
        public String seyyarOlustur(String isim, String sifre)
        {
            string connectionstring = configuration.GetConnectionString("MyConnection");
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();


            String kontrolederekEkleComent = "IF NOT EXISTS ( SELECT 1 FROM " + "[" + "SEYYAR_SATICILAR" + "]" + " WHERE ISIM = @isim ) BEGIN INSERT INTO " + "[" + "SEYYAR_SATICILAR" + "]" + " (ISIM,SIFRE)  VALUES (@isim,@sifre) END";

            SqlCommand coment = new SqlCommand(kontrolederekEkleComent, connection);

            coment.Parameters.Add("@isim", System.Data.SqlDbType.VarChar);
            coment.Parameters["@isim"].Value = isim;

            coment.Parameters.Add("@sifre", System.Data.SqlDbType.VarChar);
            coment.Parameters["@sifre"].Value = sifre;
            coment.ExecuteNonQuery();

            connection.Close();
            return "SeyyarOlusturuldu";
        }

        [HttpGet("seyyarGirisYap/{isim}/{sifre}")]
        public String seyyarGirisYap(String isim, String sifre)
        {
            string connectionstring = configuration.GetConnectionString("MyConnection");
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();

            SqlCommand com = new SqlCommand("SELECT ISIM,SIFRE FROM [SEYYAR_SATICILAR] WHERE ISIM=@isim AND SIFRE=@sifre", connection);
            com.Parameters.Add("@isim", System.Data.SqlDbType.VarChar);
            com.Parameters["@isim"].Value = isim;
            com.Parameters.Add("@sifre", System.Data.SqlDbType.VarChar);
            com.Parameters["@sifre"].Value = sifre;

            SqlDataReader reader = com.ExecuteReader();


            if (reader.HasRows)
            {

                reader.Close(); ;
                return "match";

            }
            reader.Close();
            connection.Close();
            return "dontmatch";
        }
        [HttpGet("seyyarUrunEkle/{isim}/{urun}")]
        public String seyyarUrunEkle(String isim, String urun)
        {
            string connectionstring = configuration.GetConnectionString("MyConnection");
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();

            String komut = "INSERT INTO " + "[" + "URUNLER" + "]" + " (ISIM,URUNLER) VALUES (@isim,@urun)";

            SqlCommand com = new SqlCommand(komut, connection);

            com.Parameters.Add("@isim", System.Data.SqlDbType.VarChar);
            com.Parameters["@isim"].Value = isim;

            com.Parameters.Add("@urun", System.Data.SqlDbType.VarChar);
            com.Parameters["@urun"].Value = urun;

            com.ExecuteNonQuery();
            connection.Close();
            return "Urun Olusturuldu";
        }
        [HttpGet("seyyarUrunleriCek/{isim}")]
        public List<String> seyyarUrunleriCek(String isim)
        {
            List<String> mylist = new List<string>();

            string connectionstring = configuration.GetConnectionString("MyConnection");
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();

            String komut = "SELECT * from " + "[" + "URUNLER" + "] WHERE ISIM=@isim";

            SqlCommand com = new SqlCommand(komut, connection);
            com.Parameters.Add("@isim", System.Data.SqlDbType.VarChar);
            com.Parameters["@isim"].Value = isim;

            //  var donenDeger = com.ExecuteScalar();

            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                mylist.Add(reader["URUNLER"].ToString());
            }

            reader.Close();
            connection.Close();
            return mylist;
        }
        [HttpGet("seyyarKonumGuncelle/{isim}/{Lat}/{Long}")]
        public String seyyarKonumGuncelle(String isim,Double Lat,Double Long)
        {
            string connectionstring = configuration.GetConnectionString("MyConnection");
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();

            String komut = "UPDATE " + "[" + "SEYYAR_SATICILAR" + "]" + " SET LAT=@Lat , LONG=@Long WHERE ISIM=@isim";

            SqlCommand com = new SqlCommand(komut, connection);


            com.Parameters.Add("@isim", System.Data.SqlDbType.VarChar);
            com.Parameters["@isim"].Value = isim;

            com.Parameters.Add("@Lat", System.Data.SqlDbType.Float);
            com.Parameters["@Lat"].Value = Lat;

            com.Parameters.Add("@Long", System.Data.SqlDbType.Float);
            com.Parameters["@Long"].Value = Long;

            com.ExecuteNonQuery();
            connection.Close();
            return "Konum Guncellendi";
        }
        [HttpGet("urunSil/{isim}/{urun}")]
        public String urunSıl(String isim,String urun)
        {
            string connectionstring = configuration.GetConnectionString("MyConnection");
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            // DELETE FROM URUNLER WHERE ISIM='manav' AND URUNLER='cilek'

            String komut = "DELETE FROM " + "[" + "URUNLER" + "]" + " WHERE ISIM=@isim AND URUNLER=@urun";

            SqlCommand com = new SqlCommand(komut, connection);

            com.Parameters.Add("@isim", System.Data.SqlDbType.VarChar);
            com.Parameters["@isim"].Value = isim;

            com.Parameters.Add("@urun", System.Data.SqlDbType.VarChar);
            com.Parameters["@urun"].Value = urun;

            com.ExecuteNonQuery();
            connection.Close();
            return "Urun Silindi";
        }
        [HttpGet("seyyarIsimleriCek")]
        public List<String> seyyarIsimleriCek()
        {
            List<String> mylist = new List<string>();

            string connectionstring = configuration.GetConnectionString("MyConnection");
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();

            String komut = "SELECT ISIM from " + "[" + "SEYYAR_SATICILAR" + "] WHERE LAT IS NOT NULL";

            SqlCommand com = new SqlCommand(komut, connection);
           

            //  var donenDeger = com.ExecuteScalar();

            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                mylist.Add(reader["ISIM"].ToString());
            }

            reader.Close();
            connection.Close();
            return mylist;
        }
        [HttpGet("seyyarKonumlari/{isim}")]
        public List<Double> seyyarKonumlari(String isim)
        {
            List<Double> mylist = new List<Double>();

            string connectionstring = configuration.GetConnectionString("MyConnection");
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();

            String komut = "SELECT LAT , LONG from " + "[" + "SEYYAR_SATICILAR" + "] WHERE ISIM=@isim";

            SqlCommand com = new SqlCommand(komut, connection);
            com.Parameters.Add("@isim", System.Data.SqlDbType.VarChar);
            com.Parameters["@isim"].Value = isim;

            //  var donenDeger = com.ExecuteScalar();

            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                mylist.Add(Double.Parse(reader["LAT"].ToString()));
                mylist.Add(Double.Parse(reader["LONG"].ToString()));
            }

            reader.Close();
            connection.Close();
            return mylist;
        }
        [HttpGet("seyyarCagir/{isim}/{Lat}/{Long}")]
        public String SeyyarCagir(String isim,Double Lat,Double Long)
        {
            string connectionstring = configuration.GetConnectionString("MyConnection");
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            //INSERT CAGIRMALAR (ISIM,LAT,LONG) VALUES('DENEME1',54.78,56.47)
            String komut = "INSERT " + "[" + "CAGIRMALAR" + "]" + " (ISIM,LAT,LONG) VALUES(@isim,@Lat,@Long)";

            SqlCommand com = new SqlCommand(komut, connection);


            com.Parameters.Add("@isim", System.Data.SqlDbType.VarChar);
            com.Parameters["@isim"].Value = isim;

            com.Parameters.Add("@Lat", System.Data.SqlDbType.Float);
            com.Parameters["@Lat"].Value = Lat;

            com.Parameters.Add("@Long", System.Data.SqlDbType.Float);
            com.Parameters["@Long"].Value = Long;

            com.ExecuteNonQuery();
            connection.Close();
            return "Seyyar Cagirildi";
        }
        [HttpGet("seyyariCagiranlar/{isim}")]
        public List<Double> seyyariCagiranlarinKonumlari(String isim)
        {
            List<Double> mylist = new List<Double>();

            string connectionstring = configuration.GetConnectionString("MyConnection");
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();

            String komut = "SELECT LAT , LONG from " + "[" + "CAGIRMALAR" + "] WHERE ISIM=@isim";

            SqlCommand com = new SqlCommand(komut, connection);
            com.Parameters.Add("@isim", System.Data.SqlDbType.VarChar);
            com.Parameters["@isim"].Value = isim;

            //  var donenDeger = com.ExecuteScalar();

            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                mylist.Add(Double.Parse(reader["LAT"].ToString()));
                mylist.Add(Double.Parse(reader["LONG"].ToString()));
            }

            reader.Close();
            connection.Close();
            return mylist;
        }
    }
}