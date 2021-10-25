using System.Collections.Generic;
using System.Threading.Tasks;
using LogProxy.Models;
using LogProxy.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace LogProxy.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<ActionResult<RecordList>> GetMessages()
        {
            return await _messageService.GetMessages();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<RecordList>> PostMessages(List<Message> messages)
        {
            if (messages == null)
            {
                return BadRequest("messages is empty");
            }
            return await _messageService.MessageTransfer(messages);
        }
    }
}