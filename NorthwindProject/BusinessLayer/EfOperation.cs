using NorthwindProject.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProject.BusinessLayer
{
    public abstract class EfOperation : Operation
    {
        private NorthwindEntities context = new NorthwindEntities();
        public NorthwindEntities Context => context;
    }
}
