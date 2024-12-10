using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetAllEventData_ByEventID(3);
            Console.ReadKey();
        }

        public static void GetAllEventData_ByEventID(int EventID) //Get All Events Records By ID  
        {
            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString($"http://localhost:5162/api/student/{EventID}"); //URI 
                Console.WriteLine(Environment.NewLine + result);
            }
        }
    }
}
