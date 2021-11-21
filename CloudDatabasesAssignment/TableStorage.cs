using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace CloudDatabasesAssignment
{
    public class TableStorage
    {
        public async Task BuildTable()
        {
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["DefaultEndpointsProtocol=https;AccountName=sspassignment20210925160;AccountKey=KaY9mzIvYy+q7Hj69p35QvwfDoOxbg0L7rAqk0Fe0F1UMHv9BH/ebvudNPQtT4hYJFllMn34HFEhSQmJ1byy7w==;EndpointSuffix=core.windows.net"]);
            CloudTableClient tableClient = cloudStorageAccount.CreateCloudTableClient();

            string tableName = "Products";
            CloudTable cloudTable = tableClient.GetTableReference(tableName);

            await CreateNewTable(cloudTable);
            await InsertRecordToTable(cloudTable);
            await UpdateRecordInTable(cloudTable);
            GetAllProducts(cloudTable);
        }

        public static async Task CreateNewTable(CloudTable table)
        {
            try
            {
                var result = await table.CreateIfNotExistsAsync();
            }
            catch (StorageException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public static async Task InsertRecordToTable(CloudTable table)
        {
            StoreProduct product = new StoreProduct("1", DateTime.Now.ToString(), DateTime.Now.ToString(), "widget123");

            try
            {
                TableOperation tableOperation = TableOperation.Insert(product);
                TableResult result = await table.ExecuteAsync(tableOperation);
                StoreProduct insertedProduct = result.Result as StoreProduct;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }

        private static async Task UpdateRecordInTable(CloudTable table)
        {
            string productId = "1";
            string productName = "widget123";

            StoreProduct productEntity = await RetrieveRecord(table, productId, productName);
            if (productEntity != null)
            {
                productEntity.ID = "123";
                TableOperation tableOperation = TableOperation.Replace(productEntity);
                var result = await table.ExecuteAsync(tableOperation);
            }
        }

        public static async Task DeleteRecordinTable(CloudTable table)
        {
            string productId = "1";
            string productName = "widget123";

            StoreProduct customerEntity = await RetrieveRecord(table, productId , productName);
            if (customerEntity != null)
            {
                TableOperation tableOperation = TableOperation.Delete(customerEntity);
                var result = await table.ExecuteAsync(tableOperation);
            }
        }

        public static async Task<StoreProduct> RetrieveRecord(CloudTable table, string partitionKey, string rowKey)
        {
            TableOperation tableOperation = TableOperation.Retrieve<StoreProduct>(partitionKey, rowKey);
            TableResult tableResult = await table.ExecuteAsync(tableOperation);
            return tableResult.Result as StoreProduct;
        }

        public List<StoreProduct> GetAllProducts(CloudTable cloudTable)
        {
            List<StoreProduct> products = new List<StoreProduct>();

            TableQuery<StoreProduct> query = new TableQuery<StoreProduct>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "1"));

            foreach (StoreProduct product in cloudTable.ExecuteQuerySegmentedAsync(query, null).Result)
            {
                products.Add(product);
            }
            return products;
        }
    }
}
