using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProject.BusinessLayer.DTO
{
    public class ProductDto : Dto
    {
        public int Id { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public string SupplierName { get; set; }
        public string CategoryName { get; set; }
       // public IEnumerable<string> Customers { get; set; }
        public int QuantityOrders { get; set; }
    }
}
