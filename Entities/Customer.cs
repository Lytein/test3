using System;

namespace StoreManagementBlazorApp.Entities
{
    public class Customer
    {
        public int customer_id { get; set; }
        public string? name { get; set; }
        public string? phone { get; set; }
        public string? email { get; set; }
        public string? address { get; set; }
        public DateTime created_at { get; set; }
    }
}
