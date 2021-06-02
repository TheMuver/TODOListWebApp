using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TODOListWebApp.Repository;

namespace TODOListWebApp.Controllers
{
    [ApiController]
    public class AuthApiController : ControllerBase
    {
        IUserRepository _users;

        public AuthApiController(IUserRepository users) 
        {
            _users = users;
        }

        [HttpPost]
        [Route("auth")]
        public IActionResult Auth([FromBody] User user) 
        {
            if (user.Login.Equals("lol@ya.ru") && user.Login.Equals("lol")) 
            {
                List<Claim> claims = new List<Claim>() { new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login) };
                ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
                return Ok("notes");
            }
            else 
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }
    }
}