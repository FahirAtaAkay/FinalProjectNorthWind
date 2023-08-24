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
    public class CategoryManager : ICategoryService
    {
        public IResult Add(Category category)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Category category)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Category>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Category>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Category>> GetByUnitPrice(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CategoryDto>> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
