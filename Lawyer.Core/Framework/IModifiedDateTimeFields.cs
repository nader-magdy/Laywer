﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyer.Core.Framework
{
    public interface IModifiedDateTimeFields
    {
        DateTime? LastModified { get; set; }
        DateTime? Created { get; set; }
    }
}
