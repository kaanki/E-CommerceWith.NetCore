using Bilge.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bilge.Northwind.Entities.Concrete
{
    public class Category:IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
