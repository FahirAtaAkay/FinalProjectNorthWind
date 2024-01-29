using Business.Abstract;
using Business;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Messages;
using Core.Utilities.BusinessEngine;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.Dto_s;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
        

        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
            
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
           IResult result = BusinesssRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckIfProductNameIsAlreadyInUse(product.ProductName),CheckIfCategoriesMaxedOut());
            if(result!=null) 
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.Added);

           
            
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Product>> GetAll()
        {

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.Listed);
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
        //important observation to write this method as a private individual method 
        //helps us write the needed code without making spaghetti 
        private IResult CheckIfProductNameIsAlreadyInUse(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.InvalidName);
            }
            return new SuccessResult(Messages.Empty);
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.InvalıdQuantityOfProducts);
            }
            return new SuccessResult(Messages.Empty);
        }
        private IResult CheckIfCategoriesMaxedOut() 
        {
            var result = _categoryService.GetAll();
            if(result.Data.Count > 15) 
            {
                return new ErrorResult(Messages.CategoryLimitExeeded);

            }
            return new SuccessResult(Messages.Empty);
        }
    }
}
