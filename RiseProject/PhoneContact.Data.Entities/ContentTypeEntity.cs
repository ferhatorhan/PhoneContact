using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhoneContact.Data.Entities
{
    [Table("ContentType")]
    public partial class ContentTypeEntity
    {
        public int ID { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public virtual ICollection<CommunicationInfoEntity> CommunicationInfo { get; set; }
    }
    public class ContentTypeEntityConfiguration : IEntityTypeConfiguration<ContentTypeEntity>
    {
        public void Configure(EntityTypeBuilder<ContentTypeEntity> builder)
        {
            builder.HasMany(e => e.CommunicationInfo)
                  .WithOne(e => e.ContentType)
                  .HasForeignKey(e => e.Type)
                  .OnDelete(DeleteBehavior.Restrict)
                  .IsRequired();
        }
    }
}
