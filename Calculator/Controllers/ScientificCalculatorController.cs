using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Calculator.Models;

namespace Calculator.Controllers
{
    public class ScientificCalculatorController : Controller
    {
        private readonly ILogger<ScientificCalculatorController> _logger;

        private readonly Dictionary<string, Delegate> dctOperation = new Dictionary<string, Delegate>() {
                { "base10Logarithm", new Func<double, double>(FuncBase10Logarithm) },
                { "squareRoot", new Func<double, double>(FuncSquareRoot) },
                { "sine", new Func<double, double>(FuncSine) },
                { "cosine", new Func<double, double>(FuncCosine) },
                { "tangent", new Func<double, double>(FuncTangent) }
            };

        private readonly Dictionary<string, string> dctOperator = new Dictionary<string, string>() {
                { "base10Logarithm", "Log10" },
                { "squareRoot", "Sqrt" },
                { "sine", "Sin" },
                { "cosine", "Cos" },
                { "tangent", "Tan" }
            };

        public static double FuncBase10Logarithm(double arg)
        {
            return Math.Log10(arg);
        }

        public static double FuncSquareRoot(double arg)
        {
            return Math.Sqrt(arg);
        }

        public static double FuncSine(double arg)
        {
            return Math.Sin(arg);
        }

        public static double FuncCosine(double arg)
        {
            return Math.Cos(arg);
        }
        
        public static double FuncTangent(double arg)
        {
            return Math.Tan(arg);
        }

        public ScientificCalculatorController(ILogger<ScientificCalculatorController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(CalculationModel dataModel)
        {
            ViewBag.Message = dctOperator[dataModel.Operation] + "(" + dataModel.FirstNumber + ") = "
                + dctOperation[dataModel.Operation].DynamicInvoke(Double.Parse(dataModel.FirstNumber));

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
