using CloudDatabasesAssignment;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WidgetAndCo
{
    public static class Blob
    {
        private const string BlobContainer = "images";

        public static async Task BlobOperationsAsync()
        {
            const string ImageToUpload = "../../../widget.png";

            CloudStorageAccount storageAccount = Controller.CreateStorageAccount();

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference(BlobContainer);

            try
            {
                BlobRequestOptions optionsWithRetryPolicy = new BlobRequestOptions() { RetryPolicy = new LinearRetry(TimeSpan.FromSeconds(20), 4) };

                await container.CreateIfNotExistsAsync(optionsWithRetryPolicy, null);
            }
            catch (StorageException ex)
            {
                Console.WriteLine(ex.Message);
            }

            await container.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(ImageToUpload);

            blockBlob.Properties.ContentType = "image/png";

            try
            {
                await blockBlob.UploadFromFileAsync(ImageToUpload);
            }
            catch (StorageException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
