using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MultiplicationTableMVC.Models.Constants;

namespace MultiplicationTableMVC.Models
{
    public class MultiplyViewModel
    {
        public int Size { get; set; }
        public NumericRepresentation Representation { get; set; }

        public MultiplyViewModel()
        {
            Size = 10;
            Representation = NumericRepresentation.Decimal;
        }

        public MultiplyViewModel(int size, NumericRepresentation representation)
        {
            Size = size;
            Representation = representation;
        }
    }
}