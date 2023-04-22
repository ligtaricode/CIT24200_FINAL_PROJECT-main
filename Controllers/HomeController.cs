using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Northwind.Repositories;
using Northwind.ViewModels;

namespace Northwind.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public HomeController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            var customers = _customerRepository.GetAll()
                .Select(CustomerViewModel.FromCustomer);
            return View(customers);
        }

        public IActionResult Details(string id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }

            var viewModel = CustomerViewModel.FromCustomer(customer);
            return View(viewModel);
        }
    }
}
