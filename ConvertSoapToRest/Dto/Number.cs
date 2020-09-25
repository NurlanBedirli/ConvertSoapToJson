using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConvertSoapToRest.Dto
{
    public class Number
    {
        //[Required( ErrorMessage ="FirstNumber is empty")]
        public int FirstNumber { get; set; }
        //[Required(ErrorMessage = "SecondNumber is empty")]
        public int SecondNumber { get; set; }
    }
}
