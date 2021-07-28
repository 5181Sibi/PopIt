using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class LoginViewModel
    {

        [Display(Name = "USERNAME")]
        public string username { get; set; }
        [DataType("password")]
        [Display(Name = "PASSWORD")]
        public string password { get; set; }

        public bool RememberMe { get; set; }
    }
}
