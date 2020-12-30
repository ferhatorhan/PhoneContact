using AutoMapper;
using MemoryCache.Testing.Moq;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using PhoneContact.Core.Enums;
using PhoneContact.Core.Helpers;
using PhoneContact.Core.Model.Request;
using PhoneContact.Data.Abstract;
using PhoneContact.Data.Entities;
using PhoneContact.Engine.Abstract;
using PhoneContact.Engine.Models;
using PhoneContact.Engine.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneContact.Test
{
    [TestFixture]
    public class ContactTest
    {
        private Mock<IContactService> _ContactServices;
        private Mock<IGenericRepository<ContactEntity>> _ContactRepository;
        private Mock<IOptions<AppSettings>> _appSetting = new Mock<IOptions<AppSettings>>();
        private IMapper _mapper;
        private IMemoryCache _cache;
        private Mock<ILogger<ContactManager>> _logger;
        [SetUp]
        public void Setup()
        {
            _cache = Create.MockedMemoryCache();
            _ContactServices = new Mock<IContactService>();
            _ContactRepository = new Mock<IGenericRepository<ContactEntity>>();
        }
        [Test]
        public async void AddContact()
        {
            var ContactRepositoryMock = new Mock<IGenericRepository<ContactEntity>>();
            ContactRepositoryMock.Setup(m => m.AddAsync(It.IsAny<ContactEntity>())).Verifiable();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            unitOfWorkMock.Setup(m => m.PersonEntity).Returns(ContactRepositoryMock.Object);
            IContactService ContactService = new ContactManager(unitOfWorkMock.Object, _cache, _logger.va);
            var users = new ContactDTO()
            {
                CompanyName = "Setur",
                SurName = "orhan",
                Name = "ferhat",

            };
            users.CommunicationInfos.Add(new CommunicationInfoDTO()
            {
                Type = new ContentTypeDTO()
                {
                    Id = (int)ContentTypeEnum.Phone
                },
                Content = "5555555"
            });
            users.CommunicationInfos.Add(new CommunicationInfoDTO()
            {
                Type = new ContentTypeDTO()
                {
                    Id = (int)ContentTypeEnum.Email
                },
                Content = "test@test.com"
            });
            users.CommunicationInfos.Add(new CommunicationInfoDTO()
            {
                Type = new ContentTypeDTO()
                {
                    Id = (int)ContentTypeEnum.Location
                },
                Content = "İzmir"
            });
            var actual = ContactService.Add(users);

            ContactRepositoryMock.Verify();
            Assert.AreEqual(actual, 0);
        }
        [Test]
        public async void Update()
        {
            var ContactRepositoryMock = new Mock<IGenericRepository<ContactEntity>>();
            ContactRepositoryMock.Setup(m => m.AddAsync(It.IsAny<ContactEntity>())).Verifiable();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            unitOfWorkMock.Setup(m => m.PersonEntity).Returns(ContactRepositoryMock.Object);
            IContactService ContactService = new ContactManager(unitOfWorkMock.Object, _cache, _logger.va);
            var users = new ContactDTO()
            {
                CompanyName = "Setur",
                SurName = "orhan",
                Name = "ferhat",

            };
            users.CommunicationInfos.Add(new CommunicationInfoDTO()
            {
                Type = new ContentTypeDTO()
                {
                    Id = (int)ContentTypeEnum.Phone
                },
                Content = "55523"
            });
            users.CommunicationInfos.Add(new CommunicationInfoDTO()
            {
                Type = new ContentTypeDTO()
                {
                    Id = (int)ContentTypeEnum.Email
                },
                Content = "test@test.com"
            });
            users.CommunicationInfos.Add(new CommunicationInfoDTO()
            {
                Type = new ContentTypeDTO()
                {
                    Id = (int)ContentTypeEnum.Location
                },
                Content = "İzmir"
            });
            var actual = ContactService.Update(1, users);

            ContactRepositoryMock.Verify();
            Assert.AreEqual(actual, 0);
        }
        [Test]
        public async void UpdateCommunicationInfo()
        {
            var ContactRepositoryMock = new Mock<IGenericRepository<ContactEntity>>();
            ContactRepositoryMock.Setup(m => m.AddAsync(It.IsAny<ContactEntity>())).Verifiable();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            unitOfWorkMock.Setup(m => m.PersonEntity).Returns(ContactRepositoryMock.Object);
            IContactService ContactService = new ContactManager(unitOfWorkMock.Object, _cache, _logger.va);

            var comInfo = new CommunicationRequestModel()
            {

                Type = (int)ContentTypeEnum.Phone,
                UUID = 1,
                Content = "636363"
            };
            var actual = ContactService.AddCommunication(comInfo);
            ContactRepositoryMock.Verify();
            Assert.AreEqual(actual, 0);
        }
    }
}
