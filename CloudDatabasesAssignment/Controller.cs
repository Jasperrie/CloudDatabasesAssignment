using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage;
using System.Net.Http;
using System.Net;
using Microsoft.EntityFrameworkCore.Design;

namespace CloudDatabasesAssignment
{
    public class Controller
    {
        private HttpClient httpClient;
        private WebClient webClient;
        private string connectionString = "DefaultEndpointsProtocol=https;AccountName=sspassignment20210925160;AccountKey=KaY9mzIvYy+q7Hj69p35QvwfDoOxbg0L7rAqk0Fe0F1UMHv9BH/ebvudNPQtT4hYJFllMn34HFEhSQmJ1byy7w==;EndpointSuffix=core.windows.net";

        public CloudStorageAccount CreateStorageAccount()
        {
            CloudStorageAccount storageAccount;
            storageAccount = CloudStorageAccount.Parse(connectionString);
            return storageAccount;
        }
    }
}
