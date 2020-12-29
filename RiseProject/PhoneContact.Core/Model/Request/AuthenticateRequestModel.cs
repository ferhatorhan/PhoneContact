using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhoneContact.Core.Model.Request
{
    public class AuthenticateRequestModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PassWord { get; set; }
    }
}
