using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRentals.Models;
using MovieRentals.ViewModel;
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

        public ActionResult Edit(int id)
        {
            var customer = _context.Customer.Include(c => c.MembershipType).SingleOrDefault(c => c.CustomerId == id);
            
            if (customer == null)
                return HttpNotFound();
            var ModelView = new CustomerView()
            {
                Customer = customer,
                MembershipTypes = _context.MemebershipType,
                CustomerGender = new List<GenderClass>()
                {
                    new GenderClass() { GenderId = 1, GenderType = customer.CustomerGender}
                }
            };
            return View("CustomerForm",ModelView);
        }

        //public ActionResult Details(int id=1)
        //{
        //    var customer = _context.Customer.Include(c => c.MembershipType).SingleOrDefault(c => c.CustomerId == id);
        //    if (customer == null)
        //        return HttpNotFound();
        //    return View(customer);
        //}

        [HttpPost]
        public ActionResult Create(CustomerView viewCustomer)
        {
            var checkExist = _context.Customer.Where(c => c.CustomerId == viewCustomer.Customer.CustomerId).FirstOrDefault();
            if(checkExist == null)
            {
                _context.Customer.Add(viewCustomer.Customer);

                try
                {
                    _context.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    foreach (var e in ex.EntityValidationErrors)
                    {
                        //check the ErrorMessage property
                    }
                }
            }
            else
            {
                checkExist.CustomerName = viewCustomer.Customer.CustomerName;
                checkExist.BirthDate = viewCustomer.Customer.BirthDate;
                checkExist.CustomerGender = viewCustomer.Customer.CustomerGender;
                checkExist.IsSubscribedToNewsLetter = viewCustomer.Customer.IsSubscribedToNewsLetter;
                checkExist.MembershipTypeId = viewCustomer.Customer.MembershipTypeId;
                checkExist.Age = viewCustomer.Customer.Age;
                _context.Entry(checkExist).State = EntityState.Modified;
                _context.SaveChanges();
            }
            
            
            return RedirectToAction("Index","Customers");
        }

        public ActionResult New()
        {

            var MembershipTy = _context.MemebershipType.ToList();
            var ViewModel = new CustomerView();
            ViewModel.CustomerGender = new List<GenderClass>()
            {
                new GenderClass(){ GenderId = 1, GenderType = "Male"},
                new GenderClass() { GenderId = 2, GenderType = "Female"}
            };
            
            ViewModel.MembershipTypes = MembershipTy;
            
            return View("CustomerForm",ViewModel);
        }
    }
}