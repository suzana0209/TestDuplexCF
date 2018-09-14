using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            

            IProcitaj proxy = new ChannelFactory<IProcitaj>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:10100/IProcitaj")).CreateChannel();
            //IProcitaj proxy = new DuplexChannelFactory<IProcitaj>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:10100/IProcitaj")).CreateChannel()

            foreach (var item in proxy.ProcitajIzBaze())
            {
                Console.WriteLine(item);
            }

            DuplexSample();

            Console.ReadLine();
        }

        private  static void DuplexSample()
        {

            //"INSERT INTO UneseneVrednosti " +
            //"(IDGeoPodrucja, VremeMerenja, Vrednost) " +
            //"VALUES ('" + idGeoPodrucja + "', '" + datum + "', " + _unesenaPotrosnja + ")";

            string s = "INSERT INTO UneseneVrednosti(IDGeoPodrucja, VremeMerenja, Vrednost) VALUES ('DO', '2018-6-1 00:30:00.000', 234)";
            var binding = new NetTcpBinding();
            var address = new EndpointAddress("net.tcp://localhost:10101/IUpisi");

            var clientCallback = new UpisiCallback();
            var context = new InstanceContext(clientCallback);

            var factory = new DuplexChannelFactory<IUpisi>(clientCallback, binding, address);

            IUpisi messageChanel = factory.CreateChannel();

             Task.Run(() => messageChanel.PosaljiInsert(s));
        }
    }
}

