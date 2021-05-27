using NorthwindProject.BusinessLayer.DTO;
using NorthwindProject.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProject.BusinessLayer
{
    public class InsertProductOperation : EfOperation
    {
        private InsertProductDto _dto;

        public InsertProductOperation(InsertProductDto dto)
        {
            
            _dto = dto;
        }

        public override OperationResult Execute()
        {
            Context.Products.Add(new Product
            {
                ProductName = _dto.Name,
                CategoryID = _dto.CategoryId,
                SupplierID = _dto.SupplierId,
                Discontinued = _dto.Discountinued
            });

            Context.SaveChanges();

            return new OperationResult();
        }
    }
}
