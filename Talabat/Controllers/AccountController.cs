﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Talabat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public IActionResult Register()
        {
            return Ok();
        }
        public IActionResult Login()
        {
            return Ok();
        }

    }
}
