using System;

namespace sample_api_app_key.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public decimal PayRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}