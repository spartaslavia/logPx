using System.Collections.Generic;
using System.Threading.Tasks;
using LogProxy.Models;
using LogProxy.Services;

namespace LogProxy.Tests
{
    public class MessageServiceFake : IMessageService
    {
        public Task<RecordList> GetMessages()
        {
            return Task.FromResult(new RecordList());
        }

        public Task<RecordList> MessageTransfer(IList<Message> messages)
        {
            return Task.FromResult(new RecordList());
        }
    }
}
