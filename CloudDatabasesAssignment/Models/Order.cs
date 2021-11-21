using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudDatabasesAssignment
{
    public class Order
    {
        [JsonProperty("ID")]
        public string ID { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public StoreProduct Product { get; set; }
    }
}
