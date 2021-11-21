using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudDatabasesAssignment
{
    public class Product : TableEntity
    {
        [JsonProperty("ID")]
        public string ID { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public Review Review { get; set; }

        public Product()
        {

        }

        public Product(string Id, string Created_at, string Updated_at, string Name)
        {
            this.ID = Id;
            this.Created_at = Created_at;
            this.Updated_at = Updated_at;
            this.Name = Name;

            PartitionKey = Id;
            RowKey = Name;
        }
    }
}
