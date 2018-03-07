using Bilge.Core.DataAccess.EntityFramework;
using Bilge.Northwind.DataAccess.Abstract;
using Bilge.Northwind.Entities.Concrete;

namespace Bilge.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfCategorytDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {

    }
}
