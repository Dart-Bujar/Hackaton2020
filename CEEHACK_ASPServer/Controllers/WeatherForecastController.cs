using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CEEHACK_ASPServer.Models;

namespace CEEHACK_ASPServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            var response = "";
            using (var context = new CEEHackContext())
            {
                var std = context.Patients.First<Patient>();
                response = std.Name.ToString();
            }
            return response;
          
        }



    }



}
