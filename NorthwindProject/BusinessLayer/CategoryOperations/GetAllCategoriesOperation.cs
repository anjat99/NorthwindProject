using NorthwindProject.BusinessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProject.BusinessLayer
{
    public class GetAllCategoriesOperation : EfOperation
    {
        public override OperationResult Execute()
        {
            var query = Context.Categories.Select(c => new CategoryDto
            {
                Id = c.CategoryID,
                Name = c.CategoryName
            });

            return new OperationResult
            {
                Data = query.ToList()
            };

        }
    }
}
