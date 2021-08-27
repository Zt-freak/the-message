using Microsoft.AspNetCore.Mvc;
using System;
using TheMessage.Business.Entities;
using TheMessage.Business.Interfaces.Services;

namespace TheMessage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _service;

        public MessageController(IMessageService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("id/{id}")]
        public IActionResult Get(int id)
        {
            var message = _service.GetMessageById(id);
            return Ok(message);
        }

        [HttpGet]
        [Route("userid/{id}")]
        public IActionResult GetByUserId(int id)
        {
            var messages = _service.GetMessagesByUserId(id);
            return Ok(messages);
        }

        [HttpPost]
        [Route("add/")]
        public IActionResult AddMessage([FromBody] Message message)
        {
            try
            {
                _service.SaveMessage(message);
                return Ok();
            }
            catch(Exception e)
            {
                return new BadRequestResult();
            }
        }
    }
}
