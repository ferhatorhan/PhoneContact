using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneContact.Core.Helpers
{
    public class AppSettings: IAppSettings
    {
        public string SecretKey { get; set; }
    }
}
