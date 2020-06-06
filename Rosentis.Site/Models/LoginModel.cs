using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rosentis.Site.Models
{
    public class LoginModel
    {
        //[Required(ErrorMessage = "وارد کردن شماره همراه الزامی است")]
        public long Phone { get; set; }
		[Required(ErrorMessage = "وارد کردن ایمیل الزامی است")]
		public string username { get; set; }
		public string password { get; set; }
	}
}