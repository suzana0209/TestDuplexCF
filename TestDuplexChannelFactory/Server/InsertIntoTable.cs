using Contract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class InsertIntoTable : IInsert
    {
        public SqlConnection conn = new SqlConnection(@"Server=DESKTOP-JJ3CM3A;  Database=ResidentExecutor_DB;  Integrated Security=True");
        //public static string[] podaciIzFajla = File.ReadAllLines(@"../../../PodaciSaMainWindow.txt");
        public SqlCommand cmd = null;

        public void InsertInto(List<string> l)
        {
            foreach (var item in l)
            {
                using (cmd = new SqlCommand(item, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        private async void TaskCallback(object callback)
        {
            IUpisiCallback1 messageCallback = callback as IUpisiCallback1;

            for (int i = 0; i < 10; i++)
            {
                messageCallback.OnCallback1("message " + i.ToString());
                await Task.Delay(1000);
            }
        }
    }
}
