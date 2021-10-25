using System.Collections.Generic;

namespace LogProxy.Models
{
    public class RecordList
    {
        public List<Record> Records { get; set; }

        public RecordList()
        {
            Records = new List<Record>();
        }
    }
}
