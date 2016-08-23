using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// 16.08.21 유효성검사를 위해 추가.
using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        //16.08.21 도메인 클래스 선언.

        // 16.08.21 각 도메인별 유효성 추가.
        [Required(ErrorMessage = "이름을 입력해주세요.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "메일을 입력해주세요.")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = " 메일주소가 올바르지않습니다. 다시작성해주세요. ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "연락처를 입력해주세요.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "드롭박스를 선택해주세요.")]
        public bool? WillAttend { get; set; }
    }
}