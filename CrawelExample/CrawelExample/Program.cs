using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using HtmlAgilityPack;
using System.Threading.Tasks;

namespace CrawelExample
{
    class Program
    {
        static void Main(string[] args)
        {

            startCrawel();
            Console.ReadLine();
        }

        public static async Task startCrawel()
        {
            var httpClient = new HttpClient();
            var html= await  httpClient.GetStringAsync("https://www.automobile.tn/fr");

            var htmlDocument = new HtmlDocument();
            htmlDocument.Load(html);
            var divs= htmlDocument.DocumentNode.Descendants("DIV").Where(node => node.GetAttributeValue("Class","").Equals("grid-item small--one-half medium--one-quarter large--one-quarte")).ToList();

            foreach (var div in divs)
            {
                var href=div.Descendants("product-grid-item").FirstOrDefault().ChildAttributes("href").FirstOrDefault().Value;
            }



            



          
        }

               
    }
}
