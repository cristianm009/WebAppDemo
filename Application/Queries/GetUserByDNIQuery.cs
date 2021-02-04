using MediatR;
using WebAppDemos.Application.Models.ResponseModels;

namespace WebAppDemos.Application.Queries
{
    public class GetUserByDNIQuery : IRequest<GetUserResponse>
    {
        public string DNI { get; set; }
        public GetUserByDNIQuery(string dni)
        {
            DNI = dni;
        }
    }
}
