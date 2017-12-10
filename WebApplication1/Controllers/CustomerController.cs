using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customer
        public ActionResult List()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).Select(c => c).Where(c => c.Id == id).SingleOrDefault();

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }


        public ActionResult AddCustomerDetails()
        {

            var membershipType = _context.MembershipType.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customers(),
                MembershipTypeList = membershipType
            };

            ViewBag.PageTitle = "New Customer";

            return View("CustomerForm",viewModel);
        }

        [HttpPost]   
        [ValidateAntiForgeryToken]     
        public ActionResult Save(Customers customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypeList = _context.MembershipType.ToList()
                };

                return View("CustomerForm",viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerDb.CustomerName = customer.CustomerName;
                customerDb.DateOfBirth = customer.DateOfBirth;
                customerDb.IsSubscibed = customer.IsSubscibed;
                customerDb.MembershipTypeId = customer.MembershipTypeId;


            }
            _context.SaveChanges();
            return RedirectToAction("List", "Customer");
        }

        public ActionResult Edit(int id)
        {
            var Customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            ViewBag.PageTitle = "Edit Customer";

            if (Customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = Customer,
                MembershipTypeList = _context.MembershipType.ToList()
            };

            return View("CustomerForm", viewModel);
        }

    }
}