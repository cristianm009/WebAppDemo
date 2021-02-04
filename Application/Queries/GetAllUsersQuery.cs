using MediatR;
using System.Collections.Generic;
using WebAppDemos.Application.Models.ResponseModels;

namespace WebAppDemos.Application.Queries
{
    public class GetAllUsersQuery : IRequest<List<GetUserResponse>>
    {
    }
}
