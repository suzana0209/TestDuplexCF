using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RE
{
    public class UpisiCallback1 : IUpisiCallback1
    {
        public void OnCallback1(string message)
        {
            Console.WriteLine("Message from server, {0}.", message);
        }
    }
}
