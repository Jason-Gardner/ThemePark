using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ThemePark.Models;

namespace ThemePark.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "../ThemePark/Data/Ride.json";
            List<Park> myParks = new List<Park>();

            
            using (StreamReader reader = new StreamReader(resourceName))
            {
                string jsonFile = reader.ReadToEnd(); //Make string equal to full file
                JsonDocument responseList = JsonDocument.Parse(jsonFile);
                var parks = responseList.RootElement.GetProperty("result");

                for(int i = 0; i < parks.GetArrayLength(); i++)
                {
                    myParks.Add(new Park()
                    {
                        parkName = parks[i].GetProperty("parkName").ToString(),
                        parkCity = parks[i].GetProperty("parkCity").ToString(),
                        parkState = parks[i].GetProperty("parkState").ToString(),
                        parkYear = parks[i].GetProperty("parkInfo").ToString(),
                        isOpen = parks[i].GetProperty("isOpen").GetBoolean()
                    }); 
                }
            }

            Coaster Maverick = new Coaster()
            {
                rideName = "Maverick",
                ridePark = myParks[0],
                opStatus = true
            };

            return View("Index",Maverick);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
