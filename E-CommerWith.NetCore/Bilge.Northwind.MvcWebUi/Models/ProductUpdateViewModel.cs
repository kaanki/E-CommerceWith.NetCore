using Bilge.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bilge.Northwind.MvcWebUi.Models
{
    public class ProductUpdateViewModel
    {
        public List<Category> Categories { get; set; }
        public Product Product { get; set; }
    }
}
