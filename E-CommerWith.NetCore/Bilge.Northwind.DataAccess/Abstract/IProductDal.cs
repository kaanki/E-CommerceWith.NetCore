using Bilge.Core.DataAccess;
using Bilge.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bilge.Northwind.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {

    }
}
