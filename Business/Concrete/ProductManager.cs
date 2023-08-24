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
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }


        public IResult Add(Product product)
        {
            if (product.ProductName.Length > 2) 
            {
                _productDal.Add(product);
                return new SuccessResult(Messages.Added);
            }
            else 
            {
                return new ErrorResult(Messages.InvalidName);
            }
            
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Product>> GetAll()
        {
            
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.Listed);
        }

        public IDataResult<List<Product>> GetById(int productId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.ProductId == productId), Messages.Listed);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice > min && p.UnitPrice < max), Messages.Listed);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.Updated);
        }
    }
}
