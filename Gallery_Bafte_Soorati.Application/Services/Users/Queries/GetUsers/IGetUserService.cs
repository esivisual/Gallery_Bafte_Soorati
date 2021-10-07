using Gallery_Bafte_Soorati.Application.Interfaces.Storages;
using Gallery_Bafte_Soorati.Common.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gallery_Bafte_Soorati.Application.Services.Users.Queries.GetUsers
{
    public interface IGetUserService
    {
        ResultDto<ResultUserLogin> Execute(string Email, string Password);
    }


    public class GetUserService : IGetUserService
    {
        private readonly IStorage Storage;
        public GetUserService(IStorage _Storage)
        {
            Storage = _Storage;
        }
        public ResultDto<ResultUserLogin> Execute(string Email, string Password)
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                return new ResultDto<ResultUserLogin>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "لطفا ایمیل و رمز ورود خود را بررسی نمایید",
                };
            }

            var CurUser = Storage.Users
                .Include(p => p.UserInRoles)
                .ThenInclude(p => p.Roles)
                .Where(p => p.Email == Email).SingleOrDefault();

            if (CurUser == null)
            {
                return new ResultDto<ResultUserLogin>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "اطلاعات ورودی صحیح نیست",
                };
            }
            var UserRoles = new List<string>();
            foreach (var item in CurUser.UserInRoles)
            {
                UserRoles.Add(item.Roles.Name);
            };

            return new ResultDto<ResultUserLogin>
            {

                Data = new ResultUserLogin
                {
                    NationalCode = CurUser.NationalCode,
                    Id = CurUser.Id,
                    Roles = UserRoles,
                },
                IsSuccess = true,
                Message = "ورود با موفقیت انجام شد",
            };

        }
    }

    public class ResultUserLogin
    {
        public Guid Id { get; set; }
        public List<string> Roles { get; set; }
        public string NationalCode { get; set; }
    }
}

