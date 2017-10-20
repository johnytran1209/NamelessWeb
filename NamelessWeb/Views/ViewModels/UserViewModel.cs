using NamelessWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NamelessWeb.Views.ViewModels
{
    public class UserViewModel
    {
        public LoginViewModel LoginViewModel { get; set; }
        public RegisterViewModel RegisterViewModel { get; set; }
    }
}