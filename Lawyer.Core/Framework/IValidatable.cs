using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyer.Core.Framework
{
    public interface IValidatable : IDataErrorInfo
    {
        void SetError(string propertyName, string errorMessage, bool doNotifyChanges);
        void ClearError(string propertyName);

        bool Validate(bool doNotifyChanges);
    }
}
