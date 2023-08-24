using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result,IDataResult<T>
    {
        public DataResult(T data,bool ısSuccess,string message):base(ısSuccess,message) 
        {
            data = Data;
            
        }
        public DataResult(T data,bool ısSuccess) : base(ısSuccess)
        {
            data = Data;
        }
        
       

        public T Data { get; }
    }
}
