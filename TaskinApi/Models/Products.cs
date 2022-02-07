using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskinApi
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string PName { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public decimal WholeSalePrice { get; set; }
        public int MinQuantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public byte[] Picture { get; set; }

    }
}
