using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPIdentityDevPack.Identity
{
    public class CustomIdentityUser : IdentityUser
    {
        public string Document { get; set; }
        public string Role { get; set; }
        public DateTime Birthday { get; set; }

        public CustomIdentityUser()
        {
        }
    }
}
