using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhoneContact.Data.Entities
{
    [Table("CommunicationInfo")]
    public partial class CommunicationInfoEntity
    {
    
        public int Id { get; set; }

        public int ContactId { get; set; }

        public int Type { get; set; }    
        [StringLength(50)]
        public string Info { get; set; }
        public virtual ContactEntity Contact { get; set; }
        public virtual ContentTypeEntity ContentType { get; set; }
    }
}
