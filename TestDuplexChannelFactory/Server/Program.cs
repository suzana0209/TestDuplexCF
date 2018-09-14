using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost svc = new ServiceHost(typeof(Procitaj));
            ServiceHost serviceHost = new ServiceHost(typeof(Upisi));
            ServiceHost serviceHost1 = new ServiceHost(typeof(InsertIntoTable));


            svc.AddServiceEndpoint(typeof(IProcitaj), new NetTcpBinding(), "net.tcp://localhost:10100/IProcitaj");
            serviceHost.AddServiceEndpoint(typeof(IUpisi), new NetTcpBinding(), "net.tcp://localhost:10101/IUpisi");
            serviceHost1.AddServiceEndpoint(typeof(IInsert), new NetTcpBinding(), "net.tcp://localhost:10102/IInsert");


            svc.Open();
            serviceHost.Open();
            serviceHost1.Open();

            Console.ReadKey();
            serviceHost.Close();
            svc.Close();
            serviceHost1.Close();

            List<int> retVal = new List<int>() { 7, 7, 7, 7, 6, 6, 5, 4, 4, 2, 2, 2, 1, 1, 1, 1 };

            int i = 0;
            while (i < retVal.Count - 1)
            {
                if (retVal[i] == retVal[i + 1])
                    retVal.RemoveAt(i);
                else
                    i++;
            }



            Console.ReadKey();
        }

        public static  void ispis()
        {

        }
    }
}
