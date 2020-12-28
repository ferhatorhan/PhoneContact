using PhoneContact.Engine.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneContact.Engine.Abstract
{
    public interface IContactService
    {
        Task<int> Add(ContactDTO Entity);
        Task<int> AddCommunication(int Id, CommunicationInfoDTO Communication);
        Task<int> Update(int Id, ContactDTO Entity);
        Task Delete(int Id);
        Task<List<ContactDTO>> Get();
        Task<ContactDTO> GetById(int Id);
        Task<ContactDTO> GetByPhone(string PhoneNumber);
        Task<ContactDTO> GetByName(string Name);
    }
}
