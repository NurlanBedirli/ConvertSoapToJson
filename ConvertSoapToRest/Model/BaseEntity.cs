using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConvertSoapToRest.Model
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime Insert_Date { get; set; }
    }
}
