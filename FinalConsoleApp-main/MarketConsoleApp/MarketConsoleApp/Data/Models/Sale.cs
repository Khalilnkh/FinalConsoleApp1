using MarketConsoleApp.Data.Common;
using MarketConsoleApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketConsoleApp.Data.Models
{
    public class Sale:BaseModel
    {
        private static int id = 0;
        public Sale()
        {
          Id= id;
            id++;
        }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public SaleItem SaleItem { get; set; } = null!;
        public Product Product { get; set; } = null!;




    }
}
