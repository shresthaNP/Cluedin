using System;
using System.Collections.Generic;
using System.Text;

namespace Cluedln.Core
{

    public class Company
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Employee> Employee { get; set; }
        public List<Customer> Customer { get; set; }


        public List<Customer> GetSetCustomer

        {

            get

            {

                return Customer;

            }

            set

            {

                Customer = value;

            }



        }
        public List<Employee> GetSetEmployee

        {

            get

            {

                return Employee;

            }

            set

            {

                Employee = value;

            }
        }


        public void Print()

        {

            Console.WriteLine("Name: " + this.Name);           

            Console.WriteLine("Car Owns");

            foreach (Employee e in this.GetSetEmployee)

            {

                Console.WriteLine("Emplyee Name:- " + e.FirstName + e.LastName);

            }

            foreach (Customer c in this.GetSetCustomer)

            {

                Console.WriteLine("Customer Name:- " + c.CustomerName);

            }

        }

    }
    }
