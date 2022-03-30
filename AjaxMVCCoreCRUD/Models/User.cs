using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxMVCCoreCRUD.Models
{
    public class User
    {
        public int UserId { get; set; }
        [DisplayName("FirstName:")]
        [Required(ErrorMessage = "FirstName is Required")]
        public string FirstName { get; set; }

        [DisplayName("LastName:")]
        [Required(ErrorMessage = "LastName is Required")]
        public string LastName { get; set; }

        [DisplayName("Email:")]
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }


        [DisplayName("UserName:")]
        [Required(ErrorMessage = "UserName is Required")]
        public string UserName { get; set; }

        [DisplayName("Password:")]
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("ConfirmPassword:")]
        [Compare("Password", ErrorMessage = "Password Is Not Matched")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
