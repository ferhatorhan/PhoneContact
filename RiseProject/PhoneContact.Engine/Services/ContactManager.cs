using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PhoneContact.Core.Model.Request;
using PhoneContact.Data.Abstract;
using PhoneContact.Data.Entities;
using PhoneContact.Engine.Abstract;
using PhoneContact.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneContact.Engine.Services
{
    public class ContactManager : BusinessEngineBase, IContactService
    {

        IUnitOfWork _Uow;
        private readonly string CacheKey = "ContactIncludes";
        private Expression<Func<ContactEntity, object>>[] _includes;
        private IEnumerable<ContactEntity> PersonList;
        public ContactManager(IUnitOfWork Uow, IMemoryCache cache, ILogger<CacheManager> logger)
        {
            _Uow = Uow;

        }
        public Task<int> Add(ContactDTO Entity)
        {
            return ExecuteWithExceptionHandledOperation(async () =>
            {
                var dbModel = Mapper.Map<ContactEntity>(Entity);
                var result = await _Uow.PersonEntity.AddAsync(dbModel);
                await _Uow.Commit();
                _cache.TryGetValue(CacheKey, out PersonList);
                if (PersonList != null)
                {
                    var list = PersonList.ToList();
                    list.Add(dbModel);
                    _cache.Set(CacheKey, list.AsEnumerable());
                }
                return dbModel.Id;
            });
        }



        public Task Delete(int Id)
        {
            return ExecuteWithExceptionHandledOperation(async () =>
            {
                var Persons = await _Uow.PersonEntity.GetByIdAsync(Id);
                await _Uow.PersonEntity.DeleteAsync(Persons);
                await _Uow.Commit();
            });
        }

        public Task<List<ContactDTO>> Get()
        {
            return ExecuteWithExceptionHandledOperation(async () =>
            {
                var Persons = await _Uow.PersonEntity.GetAllAsync();
                return Mapper.Map<List<ContactDTO>>(Persons);
            });
        }

        public Task<ContactDTO> GetById(int Id)
        {
            return ExecuteWithExceptionHandledOperation(async () =>
            {
                var Persons = await _Uow.PersonEntity.GetByIdAsync(Id);
                return Mapper.Map<ContactDTO>(Persons);
            });
        }

        public Task<ContactDTO> GetByName(string Name)
        {
            return ExecuteWithExceptionHandledOperation(async () =>
            {
                Expression<Func<ContactEntity, bool>> Contact = (a => a.Name.Contains(Name) || a.Name.Contains(Name));
                var Persons = await _Uow.PersonEntity.SearchByAsync("Asc", false, Contact, _includes);
                return Mapper.Map<ContactDTO>(Persons);
            });
        }

        public Task<ContactDTO> GetByPhone(string PhoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(int Id, ContactDTO Entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddCommunication(CommunicationRequestModel Communication)
        {
            return ExecuteWithExceptionHandledOperation(async () =>
            {
                var Persons = await _Uow.PersonEntity.GetByIdAsync(Communication.UUID);
                var dbmodel = Mapper.Map<CommunicationInfoEntity>(Communication);
                Persons.CommunicationInfo.Add(dbmodel);
                await _Uow.PersonEntity.UpdateAsync(Persons);
                await _Uow.Commit();
                return Persons.Id;
            });
        }

        public Task DeleteCommunication(int Id)
        {
            return ExecuteWithExceptionHandledOperation(async () =>
            {
                await _Uow.CommunicationInfo.DeleteAsync(x => x.Id == Id);
                await _Uow.Commit();
            });
        }

        Task<int> IContactService.DeleteCommunication(int Id)
        {
            return ExecuteWithExceptionHandledOperation(async () =>
            {
                await _Uow.CommunicationInfo.DeleteAsync(o => o.Id == Id);
                await _Uow.Commit();
                return Id;
            });
        }

        public Task<int> UpdateCommunication(CommunicationRequestModel Communication)
        {
            return ExecuteWithExceptionHandledOperation(async () =>
            {
                var dbmodel = Mapper.Map<CommunicationInfoEntity>(Communication);
                await _Uow.CommunicationInfo.UpdateAsync(dbmodel);
                await _Uow.Commit();
                return Communication.id;
            });
        }
    }
}
