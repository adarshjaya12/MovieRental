using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRentals.Models;
namespace MovieRentals.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        private ApplicationDbContext _context;
        
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {

            var customers = _context.Customer.Include(c=> c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id=1)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.CustomerId == id);
            return View(customer);
        }
    }
}