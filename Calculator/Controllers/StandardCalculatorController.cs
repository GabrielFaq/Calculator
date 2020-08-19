using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Calculator.Models;

namespace Calculator.Controllers
{
    public class StandardCalculatorController : Controller
    {
        private readonly ILogger<StandardCalculatorController> _logger;

        private readonly Dictionary<string, Delegate> dctOperation = new Dictionary<string, Delegate>() {
                { "addition", new Func<decimal, decimal, decimal>(FuncAddition) },
                { "subtraction", new Func<decimal, decimal, decimal>(FuncSubtraction) },
                { "division", new Func<decimal, decimal, decimal>(FuncDivision) },
                { "multiplication", new Func<decimal, decimal, decimal>(FuncMultiplication) }
            };

        private readonly Dictionary<string, string> dctOperator = new Dictionary<string, string>() {
                { "addition", " + " },
                { "subtraction", " - " },
                { "division", " / " },
                { "multiplication", " * " }
            };

        //private void CleanFunctionsSelected()
        //{
        //    ViewBag.Title = string.Empty;
        //    ViewBag.AdditionSelected = false;
        //    ViewBag.SubtractionSelected = false;
        //    ViewBag.DivisionSelected = false;
        //    ViewBag.MultiplicationSelected = false;
        //}

        public static decimal FuncAddition(decimal arg1, decimal arg2)
        {
            return arg1 + arg2;
        }

        public static decimal FuncSubtraction(decimal arg1, decimal arg2)
        {
            return arg1 - arg2;
        }

        public static decimal FuncDivision(decimal arg1, decimal arg2)
        {
            return arg1 / arg2;
        }

        public static decimal FuncMultiplication(decimal arg1, decimal arg2)
        {
            return arg1 * arg2;
        }

        public StandardCalculatorController(ILogger<StandardCalculatorController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //CleanFunctionsSelected();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(CalculationModel dataModel)
        {
            ViewBag.Message = dataModel.FirstNumber + dctOperator[dataModel.Operation] + dataModel.SecondNumber + " = "
                + dctOperation[dataModel.Operation].DynamicInvoke(Decimal.Parse(dataModel.FirstNumber), Decimal.Parse(dataModel.SecondNumber));

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
