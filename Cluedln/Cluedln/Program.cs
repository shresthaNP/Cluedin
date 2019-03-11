using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using Cluedln.Core;

namespace Cluedln
{
    public class Program
    {
        static List<Company> companyList = new List<Company>();
        static List<Customer> customerList = new List<Customer>();
        static List<Employee> employeeList = new List<Employee>();

        
        

        static void Main(string[] args)
        {       
            GetCompaniesAsync().ConfigureAwait(false);
            Console.ReadLine();        
            
        }

        public static async Task GetCompaniesAsync()
        {
            string url = "https://cluedintestapi.herokuapp.com/api/companies";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url).ConfigureAwait(false);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var content = response.Content;
                    var result = await content.ReadAsStringAsync();

                    companyList = JsonConvert.DeserializeObject<List<Company>>(result);
                }
            }
            // Get all companies
            
            foreach (var company in companyList)
            {
               
                Console.WriteLine(company.Name);
                

            }

            Console.WriteLine("Get more detailed company data");
            Console.WriteLine(" ");
            foreach (var company in companyList)
            {
               
                Console.WriteLine(company.Name);
                company.Employee = await GetEmployeesAsync(company.Id).ConfigureAwait(false);
                company.Customer = await GetCustomersAsync(company.Id).ConfigureAwait(false);

            }

        }

        private static async Task<List<Customer>> GetCustomersAsync(int id)
        {
            var url = $"https://cluedintestapi.herokuapp.com/api/companies/{id}/customers";
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url).ConfigureAwait(false);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var content = response.Content;
                    var result = await content.ReadAsStringAsync();

                    customerList = JsonConvert.DeserializeObject<List<Customer>>(result);
                }
            }

            foreach (var customer in customerList)
            {
                Console.WriteLine(customer.CustomerName);

               
            }
            throw new NotImplementedException();
        }

        private static async Task<List<Employee>> GetEmployeesAsync(int id)
        {

            var url = $"https://cluedintestapi.herokuapp.com/api/companies/{id}/employees";
            
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url).ConfigureAwait(false);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var content = response.Content;
                    var result = await content.ReadAsStringAsync();

                    employeeList = JsonConvert.DeserializeObject<List<Employee>>(result);
                }
            }

            foreach (var employee in employeeList)
            {
                Console.WriteLine(employee.FirstName);

            }
            
            throw new NotImplementedException();
        }

        private static async Task<List<Company>> GetPrint()
        {

            var url = $"https://cluedintestapi.herokuapp.com/api/companies";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url).ConfigureAwait(false);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var content = response.Content;
                    var result = await content.ReadAsStringAsync();

                    companyList = JsonConvert.DeserializeObject<List<Company>>(result);
                }
            }

            foreach (var c in companyList)
            {
                Console.WriteLine(c.Name);
                c.GetSetCustomer = customerList;
                c.GetSetEmployee = employeeList;
                c.Print();
                Console.WriteLine(" ");




            }

            throw new NotImplementedException();
        }




    }
}
    


