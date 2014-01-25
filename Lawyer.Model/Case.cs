using Lawyer.Core.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyer.Model
{
    public class Case : StorageEntity
    {
        public Case()
        {
            _CaseId = GenerateNewKey();
        }


        private string _CaseId;
        [Key]
        [StringLength(128)]
        public string CaseId
        {
            get { return _CaseId; }
            set { SetValue(ref _CaseId, () => this.CaseId, value); }
        }

        private string _CaseNumber;
        [StringLength(64)]
        [Required]
        public string CaseNumber
        {
            get { return _CaseNumber; }
            set { SetValue(ref _CaseNumber, () => this.CaseNumber, value); }
        }

        private string _CircleId;
        [StringLength(128)]
        public string CircleId
        {
            get { return _CircleId; }
            set { SetValue(ref _CircleId, () => this.CircleId, value); }
        }


        [ForeignKey("CircleId")]
        public Circle Circle
        {
            get;
            set;
        }

        public virtual List<Session> Sessions
        {
            get;
            set;
        }
    }
}
