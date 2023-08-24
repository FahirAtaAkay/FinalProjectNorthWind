using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool ısSuccess , String message) : this(ısSuccess) 
        {
            Message = message;
            IsSuccess = ısSuccess;


        }
        public Result(bool ısSuccess)
        {
            IsSuccess = ısSuccess;
            
        }
        
        public bool IsSuccess { get; set; }
        public string Message { get;set; }
    }
}
