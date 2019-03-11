using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
 



namespace CluedlnProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new WebClient();

            //Get specific data from the URL
            var json = client.DownloadString("https://cluedintestapi.herokuapp.com/api/companies/4");
            Console.Write(json);
                              

            //Get specific data about all the companies
            var allData = client.DownloadString("https://cluedintestapi.herokuapp.com/api/companies");

            List<Company> listcomp= (List<Company>)JsonConvert.DeserializeObject(allData, typeof(List<Company>));

            Company cname= listcomp.Find(x => x.id == 5);
            Console.WriteLine("ID :" + cname.id + "" + "Name :" + cname.name + "" + "Email :" + cname.email + "" + "Phone :" + cname.phoneNumber);

            // counts number of companies in the list and print all the values in screen

            int count = 0;

            foreach (var item in listcomp)
            {
               
                Console.WriteLine("Id: " + item.id);
                Console.WriteLine("Name: " + item.name);
                Console.WriteLine("Email: " + item.email);
                Console.WriteLine("Phone Number: " + item.phoneNumber);
                count ++;
               
            }

            Console.WriteLine(" Number of Companies :" + count);           


            Console.WriteLine("Hello Shrestha/Simon/Silas/Seema");

        }
    }
}
