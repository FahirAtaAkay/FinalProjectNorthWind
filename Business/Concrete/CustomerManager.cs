using Business.Abstract;
using Core.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
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
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
                _customerDal = customerDal;
        }
        public IResult Add(Customer customer)
        {
            if (customer.FirstName.Length < 2)
            {
                return new ErrorResult(Messages.InvalidName);
            }
            else
            {
                return new SuccessResult(Messages.Added);
            }
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<Customer>> GetById(string id)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(p => p.CustomerId== id), Messages.Listed);

        }


        public IDataResult<List<CategoryDto>> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.Updated);
        }

        IDataResult<List<CustomerDetailDto>> ICustomerService.GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
