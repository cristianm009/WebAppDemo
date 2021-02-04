﻿using MediatR;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebAppDemos.Application.Models;
using WebAppDemos.Application.Models.EntityModels;
using WebAppDemos.Application.Models.ResponseModels;
using WebAppDemos.Application.Queries;

namespace WebAppDemos.Application.Handlers.Queries
{
    public class GetAllFilesHandler : IRequestHandler<GetAllFilesQuery, List<GetFileResponse>>
    {
        private readonly IMongoCollection<File> _files;
        public GetAllFilesHandler(IDatabaseSettings settings)
        {
            var client = new MongoClient(/*settings?.ConnectionString ??*/ "mongodb://cosmosdbcmejia:Nkg8mnCI8IZKMR4JFS1hS5bI9v2fjqADsy9NO1ZizFcz4OTVS2IvArYmp5AdSVVV3i9Z3UI0m3fqUY6LhUAS8w==@cosmosdbcmejia.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@cosmosdbcmejia@");
            var database = client.GetDatabase(/*settings?.DatabaseName ?? */"TestDB");
            _files = database.GetCollection<File>(/*settings?.FilesCollectionName ?? */"Files");
        }
        public async Task<List<GetFileResponse>> Handle(GetAllFilesQuery request, CancellationToken cancellationToken)
        {
            List<GetFileResponse> result = new List<GetFileResponse>();
            var files = await _files.Find(s => true).ToListAsync();
            if (files.Any())
            {
                foreach (File file in files)
                {
                    result.Add(new GetFileResponse()
                    {
                        BlobType = file.BlobType,
                        ContentLength = file.ContentLength,
                        ContentType = file.ContentType,
                        RequestId = file.RequestId,
                        Url = file.Url
                    }
                    );
                }
            }
            return result;
        }
    }
}
