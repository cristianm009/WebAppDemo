using MediatR;
using WebAppDemos.Application.Models.ResponseModels;

namespace WebAppDemos.Application.Queries
{
    public class GetFileByRequestIdQuery : IRequest<GetFileResponse>
    {
        public string RequestId { get; set; }
        public GetFileByRequestIdQuery(string requestId)
        {
            RequestId = requestId;
        }
    }
}
