using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;
using Northwind.Repositories;

namespace Northwind.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Order> orders = _orderRepository.GetAllOrders();
            return View(orders);
        }

        public IActionResult Details(int id)
        {
            Order order = _orderRepository.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
    }
}
