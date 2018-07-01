using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class StockDTO
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public DateTime? EntryDate { get; set; }
        public string Unit { get; set; }
        public int ProductEntry { get; set; }
        public int ProduckStock { get; set; }
    }
}
