using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudDatabasesAssignment
{
    public class Review
    {
        [JsonProperty("ID")]
        public string ID { get; set; }
        public string ProductReview { get; set; }
    }
}
