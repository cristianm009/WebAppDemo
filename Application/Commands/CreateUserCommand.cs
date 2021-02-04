using MediatR;
using WebAppDemos.Application.Models.ResponseModels;

namespace WebAppDemos.Application.Commands
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {
        public string DNIType { get; set; }
        public string DNI { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
