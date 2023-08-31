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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
                _categoryDal = categoryDal;
        }
        public IResult Add(Category category)
        {
            if(category.CategoryName.Length < 2) 
            {
                return new ErrorResult(Messages.InvalidName);
            }
            else 
            {
                return new SuccessResult(Messages.Added);
            }
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(),Messages.Listed);
        }

        public IDataResult<List<Category>> GetById(int id)
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(p => p.CategoryId == id), Messages.Listed);

        }

       

        public IDataResult<List<CategoryDto>> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.Updated);
        }
    }
}
