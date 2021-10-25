using System;
using System.Collections.Generic;
using System.Text;

namespace LogProxy.Models.Interfaces
{
    public interface IMessage
    {
        string Title { get; set; }
        string Text { get; set; }
    }
}
