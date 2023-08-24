using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<List<Order>> GetAll();
        IDataResult<List<Order>> GetById(int id);
        
        IDataResult<List<OrderDetailDto>> GetProductDetails();
        IResult Add(Order order);
        IResult Delete(Order order);
        IResult Update(Order order);
    }
}
