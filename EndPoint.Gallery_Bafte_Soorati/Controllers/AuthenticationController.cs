
using Gallery_Bafte_Soorati.Application.Services.Users.Commands.AddUsers;
using Gallery_Bafte_Soorati.Application.Services.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EndPoint.Gallery_Bafte_Soorati.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAddUserService AddUserService;
        private readonly IGetUserService GetUserService;
        public AuthenticationController(IAddUserService  _addUserService, IGetUserService _getUserService)
        {
            AddUserService = _addUserService;
            GetUserService = _getUserService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(UserDto  userDto)
        {

            var SignUpResult = AddUserService.Execute(new UserDto
            {
                Email = userDto.Email,
                Password = userDto.Password,
                RePassword = userDto.RePassword,
                Roles = new List<RoleIdUserDto>
                {
                    new RoleIdUserDto {Id =3},
                },
            });
            

            if (SignUpResult.IsSuccess == true)
            {
                var Claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,SignUpResult.Data.UserId.ToString()),
                    new Claim(ClaimTypes.Email ,userDto.Email),
                    new Claim(ClaimTypes.Role,"Customer"),

                };
                var Identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var Prinspale = new ClaimsPrincipal(Identity);
                var Properties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddDays(2),
                };
                HttpContext.SignInAsync(Prinspale,Properties);
            }

            return Json(SignUpResult);
        }


        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(string Email, string Password)
        {
            var ResultLogin=GetUserService.Execute(Email, Password);
            if (ResultLogin.IsSuccess == true)
            {
                var Claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, ResultLogin.Data.Id.ToString()),
                    new Claim(ClaimTypes.Name, ResultLogin.Data.NationalCode),
                    new Claim(ClaimTypes.Email,Email),
                };
                foreach (var item in ResultLogin.Data.Roles)
                {
                    Claims.Add(new Claim(ClaimTypes.Role, item));
                };
                var Identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var Principale = new ClaimsPrincipal(Identity);
                var Properties = new AuthenticationProperties()
                {
                    IsPersistent =true,
                    ExpiresUtc =DateTime.Now.AddDays(2),
                };

                HttpContext.SignInAsync(Principale, Properties);
               
            }
            return Json(ResultLogin);
        }
    }

}
