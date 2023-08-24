using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        public IResult Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Customer cudtomer)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Customer>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Customer>> GetByUnitPrice(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CustomerDetailDto>> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
