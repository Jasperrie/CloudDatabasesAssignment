using Microsoft.WindowsAzure.Storage;
using System.Net.Http;
using System.Net;

namespace CloudDatabasesAssignment
{
    public static class Controller
    {
        private static string connectionString = "DefaultEndpointsProtocol=https;AccountName=sspassignment20210925160;AccountKey=KaY9mzIvYy+q7Hj69p35QvwfDoOxbg0L7rAqk0Fe0F1UMHv9BH/ebvudNPQtT4hYJFllMn34HFEhSQmJ1byy7w==;EndpointSuffix=core.windows.net";

        public static CloudStorageAccount CreateStorageAccount()
        {
            CloudStorageAccount storageAccount;
            storageAccount = CloudStorageAccount.Parse(connectionString);
            return storageAccount;
        }
    }
}
