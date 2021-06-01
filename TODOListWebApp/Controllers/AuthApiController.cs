using System;
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
        public IActionResult Auth() 
        {
            return Ok();
        }
    }
}