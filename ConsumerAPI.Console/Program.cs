using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
        }

        public static void GetAllEventData_ByEventID(string EventID) //Get All Events Records By ID  
        {
            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("http://localhost:50024/api/Event/" + EventID); //URI  
                Console.WriteLine(Environment.NewLine + result);
            }
        }
    }
}
