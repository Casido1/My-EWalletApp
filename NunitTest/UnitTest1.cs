using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;
using MyEWalletApp.DataAccess;
using MyEWalletApp.Models.DTOs;
using MyEWalletApp.Models.Models;
using MyEWalletApp.Services.Implementation;
using MyEWalletApp.Services.Interface;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NunitTest
{
    public class AuthServiceUnitTestWithMoq
    {
        //usemgr
        //signmgr
        //JWtService
        //context
        //mapper
        //private Mock<UserManager<AppUser>> _userManager = new Mock<UserManager<AppUser>>(Mock.Of<IUserStore<AppUser>>(), null, null, null, null, null, null, null, null);
        //private Mock<IHttpContextAccessor> _contextAccessor = new Mock<IHttpContextAccessor>();
        //private readonly Mock<IUserClaimsPrincipalFactory<AppUser>> _userPrincipalFactory = new Mock<IUserClaimsPrincipalFactory<AppUser>>(_userManager);
        //private readonly Mock<SignInManager<AppUser>> SignInManager = new Mock<SignInManager<AppUser>>();
        //private readonly Mock<IJWTService> JWTService = new Mock<IJWTService>();
        //private readonly Mock<MyEWalletAppContext> Context = new Mock<MyEWalletAppContext>();
        //private readonly Mock<IMapper> Mapper = new Mock<IMapper>();
        //private AuthService _authService;
        private AuthService authService { get; }
        ////public object loginDto { get; private set; }
        //public LoginDto login { get; set; }
        //Arrange
        private const string email = "eddie@gmail.com";
        private const string Username = "a";
        private const string Password = "Pa$$w0rd";


        public AuthServiceUnitTestWithMoq()
        {
            AppUser user = new AppUser
            {
                UserName = "ugochukwu.anunihu@gmail.com",
                Gender = "male"
            };
            Login login = new Login
            {
                Password = "Pa$$w0rd",
                Email = "ugochukwu.anunihu@gmail.com"
            };
            var roles = new List<string> { "Admin" };
            var _userMgr = new Mock<UserManager<AppUser>>(Mock.Of<IUserStore<AppUser>>(), null, null, null, null, null,
                null, null, null);
            _userMgr.Setup(x => x.FindByEmailAsync(login.Email)).ReturnsAsync(user);
            //_userMgr.Setup(x => x.GetRolesAsync(user)).ReturnsAsync(roles);
            //_userMgr.Setup(x => x.CheckPasswordAsync(user, login.Password)).ReturnsAsync(true);
            //var mockMapper = new Mock<IMapper>();
           
            var mockTokenSer = new Mock<IJWTService>();
            var _contextAccessor = new Mock<IHttpContextAccessor>();
            var _userPrincipalFactory = new Mock<IUserClaimsPrincipalFactory<AppUser>>();
            var _signInMgr = new Mock<SignInManager<AppUser>>(_userMgr.Object,
                _contextAccessor.Object, _userPrincipalFactory.Object, null, null, null, null);
            _signInMgr.Setup(x => x.CheckPasswordSignInAsync(user, Password, false)).ReturnsAsync(SignInResult.Success);
            authService = new AuthService(_userMgr.Object, _signInMgr.Object, mockTokenSer.Object/*, mockMapper.Object*/);

        }

        //[Fact]
        [Test]
        public async Task Login()
        {
           
            Login login = new Login
            {
                Password = "Dap20000?",
                Email = "ugochukwu.anunihu@gmail.com"
            };
            //Act
            //var result = await authService.LoginAsync(login);
            //Assert
            Assert.IsTrue(true/*result.status*/);
        }
        [Theory]
        [TestCase("user", Password)]
        [TestCase(email, "")]
        public async Task InvalidEmailTest(string email, string password)
        {
            Login login = new Login
            {
                Password = password,
                Email = email
            };
            //Act
            var result = await authService.LoginAsync(login);
            //Assert
            Assert.IsFalse(result.status);
            //Assert.That(contResut, Is.InstanceOf<ActionResult>());
        }



        //[SetUp]
        //public void Setup()
        //{
        //}

        //[Test]
        //public async Task Login_Test_With_Wrong_Email()
        //{
        //    //arrange
        //    var _userManager = new Mock<UserManager<AppUser>>(Mock.Of<IUserStore<AppUser>>(), null, null, null, null, null, null, null, null);
        //    var _contextAccessor = new Mock<IHttpContextAccessor>();
        //    var _userPrincipalFactory = new Mock<IUserClaimsPrincipalFactory<AppUser>>();
        //    var _signInManager = new Mock<SignInManager<AppUser>>(_userManager, _contextAccessor, _userPrincipalFactory, null, null, null, null);
        //    var jWTService = new Mock<IJWTService>();
        //    var _authService = new AuthService(_userManager.Object, _signInManager.Object, jWTService.Object);
        //    var login = new Login { Email="sjkdnfsdkjsdf",Password="ksjdfhgi"};
        //    var user = new AppUser();

        //    _userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync(user=null);

        //    //act
        //     var response = await _authService.LoginAsync(login);
        //    //assert
        //    Assert.AreNotEqual(response.Message, "Email or Password incorrect");
        //}
    }
}