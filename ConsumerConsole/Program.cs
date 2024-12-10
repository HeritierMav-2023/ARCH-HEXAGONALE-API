// See https://aka.ms/new-console-template for more information
using System.Net;

GetAllEventData_ByEventID(3);

Console.ReadKey();


static void GetAllEventData_ByEventID(int EventID) //Get All Events Records By ID  
{
    using (var client = new WebClient()) //WebClient  
    {
        client.Headers.Add("Content-Type:application/json"); //Content-Type  
        client.Headers.Add("Accept:application/json");
        var result = client.DownloadString($"http://localhost:5162/api/student/{EventID}"); //URI 
        Console.WriteLine(Environment.NewLine + result);
    }
}
