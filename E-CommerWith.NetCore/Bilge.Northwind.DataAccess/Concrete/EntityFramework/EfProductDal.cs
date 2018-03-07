using Bilge.Core.DataAccess.EntityFramework;
using Bilge.Northwind.DataAccess.Abstract;
using Bilge.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bilge.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal:EfEntityRepositoryBase<Product,NorthwindContext>,IProductDal
    {

    }
}
