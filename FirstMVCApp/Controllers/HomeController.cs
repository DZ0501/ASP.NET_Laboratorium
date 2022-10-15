using FirstMVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public string Hello()
        {
            string name = Request.Query["name"];
            string age = Request.Query["age"];

            if (int.TryParse(age, out var ageInt) && name != null)
            {
                Response.StatusCode = 200;
                return $"Hello {name}, You are {ageInt} years old";

            }

            if (name == null)
            {
                Response.StatusCode = 418;
                return "";
            }

            return "";
        }

        public string HelloBis([FromQuery] string name, [FromQuery] int age)
        {
            if (name != null )
            {
                Response.StatusCode = 200;
                return $"Hello {name}, You are {age} years old";
            }
            Response.StatusCode = 400;
            return "";
        }

        /**
         *  Zdefiniuj akcję Calc, która realizuje kalkulator czyli mam 3 parametry
         * a, b = liczby double
         * operator - łańcuch z nazwami operacji, np. MUL, DIV, ADD, SUB
        **/

        public string Calc([FromQuery] double a, [FromQuery] double b, [FromQuery] string OPRTR)
        {
            double result;

            if (OPRTR == "MUL")
            {
                result = a * b;
                return $"{result}";
            }

            else if (OPRTR == "DIV")
            {
                
                if (b == 0)
                {
                    return "Do not divide by 0";
                }

                result = a / b;
                return $"{result}";
            }

            else if (OPRTR == "ADD")
            {
                result = a + b;
                return $"{result}";
            }

            else if (OPRTR == "SUB")
            {
                result = a - b;
                return $"{result}";
            }

            else if (OPRTR == null | a == null | b == null)
            {
                Response.StatusCode = 418;
                return "";
            }

            return "";
        }

        public string CalcBis([FromQuery] CalcModel model)
        {
            if (model == null || model.A == null || model.B == null || model.OP == null)
            {
                Response.StatusCode = 418;
                return "";
            }

            double b = (double)model.B;
            return $"{ model.A / b}";
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
