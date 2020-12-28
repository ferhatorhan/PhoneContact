using PhoneContact.Data.Abstract;
using PhoneContact.Data.EfDbContext;
using PhoneContact.Data.Entities;
using PhoneContact.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneContact.Data.Uow
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly PhoneContactContext _context;
        private IGenericRepository<ContactEntity> _PersonRepository;
        private IGenericRepository<ContentTypeEntity> _ContentTypeRepository;
        private IGenericRepository<CommunicationInfoEntity> _CommunicationInfoRepository;
        private IGenericRepository<UserEntity> _UserRepostiyory;
        public UnitOfWork(PhoneContactContext context)
        {
            _context = context;
        }
        public IGenericRepository<ContactEntity> PersonRepository
        {
            get { return _PersonRepository ?? (_PersonRepository = new GenericRepository<ContactEntity>(_context)); }
        }
        public IGenericRepository<ContentTypeEntity> ContentTypeRepository
        {
            get { return _ContentTypeRepository ?? (_ContentTypeRepository = new GenericRepository<ContentTypeEntity>(_context)); }
        }
        public IGenericRepository<CommunicationInfoEntity> CommunicationInfoRepository
        {
            get { return _CommunicationInfoRepository ?? (_CommunicationInfoRepository = new GenericRepository<CommunicationInfoEntity>(_context)); }
        }

        public IGenericRepository<ContactEntity> PersonEntity
        {
            get { return _PersonRepository ?? (_PersonRepository = new GenericRepository<ContactEntity>(_context)); }

        }

        public IGenericRepository<ContentTypeEntity> ContentType
        {
            get { return _ContentTypeRepository ?? (_ContentTypeRepository = new GenericRepository<ContentTypeEntity>(_context)); }

        }
        public IGenericRepository<CommunicationInfoEntity> CommunicationInfo
        {
            get { return _CommunicationInfoRepository ?? (_CommunicationInfoRepository = new GenericRepository<CommunicationInfoEntity>(_context)); }

        }
        public IGenericRepository<UserEntity> UserRepostiyory
        {
            get { return _UserRepostiyory ?? (_UserRepostiyory = new GenericRepository<UserEntity>(_context)); }

        }
      

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
        public async Task Commit()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync();
                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    _context.Dispose();
                    transaction.Rollback();
                }

            }

        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

       
    }
}
