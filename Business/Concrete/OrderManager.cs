using Business.Abstract;
using Core.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderdal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderdal = orderDal;
                
        }
        public IResult Add(Order order)
        {
            _orderdal.Add(order);
            return new SuccessResult(Messages.Added);

        }

        public IResult Delete(Order order)
        {
            _orderdal.Delete(order);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderdal.GetAll(),Messages.Listed);
        }

        public IDataResult<List<Order>> GetById(int id)
        {
            return new SuccessDataResult<List<Order>>(_orderdal.GetAll(p => p.OrderId == id));
        }

       

        public IDataResult<List<OrderDetailDto>> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Order order)
        {
            _orderdal.Update(order);
            return new SuccessResult(Messages.Updated);
        }
    }
}
