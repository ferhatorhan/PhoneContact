using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneContact.Core.Model.Request
{
    public class UserRequestModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
