using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TODOListWebApp.Controllers
{
    [Authorize]
    public class UserApiController : ControllerBase
    {
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout() {
            HttpContext.SignOutAsync();
            return Ok();
        }
    }
}