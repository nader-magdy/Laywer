using Lawyer.Core.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyer.Model
{
    public class Lawyer : User
    {
        public virtual List<Case> Cases { get; set; }
    }
}
