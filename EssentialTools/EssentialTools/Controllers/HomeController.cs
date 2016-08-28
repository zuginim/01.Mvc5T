using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EssentialTools.Models;
//16.08.24 Ninject 추가.
using Ninject;

namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        private IValueCalculator calc;

        private Product[] products = {
            new Product { Name="Kayak", Category="Watersport", Price = 275M},
            new Product { Name="Lifejacket", Category="Watersport", Price = 48.95M},
            new Product { Name="Soccer ball", Category="Soccer", Price = 19.50M},
            new Product { Name="Corner flag", Category="Soccer", Price = 34.95M}
        };

        public HomeController(IValueCalculator calcParam) {
            calc = calcParam;
        }

        public ActionResult Index() {
            
            /*16.08.24 NuGet을 이용한 ninject 설치후 사용. (LinqValueCalculator.cs 모델과, Homecontroller 간의 의존성 제거.)
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            IValueCalculator calc = ninjectKernel.Get<IValueCalculator>();
            */

            ShoppingCart cart = new ShoppingCart(calc) { Products = products };

            decimal totalValue = cart.CalculateProductTotal();

            return View(totalValue);
        }
        
        public ActionResult Exam() {
            
            //16.08.24 의문1 : 이렇게 해도 되는거 같은데 왜 구지 위와같이 하는건지..
            LinqValueCalculator calc_exam = new LinqValueCalculator();
            decimal test = calc_exam.ValueProducts(products);
            return View(test);
        }

        public ActionResult Exam2() {

            //16.08.24 의문2 : 이렇게 해도 되는거 같은데 왜 구지 위와같이 하는건지..
            ShoppingCart_Exam cart_exam = new ShoppingCart_Exam() { Products = products };
            decimal test2 = cart_exam.CalculateProductTotal();
            return View(test2);
        }
    }
}