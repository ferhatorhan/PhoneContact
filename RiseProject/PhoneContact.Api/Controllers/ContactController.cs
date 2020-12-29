using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
