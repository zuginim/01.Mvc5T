using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class ShoppingCart
    {
        private IValueCalculator calc;
        //private LinqValueCalculator calc;

        //16.08.24 생성자세팅.
        //public ShoppingCart(LinqValueCalculator calcParam) {
        //    calc = calcParam;
        //}
        public ShoppingCart(IValueCalculator calcParam) {
            calc = calcParam;
        }
        //16.08.24 이와같이 ShoppingCart 와 LinqValueCalculator 간의 의존성을 제거할 수 있다.

        public IEnumerable<Product> Products { get; set; }
        
        public decimal CalculateProductTotal() {
            return calc.ValueProducts(Products);
        }
    }
    public class ShoppingCart_Exam {
        LinqValueCalculator calc = new LinqValueCalculator();
        public IEnumerable<Product> Products { get; set; }
        public decimal CalculateProductTotal() {
            return calc.ValueProducts(Products);
        }
    }
}