using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneContact.Data.Entities
{
    [Table("Contact")]
    public class ContactEntity
    {
         public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string SurName { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        public virtual ICollection<CommunicationInfoEntity> CommunicationInfo { get; set; }
    }

    public class ContactEntityConfiguration : IEntityTypeConfiguration<ContactEntity>
    {
        public void Configure(EntityTypeBuilder<ContactEntity> builder)
        {
            builder.HasMany(e => e.CommunicationInfo)
            .WithOne(o => o.Contact)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        }
    }


}
