using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ClientGui;
using ClientLibrary;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientTCP client = new ClientTCP(IPAddress.Parse("127.0.0.1"), 8000);
            client.Start();
        }
    }
}
