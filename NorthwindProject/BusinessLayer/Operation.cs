using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProject.BusinessLayer
{
    public abstract class Operation
    {
        public abstract OperationResult Execute();
    }
}
