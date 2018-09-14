using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace RE
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> s = new List<string>();

            //string s = "INSERT INTO UneseneVrednosti(IDGeoPodrucja, VremeMerenja, Vrednost) VALUES ('DO', '2018-6-1 00:30:00.000', 234)";


            s.Add("INSERT INTO UneseneVrednosti(IDGeoPodrucja, VremeMerenja, Vrednost) VALUES ('DO', '2018-6-1 00:36:00.000', 234)");
            s.Add("INSERT INTO UneseneVrednosti(IDGeoPodrucja, VremeMerenja, Vrednost) VALUES ('DO', '2018-6-1 00:46:00.000', 214)");

            DuplexSample(s);

            Console.ReadLine();
        }

        private static void DuplexSample(List<string> l)
        {

            //"INSERT INTO UneseneVrednosti " +
            //"(IDGeoPodrucja, VremeMerenja, Vrednost) " +
            //"VALUES ('" + idGeoPodrucja + "', '" + datum + "', " + _unesenaPotrosnja + ")";

            var binding = new NetTcpBinding();
            var address = new EndpointAddress("net.tcp://localhost:10102/IInsert");

            var clientCallback = new UpisiCallback1();
            var context = new InstanceContext(clientCallback);

            var factory = new DuplexChannelFactory<IInsert>(clientCallback, binding, address);

            IInsert messageChanel = factory.CreateChannel();

            //foreach (var item in l)
            //{
                Task.Run(() => messageChanel.InsertInto(l));
           // }

           
        }
    }
}
