using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneContact.Core.Helpers
{
    public interface IAppSettings
    {
        string SecretKey { get; set; }
    }
}
