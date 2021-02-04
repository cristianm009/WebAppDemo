using MediatR;
using WebAppDemos.Application.Models.ResponseModels;

namespace WebAppDemos.Application.Commands
{
    public class CreateFileCommand : IRequest<CreateFileResponse>
    {
        public string RequestId { get; set; }
        public string ContentType { get; set; }
        public long ContentLength { get; set; }
        public string BlobType { get; set; }
        public string Url { get; set; }
    }
}
