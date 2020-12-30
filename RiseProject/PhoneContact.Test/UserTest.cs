using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using PhoneContact.Core.Helpers;
using PhoneContact.Core.Model.Request;
using PhoneContact.Data.Abstract;
using PhoneContact.Data.Entities;
using PhoneContact.Data.Repository;
using PhoneContact.Engine.Abstract;
using PhoneContact.Engine.Services;

namespace PhoneContact.Test
{
    public class UserTest
    {
        //UserManager : BusinessEngineBase, IUSerServices
        private Mock<IUSerServices> _UsersServices;
        private Mock<IGenericRepository<UserEntity>> _UserRepository;
        private Mock<IOptions<AppSettings>> _appSetting = new Mock<IOptions<AppSettings>>();
        private IMapper _mapper;
        private IMemoryCache _cache;
        private Mock<ILogger<UserManager>> _logger;
        [SetUp]
        public void Setup()
        {
            _UsersServices = new Mock<IUSerServices>();
            _UserRepository = new Mock<IGenericRepository<UserEntity>>();
        }
        [Test]
        public async void AddUser()
        {

            //var testObject = new UserDTO();
            //var expected = new Todo();
            var userRepositoryMock = new Mock<IGenericRepository<UserEntity>>();
            userRepositoryMock.Setup(m => m.AddAsync(It.IsAny<UserEntity>())).Verifiable();

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.UserRepostiyory).Returns(userRepositoryMock.Object);
            IUSerServices todoService = new UserManager(unitOfWorkMock.Object, _appSetting.Object);
            var users= new UserRequestModel()
            {
                UserName = "ferhat",
                Password = "1234",
                LastName = "Orhan",
                Name = "ferhat"
            };
       
            var actual =   todoService.Add(users);
         
            userRepositoryMock.Verify(); 
            Assert.AreEqual(actual, 0); 

        }
        [Test]
        public void GetToken()
        {
            var userRepositoryMock = new Mock<IGenericRepository<UserEntity>>();
            userRepositoryMock.Setup(m => m.AddAsync(It.IsAny<UserEntity>())).Verifiable();

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.UserRepostiyory).Returns(userRepositoryMock.Object);
            IUSerServices todoService = new UserManager(unitOfWorkMock.Object, _appSetting.Object);
            var users = new UserRequestModel()
            {
                UserName = "ferhat",
                Password = "1234",
                LastName = "Orhan",
                Name = "ferhat"
            };

            var actual = todoService.Authenticate("ferhat","1234");

            userRepositoryMock.Verify();
            Assert.AreEqual(actual, 0);
        }
    }
}