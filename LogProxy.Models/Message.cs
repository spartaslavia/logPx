using LogProxy.Models.Interfaces;

namespace LogProxy.Models
{
    public class Message : IMessage
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
