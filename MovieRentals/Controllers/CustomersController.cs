using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRentals.Models;
namespace MovieRentals.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public CustomersList FillList()
        {
            CustomersList list = new CustomersList();
            list.CustomerLists = new List<Customer> { 
                                new Customer { CustomerId = 1, CustomerName = "Adarsh Jayakumar" , CustomerGender ="Male"},
                                new Customer { CustomerId = 2, CustomerName="Abhinav Jayakumar", CustomerGender ="Male"},
                                new Customer { CustomerId = 3, CustomerName="Jayalatha" , CustomerGender ="Female"},
                                new Customer {CustomerId = 4, CustomerName ="Jayakumar", CustomerGender = "Male"}

                                };
            return list;
        }
        public ActionResult Index()
        {
            CustomersList list = FillList();

            return View(list);
        }

        public ActionResult Details(int id=1)
        {
            CustomersList list = FillList();
            var customerDetails = list.CustomerLists.Where(c => c.CustomerId == id).ToList();
            return View(customerDetails);
        }
    }
}