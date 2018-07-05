using System;

namespace Entities
{
    public class Stock
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public DateTime? EntryDate { get; set; }
        public string Unit { get; set; }
        public int ProductEntry { get; set; }
        public int ProductStock { get; set; }
    }
}
