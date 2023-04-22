using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore.Controllers
{
    public class CustomerController : Controller
    {
        private readonly NorthwindContext _context;

        public CustomerController(NorthwindContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<CustomerViewModel> customers = _context.Customers.Select(c => new CustomerViewModel
            {
                CustomerID = c.CustomerId,
                CompanyName = c.CompanyName,
                ContactName = c.ContactName,
                ContactTitle = c.ContactTitle,
                Address = c.Address,
                City = c.City,
                Region = c.Region,
                PostalCode = c.PostalCode,
                Country = c.Country,
                Phone = c.Phone,
                Fax = c.Fax
            }).ToList();

            return View(customers);
        }

        public IActionResult Details(string id)
        {
            CustomerViewModel customer = _context.Customers.Where(c => c.CustomerId == id).Select(c => new CustomerViewModel
            {
                CustomerID = c.CustomerId,
                CompanyName = c.CompanyName,
                ContactName = c.ContactName,
                ContactTitle = c.ContactTitle,
                Address = c.Address,
                City = c.City,
                Region = c.Region,
                PostalCode = c.PostalCode,
                Country = c.Country,
                Phone = c.Phone,
                Fax = c.Fax
            }).FirstOrDefault();

            return View(customer);
        }
    }
}
