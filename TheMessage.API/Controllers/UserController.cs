using Microsoft.AspNetCore.Mvc;
using System;
using TheMessage.Business.Entities;
using TheMessage.Business.Interfaces.Services;

namespace TheMessage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("id/{id}")]
        public IActionResult Get(int id)
        {
            var message = _service.GetUserById(id);
            return Ok(message);
        }

        [HttpPost]
        [Route("add/")]
        public IActionResult AddMessage([FromBody] User user)
        {
            try
            {
                _service.SaveUser(user);
                return Ok();
            }
            catch (Exception e)
            {
                return new BadRequestResult();
            }
        }
    }
}
