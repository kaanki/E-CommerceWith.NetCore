using Bilge.Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace Bilge.Northwind.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
    }
}
