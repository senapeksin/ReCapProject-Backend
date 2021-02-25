using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IResult
    {
        //Temel voidler için
        public string Success { get;}
        public string  Message { get; set; }
    }
}
