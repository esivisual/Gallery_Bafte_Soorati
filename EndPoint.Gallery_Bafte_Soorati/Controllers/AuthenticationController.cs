using System;
using MediatR;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Gallery_Bafte_Soorati.Application.Services.Users.Commands.AddUsers;
using static Gallery_Bafte_Soorati.Application.Services.Users.MediatR.Command.AddUser;
using static Gallery_Bafte_Soorati.Application.Services.Users.MediatR.Queries.GetUser;

namespace EndPoint.Gallery_Bafte_Soorati.Controllers
{
    public class AuthenticationController : Controller
    {
        //private readonly IAddUserService AddUserService;
        //private readonly IGetUserService GetUserService;

        private readonly IMediator _mediator;
        public AuthenticationController(IMediator mediator)
        {
            //AddUserService = _addUserService;
            //GetUserService = _getUserService;
            _mediator = mediator;
            
        }

        public IActionResult Index() => View();
        public IActionResult SignUp() => View();

        [HttpPost]
        public async Task<IActionResult> SignUp(UserDto userDto)
        {
            var SignUpResult = await _mediator.Send(new Command
            {
                Email = userDto.Email,
                Password = userDto.Password,

            });

            /* var SignUpResult = AddUserService.Execute(new UserDto
            {
                Email = userDto.Email,
                Password = userDto.Password,
                RePassword = userDto.RePassword,
                Roles = new List<RoleIdUserDto>
                {
                    new RoleIdUserDto {Id =3},
                },
            });*/


            if (SignUpResult.IsSuccess == true)
            {
                var Claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,SignUpResult.Id),
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

                await HttpContext.SignInAsync(Prinspale, Properties);

            }

            return Json(SignUpResult);
        }


        public IActionResult SignIn() => View();

        [HttpPost]
        public async Task<IActionResult> SignIn(string Email, string Password)
        {
            var ResultLogin = await _mediator.Send(new Query
            {
                Email = Email,
                Password = Password,
            });

            //GetUserService.Execute(Email, Password);
            if (ResultLogin.IsSuccess == true)
            {
                var Claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, ResultLogin.Id.ToString()),
                    new Claim(ClaimTypes.Name, ResultLogin.Email),
                    new Claim(ClaimTypes.Email,Email),
                };
                foreach (var item in ResultLogin.Roles)
                {
                    Claims.Add(new Claim(ClaimTypes.Role, item));
                };
                var Identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var Principale = new ClaimsPrincipal(Identity);
                var Properties = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddDays(2),
                };

                await HttpContext.SignInAsync(Principale, Properties);

            }
            return Json(ResultLogin);
        }
    }

}
