using Lawyer.Core.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyer.Model
{
    public class Circle : StorageEntity
    {
         public Circle()
        {
            _CircleId = GenerateNewKey();
        }
        private string _CircleId;
        [Key]
        [StringLength(128)]
        public string CircleId
        {
            get { return _CircleId; }
            set { SetValue(ref _CircleId, () => this.CircleId, value); }
        }

    }
}
