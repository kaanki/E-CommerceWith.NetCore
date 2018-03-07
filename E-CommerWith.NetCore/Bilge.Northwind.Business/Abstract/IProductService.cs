using Bilge.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bilge.Northwind.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetByCategory(int categoryId);
        void Add(Product product);
        void Update(Product product);
        void delete(int ProductId);
        Product GetById(int productId);
    }
}
