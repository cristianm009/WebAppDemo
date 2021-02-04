﻿using MediatR;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;
using WebAppDemos.Application.Commands;
using WebAppDemos.Application.Models;
using WebAppDemos.Application.Models.EntityModels;
using WebAppDemos.Application.Models.ResponseModels;

namespace WebAppDemos.Application.Handlers.Commnads
{

    public class CreateFileHandler : IRequestHandler<CreateFileCommand, CreateFileResponse>
    {
        private readonly IMongoCollection<File> _files;
        public CreateFileHandler(IDatabaseSettings settings)
        {
            var client = new MongoClient(/*settings?.ConnectionString ?? */"mongodb://cosmosdbcmejia:Nkg8mnCI8IZKMR4JFS1hS5bI9v2fjqADsy9NO1ZizFcz4OTVS2IvArYmp5AdSVVV3i9Z3UI0m3fqUY6LhUAS8w==@cosmosdbcmejia.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@cosmosdbcmejia@");
            var database = client.GetDatabase(/*settings?.DatabaseName ?? */"TestDB");
            _files = database.GetCollection<File>(/*settings?.FilesCollectionName ??*/ "Files");
        }
        public async Task<CreateFileResponse> Handle(CreateFileCommand request, CancellationToken cancellationToken)
        {
            CreateFileResponse result = null;
            if (request != null)
            {
                File fileToInsert = new File()
                {
                    BlobType = request.BlobType,
                    ContentLength = request.ContentLength,
                    ContentType = request.ContentType,
                    RequestId = request.RequestId,
                    Url = request.Url
                };
                await _files.InsertOneAsync(fileToInsert);
                result = new CreateFileResponse()
                {
                    ContentType = fileToInsert.ContentType,
                    Url = fileToInsert.Url
                };
            }
            return result;
        }
    }
}
