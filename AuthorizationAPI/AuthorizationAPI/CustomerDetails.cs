using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationAPI.Models;

namespace AuthorizationAPI
{
    public class CustomerDetails
    {
        public static List<Customer> Customers { get; set; } = new List<Customer>()
        {
            new Customer()
            {
                CustomerId = 1,
                PortfolioId = 1,
                CustomerName = "Achintya Mittal",
                Password = "Achintya@cts",
                PhoneNumber = 252806,
                Username = "achintya@cts"
            },
            new Customer()
            {
                CustomerId = 2,
                PortfolioId = 2,
                CustomerName = "Chanakya Nallapati",
                Password = "Chanakya@cts",
                PhoneNumber = 252899,
                Username = "chanakya@cts"
            },
            new Customer()
            {
                CustomerId = 3,
                PortfolioId = 3,
                CustomerName = "Yogesh Mundra",
                Password = "Yogesh@cts",
                PhoneNumber = 232806,
                Username = "yogesh@cts"
            },
            new Customer()
            {
                CustomerId = 4,
                PortfolioId = 4,
                CustomerName = "Yamini Pattamsetti",
                Password = "Yamini@cts",
                PhoneNumber = 252806,
                Username = "yamini@cts"
            },
            new Customer()
            {
                CustomerId = 5,
                PortfolioId = 5,
                CustomerName = "Samarth Gupta",
                Password = "Samarth@cts",
                PhoneNumber = 232806,
                Username = "samarth@cts"
            },
            new Customer()
            {
                CustomerId = 6,
                PortfolioId = 6,
                CustomerName = "Kamal Sharma",
                Password = "Kamal@cts",
                PhoneNumber = 252806,
                Username = "kamal@cts"
            }
        };
    }
}
