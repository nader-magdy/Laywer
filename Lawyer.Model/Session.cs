using Lawyer.Core.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyer.Model
{
    public class Session : StorageEntity
    {
        public Session()
        {
            _SessionId = GenerateNewKey();
        }
        private string _SessionId;
        [Key]
        [StringLength(128)]
        public string SessionId
        {
            get { return _SessionId; }
            set {
                SetValue(ref _SessionId, () => this.SessionId, value);
            }
        }

    }
}
