namespace PhoneContact.Data.EfDbContext
{
    using Microsoft.EntityFrameworkCore;
    using PhoneContact.Data.Entities;
    public partial class PhoneContactContext : DbContext
    {
        public PhoneContactContext(DbContextOptions<PhoneContactContext> options) : base(options)
        {
        }
        public virtual DbSet<ContactEntity> Contact { get; set; }
        public virtual DbSet<ContentTypeEntity> ContentType { get; set; }
        public virtual DbSet<CommunicationInfoEntity> CommunicationInfo { get; set; }
        //public virtual DbSet<UserEntity> Users { get; set; }

    }
}
