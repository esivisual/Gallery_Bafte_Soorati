using Gallery_Bafte_Soorati.Application.Interfaces.Storages;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Gallery_Bafte_Soorati.Application.Services.Users.MediatR.Command
{
    public struct AddUser
    {
        public struct Command : IRequest<Response>
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public struct Handler : IRequestHandler<Command, Response>
        {
            private readonly IStorage _storage;
            public Handler(IStorage storage)
            {
                _storage = storage;
            }
            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                var Result = await _storage.Users.AddAsync(new Domain.Entities.Users.User
                {
                    Email = request.Email,
                    Password = request.Password,
                }, cancellationToken);

                await _storage.SaveChangesAsync(cancellationToken);

                return new Response
                {
                    Id = Result.Entity.Id.ToString(),

                    IsSuccess = true,
                };
            }
        }

        public struct Response
        {
            public string Id { get; set; }
            public bool IsSuccess { get; set; }
        }

    }
}
