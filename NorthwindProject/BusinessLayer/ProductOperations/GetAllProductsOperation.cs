﻿using NorthwindProject.BusinessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProject.BusinessLayer
{
    public class GetAllProductsOperation : EfOperation
    {
        private int _id;

        public GetAllProductsOperation()
        {

        }
        public GetAllProductsOperation(int id)
        {
            _id = id;
        }

        public override OperationResult Execute()
        {
            var query = Context.Products.AsQueryable();

            if (_id != 0)
            {
                query = query.Where(p => p.CategoryID == _id);
            }

            var data = query.Select(p => new ProductDto
            {
                Id = p.ProductID,
                CategoryId = p.CategoryID,
                SupplierId = p.SupplierID,
                Name = p.ProductName,
                CategoryName = p.Category.CategoryName,
                SupplierName = p.Supplier.CompanyName,
              //  Customers = p.Order_Details.Select(od => od.Order.Customer.CompanyName),
                QuantityOrders = p.Order_Details.Any() ? p.Order_Details.Sum(od => od.Quantity) : 0
            });

            return new OperationResult
            {
                Data = data.ToList()
            };
        }
    }
}
