using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class ShoppingCart
    {
        //16.08.24 price 합계계산클래스. - 기존.
        private LinqValueCalculator calc;

        //16.08.24 ShoppingCart 생성자에 형 세팅.
        public ShoppingCart(LinqValueCalculator calcParam) {
            calc = calcParam;
        }
        
        //16.08.24 IEnumerable 형식의 속성.get;set;
        public IEnumerable<Product> Products { get; set; }

        //16.08.24 합계를 구하는 메서드 호출.
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