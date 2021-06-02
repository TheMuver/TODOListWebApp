using System.Data;
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
        [Route("user.auth")]
        public IActionResult Auth([FromBody] User user) 
        {
            if (_users.IsCorrectData(user.ToDTO())) 
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

        [HttpPost]
        [Route("user.create")]
        public IActionResult Create([FromBody] User user) 
        {
            if (!_users.IsUserExist(user.ToDTO())) 
            {
                _users.InsertUser(user.ToDTO());
                return Ok("login");
            }
            else 
            {
                return StatusCode(StatusCodes.Status409Conflict);
            }
        }
    }
}