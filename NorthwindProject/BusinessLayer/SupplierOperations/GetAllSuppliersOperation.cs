using NorthwindProject.BusinessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProject.BusinessLayer
{
    public class GetAllSuppliersOperation : EfOperation
    {
        public override OperationResult Execute()
        {
            var query = Context.Suppliers.Select(s => new SupplierDto
            {
                Id = s.SupplierID,
                Name = s.CompanyName
            });

            return new OperationResult
            {
                Data = query.ToList()
            };
        }
    }
}
