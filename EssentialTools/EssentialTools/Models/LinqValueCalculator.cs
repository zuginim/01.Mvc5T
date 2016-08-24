using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    /*
    public class LinqValueCalculator
    {
        public decimal ValueProducts(IEnumerable<Product> products) {
            return products.Sum(p=>p.Price);
        }
    }*/

    //16.08.24 interface 도입.
    public class LinqValueCalculator : IValueCalculator {
        public decimal ValueProducts(IEnumerable<Product> products) {
            return products.Sum(p=>p.Price);
        }
    }
}