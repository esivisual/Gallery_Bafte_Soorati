
using Gallery_Bafte_Soorati.Application.Interfaces.Storages;
using Gallery_Bafte_Soorati.Common;
using Gallery_Bafte_Soorati.Common.Dto;
using Gallery_Bafte_Soorati.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gallery_Bafte_Soorati.Application.Services.Users.Commands.AddUsers
{
    public interface IAddUserService
    {
        ResultDto<ResultUserDto> Execute(UserDto userDto);
    }


    public class AddUserService : IAddUserService
    {
        private readonly IStorage Storage;
        public AddUserService(IStorage _storage)
        {
            Storage = _storage;
        }
        public ResultDto<ResultUserDto> Execute(UserDto userDto)
        {
            if (userDto.Password != userDto.RePassword)
            {
                return new ResultDto<ResultUserDto>
                {
                    Data = new ResultUserDto { UserId = new Guid() },
                    IsSuccess = false,
                    Message = "رمز ورود و تکرار آن همخوانی ندارند",
                };
            }
                        
            string emailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$";
                        
            if (string.IsNullOrWhiteSpace(userDto.Email) || string.IsNullOrWhiteSpace(userDto.Password))
            {
                return new ResultDto<ResultUserDto>
                {
                    Data = new ResultUserDto { UserId = new Guid() },
                    IsSuccess = false,
                    Message = "لطفا اطلاعات را کامل کنید",
                };
            }

            var Match  = Regex.Match(userDto.Email, emailRegex, RegexOptions.IgnoreCase);

            if (!Match.Success)
            {
                return new ResultDto<ResultUserDto>
                {
                    Data = new ResultUserDto { UserId = new Guid() },
                    IsSuccess = false,
                    Message = "لطفا ایمیل خود را به درستی وارد نمایید"
                };
            }

            List<User> emailExist= Storage.Users.Where(f => f.Email == userDto.Email).ToList();

            if (emailExist.Any())
            {
                return new ResultDto<ResultUserDto>
                {
                    Data = new ResultUserDto { UserId = new Guid() },
                    IsSuccess = false,
                    Message = "این ایمیل قبلا ثبت شده است"
                };
            }

            var PasswordHasher = new PasswordHasher ();
            var HashedPassword = PasswordHasher.HashPassword(userDto.Password);

            User user = new()
            {
                Password = HashedPassword,
                Email = userDto.Email,
                Mobile = "",
                NationalCode = "",
                IsActive =true,
            };

            List<UserInRole> userInRole = new();

            foreach (var item in userDto.Roles)
            {
                var Role = Storage.Roles.Where(p => p.Id == item.Id).FirstOrDefault();
                userInRole.Add(new UserInRole
                {
                    User = user,
                    Roles=Role,
                    RolesId=Role.Id,
                    UserId =user.Id,
                });
            }
            
            user.UserInRoles=userInRole;
            Storage.Users.Add(user);
            Storage.SaveChanges();

            return new ResultDto<ResultUserDto>
            {
                Data= new ResultUserDto { UserId =user.Id},
                IsSuccess = true,
                Message = "کاربر جدید ثبت شد",
            };
        }
    }

    public class UserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public List<RoleIdUserDto> Roles { get; set; }
    }

    public class RoleIdUserDto
    {
        public int Id { get; set; }
    }

    public class ResultUserDto
    {
        public Guid UserId { get; set; }
       
    }
}
