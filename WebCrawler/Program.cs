using System;
using System.ComponentModel;
using System.IO.Enumeration;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crawler
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           string websiteUrl = null;

           checkIfNull(websiteUrl); //zadanie 4

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(websiteUrl);
            string content = await response.Content.ReadAsStringAsync();

            Regex regex = new Regex(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])");
            MatchCollection matchCollection = regex.Matches(content);
            
            
            if (matchCollection.Count < 1)
            {
                Console.WriteLine("Brak adresów email pod podanym url!"); //zadanie 4
            }
            foreach (var match in matchCollection)
            {
                Console.WriteLine(match);
            }
            
            response.Dispose(); //zadanie 4
            
        }
        static void checkIfNull(string url)
        {
            if (url == null) throw new InvalidEnumArgumentException("Argument jest nullem!"); //zadanie 4

        }
    }
}