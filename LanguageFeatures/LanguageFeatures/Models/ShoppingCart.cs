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

        //16.08.21 인터페이스 확장메서드, 필터링 확장메서드, 델리게이트,람다식 확장메서드, 자동형식추론 알아봐야함.
        //16.08.21 비동기메서드에 대해 좀더 자세히 알아봐야함.
    }
}