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
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<Customer>> GetById(int id);
        IDataResult<List<Customer>>GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<CustomerDetailDto>> GetProductDetails();
        IResult Add(Customer customer);
        IResult Delete(Customer cudtomer);
        IResult Update(Customer customer);
    }
}
