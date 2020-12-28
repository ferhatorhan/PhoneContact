using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneContact.Engine.Models
{
    public class ContactDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string CompanyName { get; set; }
        public List<CommunicationInfoDTO> CommunicationInfos { get; set; }

    }
}
