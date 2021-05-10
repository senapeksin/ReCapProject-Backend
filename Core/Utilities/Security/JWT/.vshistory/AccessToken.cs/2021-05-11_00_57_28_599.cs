using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken  //Access Token : anlamsız karakterlerden olusan bir anahtar değeridir.
    {
        public string Token { get; set; } //JWT
        public DateTime Expiration { get; set; } //bitiş zamanı
    }
}
