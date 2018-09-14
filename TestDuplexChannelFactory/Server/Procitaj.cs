using Contract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{


    public class Procitaj : IProcitaj
    {
        public  SqlConnection conn = new SqlConnection(@"Server=DESKTOP-JJ3CM3A;  Database=ResidentExecutor_DB;  Integrated Security=True");
        //public static string[] podaciIzFajla = File.ReadAllLines(@"../../../PodaciSaMainWindow.txt");
        public  SqlCommand cmd = null;

        public List<PodaciIzBaze> ProcitajIzBaze()
        {
            List<PodaciIzBaze> podaci = new List<PodaciIzBaze>();
            conn.Open();

            //"SELECT * FROM UneseneVrednosti WHERE " +  "VremeMerenja = '" + datum + "' AND IDGeoPodrucja = '" + idGeoPodrucja + "'"

            string selectFromUneseneVrednosti = "SELECT * FROM UneseneVrednosti";

            SqlCommand cmd = new SqlCommand(selectFromUneseneVrednosti, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                podaci.Add(new PodaciIzBaze((string)reader.GetSqlString(0), reader.GetSqlDateTime(1), (float)reader.GetSqlDouble(2)));
            }
            reader.Close();
            conn.Close();

            return podaci;
        }
    }
}
