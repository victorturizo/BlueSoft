using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreBluesoft.WebApi.JWTImplementation
{
    public class User
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public double Expires { get; set; }
    }
}
