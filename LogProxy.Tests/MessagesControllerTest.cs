using System.Collections.Generic;
using LogProxy.Models;
using LogProxy.Services;
using LogProxy.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace LogProxy.Tests
{
    public class MessagesControllerTest
    {
        MessagesController _controller;
        IMessageService _service;

        public MessagesControllerTest()
        {
            _service = new MessageServiceFake();
            _controller = new MessagesController(_service);
        }

        [Fact]
        public async void GetMessages_Result_Test()
        {
            var result = await _controller.GetMessages();
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async void GetMessages_Type_Test()
        {
            var result = await _controller.GetMessages();
            Assert.IsType<ActionResult<RecordList>>(result);
        }

        [Fact]
        public async void PostMessages_OK_Test()
        {
            var result = await _controller.PostMessages(new List<Message>());
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async void PostMessages_BadRequest_Test()
        {
            var result = await _controller.PostMessages(null);
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async void PostMessages_Type_Test()
        {
            var result = await _controller.PostMessages(new List<Message>());
            Assert.IsType<ActionResult<RecordList>>(result);
        }
    }



}
