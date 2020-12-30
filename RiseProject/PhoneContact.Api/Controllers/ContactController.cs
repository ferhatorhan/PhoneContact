using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneContact.Core.Model.Request;
using PhoneContact.Engine.Abstract;
using PhoneContact.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneContact.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpPost]
        public Task<int> Post([FromBody] ContactDTO contact)
        {
            return _contactService.Add(contact);
        }
        [HttpGet]
        public Task<List<ContactDTO>> Get()
        {
            return _contactService.Get();
        }
        [HttpGet]
        public Task<ContactDTO> Get(int id)
        {
            return _contactService.GetById(id);
        }
        [HttpPost]
        public Task<int> AddCommunication([FromBody] CommunicationRequestModel requestModel)
        {
            return _contactService.AddCommunication(requestModel);
        }
        [HttpPost]
        public Task<int> UpdateComInfo([FromBody] CommunicationRequestModel requestModel)
        {
            return _contactService.UpdateCommunication(requestModel);
        }
        [HttpDelete]
        public Task<int> DeleteComInfo(int id)
        {
            return _contactService.DeleteCommunication(id);
        }
        [HttpDelete]
        public Task Delete(int Id)
        {
            return _contactService.Delete(Id);
        }
    }
}
