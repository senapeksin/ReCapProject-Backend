using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result()
        {

        }
        public bool Success { get; }

        public string Message { get; }
    }
}
