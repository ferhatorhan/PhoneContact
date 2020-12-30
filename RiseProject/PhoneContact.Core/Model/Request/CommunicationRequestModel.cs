using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneContact.Core.Model.Request
{
    public class CommunicationRequestModel
    {
        public int UUID { get; set; }

        public int id { get; set; }
        public int Type { get; set; }
        public string Content { get; set; }
    }
}
