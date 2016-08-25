using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageFeatures.Models
{
    public class ShoppingCart
    {
        //16.08.21 Product 개체의 컬렉션.
        public List<Product> Products { get; set; }
    }
}