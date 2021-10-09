using Gallery_Bafte_Soorati.Application.Interfaces.Storages;
using Gallery_Bafte_Soorati.Application.Services.Users.Queries.GetUsers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gallery_Bafte_Soorati.Application.Services.Users.MediatR.Queries
{
    public struct GetUser
    {
        public struct Query : IRequest<Response>
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public struct Handler : IRequestHandler<Query, Response>
        {
            private readonly IStorage _storage;
            public Handler(IStorage storage)
            {
                _storage = storage;
            }
            public  async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var CurUser =await  _storage.Users
                    .Include(p => p.UserInRoles)
                    .ThenInclude(p => p.Roles)
                    .Where(p => p.Email == request.Email).FirstOrDefaultAsync(cancellationToken: cancellationToken);

                List<string> UserRoles = new();
                if (CurUser != null)
                {
                    foreach (var item in CurUser.UserInRoles)
                    {
                        UserRoles.Add(item.Roles.Name);
                    }
                    return new Response
                    {
                        Id = CurUser.Id.ToString(),
                        Email = CurUser.Email,
                        Roles = UserRoles,
                        IsSuccess = true,
                    };
                }
                else
                {
                    return new Response
                    {
                        Id = "",
                        Email = "",
                        Roles =new List<string> {""},
                        IsSuccess = false,
                    };
                }
            }
        }
        public struct Response
        {
            public string Id { get; set; }
            public string Email { get; set; }
            public List<string> Roles { get; set; }
            public bool IsSuccess { get; set; }
        }

    }
}

