using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rosentis.DataContract.Base;
using System.ComponentModel.DataAnnotations;

namespace Rosentis.DataContract.AuthEntities
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "وارد کردن شماره همراه الزامی است")]
        public long Phone { get; set; }
        [Required(ErrorMessage = "وارد کردن ایمیل الزامی است")]
        [EmailAddress(ErrorMessage = "ایمیل به درستی وارد نشده است")]
        public string Email { get; set; }
    }
}
