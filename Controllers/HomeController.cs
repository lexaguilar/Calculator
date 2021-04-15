using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Calculator.Models;
using Calculator.Services;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICalculatorServices<Tax> _service;
        private ITaxServices<IR> _taxService;

        public HomeController(ILogger<HomeController> logger, ICalculatorServices<Tax> service, ITaxServices<IR> taxService)
        {
            _logger = logger;
            _service = service;
            _taxService = taxService;
        }

        public IActionResult Index()
        {           

            ViewBag.Salary = 0M;
            ViewBag.Inss = _taxService.GetInss();

            return View();

        }

        [HttpPost]
        public IActionResult Index(decimal salary)
        {
           
            ViewBag.Salary = salary;
            ViewBag.Inss = _taxService.GetInss();

            var newTax = _service.Calculate(salary);
            var newTaxMonthly = _service.CalculateMonthly(newTax);

            Tax[] Taxs = { newTax, newTaxMonthly };

            return View(Taxs);

        }
    }
}
