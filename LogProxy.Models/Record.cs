using System;

namespace LogProxy.Models
{
    public class Record
    {
        public string Id { get; set; }
        public OuterMessage Fields { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
    }
}
