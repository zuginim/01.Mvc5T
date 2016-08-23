using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// 16.08.21 모델클래스 사용을 위한 using.
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        /* 16.08.21 helloworld.
        public string Index()
        {
            return "Hello World";
        }*/

        // 16.08.21 액션메서드.
        public ViewResult Index() {
            int hour = DateTime.Now.Hour;
            ViewBag.Greetiong = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View();
        }

        // 16.08.21 회신버튼 클릭시 액션메서드.
        // 16.08.21 페이지 호출시 실행 액션 메서드. 
        [HttpGet]
        public ViewResult RsvpForm() {
            return View();
        }

        // 16.08.21 폼작성후 Submit 시 호출.
        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse) {

            // 16.08.21 컨트롤러에서의 유효성검사 유무 체크.
            if (ModelState.IsValid)
            {
                // 16.08.21 Thanks 페이지로 데이터 전달.
                return View("Thanks", guestResponse);
            }
            else {
                // 16.08.21 유효성검사가 통과되지 못했을 경우 다시 현재 페이지로..
                return View();
            }
            
        }
    }
}