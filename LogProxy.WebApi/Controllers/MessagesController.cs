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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<RecordList>> GetMessages()
        {
            var items = await _messageService.GetMessages();
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
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
            var items = await _messageService.MessageTransfer(messages);
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }
    }
}