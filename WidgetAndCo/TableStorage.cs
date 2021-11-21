//using Microsoft.WindowsAzure.Storage;
//using Microsoft.WindowsAzure.Storage.Table;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Text;
//using System.Threading.Tasks;
//using CloudDatabasesAssignment;

//namespace CloudDatabasesAssignment
//{
//    public class TableStorage
//    {
//        public async Task BuildTable()
//        {
//            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["DefaultEndpointsProtocol=https;AccountName=sspassignment20210925160;AccountKey=KaY9mzIvYy+q7Hj69p35QvwfDoOxbg0L7rAqk0Fe0F1UMHv9BH/ebvudNPQtT4hYJFllMn34HFEhSQmJ1byy7w==;EndpointSuffix=core.windows.net"]);
//            CloudTableClient tableClient = cloudStorageAccount.CreateCloudTableClient();

//            string tableName = "Products";
//            CloudTable cloudTable = tableClient.GetTableReference(tableName);

//            await CreateNewTable(cloudTable);
//            await InsertRecordToTable(cloudTable);
//            await UpdateRecordInTable(cloudTable);
//            GetAllProducts(cloudTable);
//        }

//        public static async Task CreateNewTable(CloudTable table)
//        {
//            try
//            {
//                var result = await table.CreateIfNotExistsAsync();
//            }
//            catch (StorageException ex)
//            {
//                Console.WriteLine(ex.Message.ToString());
//            }
//        }

//        public static async Task InsertRecordToTable(CloudTable table)
//        {
//            Product product = new Product("1", DateTime.Now.ToString(), DateTime.Now.ToString(), "widget123");

//            try
//            {
//                TableOperation tableOperation = TableOperation.Insert(product);
//                TableResult result = await table.ExecuteAsync(tableOperation);
//                Product insertedProduct = result.Result as Product;
//            }
//            catch (StorageException e)
//            {
//                Console.WriteLine(e.Message.ToString());
//            }
//        }

//        private static async Task UpdateRecordInTable(CloudTable table)
//        {
//            string productId = "1";
//            string productName = "widget123";

//            Product productEntity = await RetrieveRecord(table, productId, productName);
//            if (productEntity != null)
//            {
//                productEntity.ID = "123";
//                TableOperation tableOperation = TableOperation.Replace(productEntity);
//                var result = await table.ExecuteAsync(tableOperation);
//            }
//        }

//        public static async Task DeleteRecordinTable(CloudTable table)
//        {
//            string productId = "1";
//            string productName = "widget123";

//            Product customerEntity = await RetrieveRecord(table, productId , productName);
//            if (customerEntity != null)
//            {
//                TableOperation tableOperation = TableOperation.Delete(customerEntity);
//                var result = await table.ExecuteAsync(tableOperation);
//            }
//        }

//        public static async Task<Product> RetrieveRecord(CloudTable table, string partitionKey, string rowKey)
//        {
//            TableOperation tableOperation = TableOperation.Retrieve<Product>(partitionKey, rowKey);
//            TableResult tableResult = await table.ExecuteAsync(tableOperation);
//            return tableResult.Result as Product;
//        }

//        public List<Product> GetAllProducts(CloudTable cloudTable)
//        {
//            List<Product> products = new List<Product>();

//            TableQuery<Product> query = new TableQuery<Product>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "1"));

//            foreach (Product product in cloudTable.ExecuteQuerySegmentedAsync(query, null).Result)
//            {
//                products.Add(product);
//            }
//            return products;
//        }
//    }
//}
