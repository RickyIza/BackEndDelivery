using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMiVeci.Models
{
    public class LoginRequest
    {
         public string correo { get; set; }
         public string password { get; set; }
    }
}