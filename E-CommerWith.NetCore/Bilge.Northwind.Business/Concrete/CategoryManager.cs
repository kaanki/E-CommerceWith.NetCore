using Bilge.Northwind.Business.Abstract;
using Bilge.Northwind.DataAccess.Abstract;
using Bilge.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bilge.Northwind.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetList();
        }
    }
}
