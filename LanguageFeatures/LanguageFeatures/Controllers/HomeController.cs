using System;
//16.08.21 컬렉션, 배열사용 using.
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LanguageFeatures.Models;
using System.Text;
//16.08.21 LINQ 사용을 위한 using.


namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public string Index() {
            return "Navigate to a URL to show an example";
        }

        public ViewResult AutoProperty() {
            //16.08.21 전달받은 도메인 네임 세팅후 Result 페이지로 전달.
            Product myProduct = new Product();
            myProduct.Name = "jiwook";
            string productName = myProduct.Name;
            //16.08.21 기존 string 2개를 받는 뷰메서드가 있어 달리동작하므로 object 로 변환.
            return View("Result",(object)String.Format("Product Name: {0}", productName));
        }

        public ViewResult CreateProduct() {
            //16.08.21 이니셜라이저 사용.
            Product myProduct = new Product {
                ProductID=100, Name="jiwook",Description="A boat for one person",
                Price=275M, Category="Watersports"
            };
            return View("Result",(object)String.Format("Category: {0}", myProduct.Category));
        }

        public ViewResult CreateCollection() {
            //16.08.21 컬렉션, 배열에서의 사용.
            string[] stringArray = { "apple","orange","plum"};
            List<int> intList = new List<int> { 10,20,30,40};
            Dictionary<string, int> myDict = new Dictionary<string, int> {
                { "apple",10}, {"orange",20}, { "plum",30}
            };

            return View("Result", (object)(stringArray[1] + " | " + intList[2]));
        }

        public ViewResult UseExtension() {

            ShoppingCart cart = new ShoppingCart {
                Products = new List<Product> {
                    new Product { Name = "Kayak", Price= 275M},
                    new Product { Name = "LifeJacket", Price= 48.95M},
                    new Product { Name = "Soccer Ball", Price= 19.50M},
                    new Product { Name = "Corner flag", Price=34.95M}
                }
            };
            //16.08.21 확장메서드사용. myextensionmethods 클래스파일 내 totalprices 클래스를 shoppingcart 클래스에서 바로사용함.(this)
            //16.08.21 같은 네임스페이스 안에서 사용가능.
            decimal cartTotal = cart.TotalPrices();
            return View("Result", (object)String.Format("Total: {0:c}", cartTotal));
        }


        //16.08.21 형식추론. (var키워드를 통한 형식을 지정하지 않은 지역변수 선언방법.)
        public ViewResult CreateVariable() {
            var myVariable = new Product { Name = "jiwook", Category="Watersports", Price=275M};
            string name = myVariable.Name;
            // int count = myVariable.Count; // 에러발생. Product 클래스내 선언된 멤버에 대해서만 호출을 허용함.
            return View("Result", (object)name);
        }

        //16.08.21 익명형식 사용하기 (개체이니셜라이저 + 형식추론)
        public ViewResult CreateAnonArray() {

            //16.08.21 익명개체를 사용.
            var oddsAndEnds = new[] {
                new { Name = "MVC", Category = "Pattern"},
                new { Name = "Hat", Category = "Clothing"},
                new { Name="Apple", Category="Fruit"}
            };

            StringBuilder result = new StringBuilder();
            foreach (var item in oddsAndEnds) {
                result.Append(item.Name).Append(" ");
            }

            return View("Result", (object)result.ToString());
        }

        // 16.08.21 LINQ 사용.
        public ViewResult FindProducts() {

            Product[] products = {
                new Product { Name = "Kayak", Category = "Watersports", Price = 275M},
                new Product { Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                new Product { Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                new Product { Name = "Corner flag", Category = "Soccer", Price = 34.95M}
            };

            /************************        01. 16.08.21 LINQ를 사용하지 않고 질의 수행.
            Product[] foundProducts = new Product[3];

            //16.08.21 배열의 내용을 정렬.
            Array.Sort(products, (item1, item2) => {
                return Comparer<decimal>.Default.Compare(item1.Price, item2.Price);
            });

            //16.08.21 배열의 첫번째 3개의 항목을 결과로 얻기.
            Array.Copy(products, foundProducts, 3);

            //16.08.21 결과작성.
            StringBuilder result = new StringBuilder();
            foreach (Product p in foundProducts) {
                result.AppendFormat("Price: {0} ", p.Price);
            };

            //16.08.21 결과 리턴.
            return View("Result", (object)result.ToString());
            ********************************************************************* END */
            /************************        01. 16.08.21 LINQ 사용. */

            var foundProducts = products.OrderByDescending(e => e.Price).Take(3).Select(e => new { e.Name, e.Price});

            //16.08.21 지연되지않는 LINK 확장메서드. 예)
            var results = products.Sum(e => e.Price); // 16.08.21 결과(stadium) 에 값에 영향을 받지 않음.

            //16.08.21 지연되는 LINQ 확장메서드. 예)
            products[2] = new Product { Name = "Stadium", Price = 79600M}; // 16.08.21 결과에 영향을 미침.
            
            StringBuilder result = new StringBuilder();
            foreach (var p in foundProducts) {
                result.AppendFormat("Price: {0} ", p.Price);
            }

            return View("Result", (object)result.ToString());
            //16.08.21 좀더 확인해봐야함. (LINQ).
        }
    }
}
 