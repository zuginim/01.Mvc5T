using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        //16.08.21 ShoppingCart 클래스의 인스턴스를 이용하여 토털 가격을 계산한다.
        //16.08.21 this 키워드는 지정한 클래스의 확장 클래스라는 것을 의미.
        public static decimal TotalPrices(this ShoppingCart cartParam) {
            decimal total = 0;
            foreach (Product prod in cartParam.Products) {
                total += prod.Price;
            }
            return total;
        }
    }
}