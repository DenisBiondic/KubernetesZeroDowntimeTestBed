using System;
using Microsoft.AspNetCore.Mvc;

namespace FancyService.Controllers
{
    [Route("api/test")]
    public class TestController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("hello");
        }
    }
}