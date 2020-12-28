using PhoneContact.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneContact.Data.Abstract
{
    public interface IUnitOfWork
    {
        IGenericRepository<ContactEntity> PersonEntity { get; }
        IGenericRepository<ContentTypeEntity> ContentType { get; }
        IGenericRepository<CommunicationInfoEntity> CommunicationInfo { get; }
        IGenericRepository<UserEntity> UserRepostiyory { get; }
        Task Commit();
    }
}
