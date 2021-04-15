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
    public class InssController : Controller
    {
        private readonly ILogger<InssController> _logger;
        private ITaxServices<IR> _service;

        public InssController(ILogger<InssController> logger, ITaxServices<IR> service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            var inss = _service.GetInss();
            return View(inss);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Inss inss)
        {
            await _service.SetInssAsync(inss);
            return View(inss);
        }
    }
}
