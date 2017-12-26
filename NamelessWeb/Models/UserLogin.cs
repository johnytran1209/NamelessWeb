using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NamelessWeb.Models
{
    public class UserLogin
    {
        string LoginProvider { get; set; }
        string ProviderKey { get; set; }
        string UserId { get; set; }
    }
}