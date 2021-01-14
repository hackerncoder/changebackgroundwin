using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace tester
{
    class Program
    {
        static string urlBase = "http://5.175.25.50/ChangeBackgroundWin/update/";
        static void Main(string[] args)
        {
            WebRequest wr2 = WebRequest.Create(urlBase + "testversions.txt");
            WebResponse ws2 = wr2.GetResponse();
            StreamReader sr2 = new StreamReader(ws2.GetResponseStream());

            string newversion2 = sr2.ReadToEnd();
            string[] newversion2Arr = newversion2.Split('\n');

            Console.WriteLine(newversion2);
            Console.WriteLine(newversion2Arr[1]);
            Console.ReadKey();
        }
    }
}
