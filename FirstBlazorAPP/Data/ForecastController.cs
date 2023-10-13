/*
using FirstBlazorApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasksl


namespace FirstBlazorApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForecastController : ControllerBase
    {
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> GetTask
        {
            var svc = new WeatherForecastService();
            return new OkObjectResult(await svc.GetForecastAsync(DateTime.))
        }
    }
}

*/