using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneContact.Engine.Models
{
    public class CommunicationInfoDTO
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public int PersonId { get; set; }
        public ContentTypeDTO Type { get; set; }
    }
}
