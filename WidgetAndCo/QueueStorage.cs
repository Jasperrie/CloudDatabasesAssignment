using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudDatabasesAssignment
{
    public class QueueStorage : IQueueStorage
    {
        private readonly string connectionString;
        private readonly string queueName;
        private CloudStorageAccount storageAccount;
        private CloudQueueClient queueClient;
        private CloudQueue queue;

        public QueueStorage(IConfiguration configuration)
        {
            connectionString = configuration["DefaultEndpointsProtocol=https;AccountName=sspassignment20210925160;AccountKey=KaY9mzIvYy+q7Hj69p35QvwfDoOxbg0L7rAqk0Fe0F1UMHv9BH/ebvudNPQtT4hYJFllMn34HFEhSQmJ1byy7w==;EndpointSuffix=core.windows.net"];
            queueName = configuration["ordersqueue"];

            storageAccount = CloudStorageAccount.Parse(connectionString);
            queueClient = storageAccount.CreateCloudQueueClient();
            queue = queueClient.GetQueueReference(queueName);
        }

        public async Task CreateMessage(string message)
        {
            try
            {
                await queue.CreateIfNotExistsAsync();
            }
            catch (StorageException ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }

            try
            {
                await queue.AddMessageAsync(new CloudQueueMessage(message));
            }
            catch (StorageException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public async Task DeleteMessage()
        {
            CloudQueueMessage message = await queue.GetMessageAsync();
            if (message != null)
            {
                try
                {
                    await queue.DeleteMessageAsync(message);
                }
                catch (StorageException ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }
        }

        public async Task<string> PeekMessage()
        {
            try
            {
                CloudQueueMessage peekedMessage = await queue.PeekMessageAsync();
                if (peekedMessage != null)

                    return peekedMessage.AsString;
            }
            catch (StorageException ex)
            {
                Console.WriteLine(ex.Message.ToString());

            }
            return "Not possible to peek message";
        }
    }
}
