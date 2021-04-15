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
    public class IRController : Controller
    {
        private readonly ILogger<IRController> _logger;
        private ITaxServices<IR> _service;

        public IRController(ILogger<IRController> logger, ITaxServices<IR> service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
             var tableIR = _service.GetTable();
            return View(tableIR);
        }
    }
}
