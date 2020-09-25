using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConvertSoapToRest.Model
{
    public class SecondTable : BaseEntity
    {
        public Table Table { get; set; }
        public int TableId { get; set; }
        public string Value { get; set; }
    }
}
