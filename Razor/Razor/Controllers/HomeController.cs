using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//16.08.22 모델클레스참조를 위한 using.
using Razor.Models;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        //16.08.22 개체이니셜라이저.
        Product myProduct = new Product {

            ProductID = 1,
            Name = "jiwook",
            Description = "A boat for one person",
            Category = "Watersports",
            Price = 275M
        };

        //16.08.22 기본 뷰 호출.
        public ActionResult Index()
        {
            return View(myProduct);
        }

        //16.08.22 뷰로 배열을 렌더하는부분은 기본적으로 지원되지 않으나, 모델 배열선언을 통해 가능.
        public ActionResult DemoArray() {

            Product[] array = {
                new Product { Name = "Kayak", Price = 275M},
                new Product { Name = "Liftjacket", Price = 48.95M},
                new Product { Name = "Soccer ball", Price = 19.50M},
                new Product { Name = "Corner flag", Price = 34.95M}
            };

            return View(array);
        }

        
    }
}