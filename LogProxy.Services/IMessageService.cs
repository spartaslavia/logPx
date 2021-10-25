using System.Collections.Generic;
using System.Threading.Tasks;
using LogProxy.Models;

namespace LogProxy.Services
{
    public interface IMessageService
    {
        Task<RecordList> MessageTransfer(IList<Message> messages);

        Task<RecordList> GetMessages();
    }
}
