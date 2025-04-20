using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace This2ThatConverter.Models
{
    public class UnitConversionRequest
    {      
        public string FromUnit { get; set; }
        public string ToUnit { get; set; }
        public double Value { get; set; }
    }
}
