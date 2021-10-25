using System.Collections.Generic;

namespace LogProxy.Models
{
    public class InData
    {
        public IList<InRecord> records { get; set; }
        public InData()
        {
            records = new List<InRecord>();
        }
    }
}
