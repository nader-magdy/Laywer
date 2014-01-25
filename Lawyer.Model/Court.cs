using Lawyer.Core.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyer.Model
{
    public class Court : StorageEntity
    {
        public Court()
        {
            _CourtId = GenerateNewKey();
        }
        private string _CourtId;
        [Key]
        [StringLength(128)]
        public string CourtId
        {
            get { return _CourtId; }
            set { SetValue(ref _CourtId, () => this.CourtId, value); }
        }

        private string _CourtName;
        [Display(Name="المحكمة")]
        public string CourtName
        {
            get { return _CourtName; }
            set { SetValue(ref _CourtName, () => this.CourtName, value); }
        }

        private string _Address;
        [Display(Name = "العنوان")]
        public string Address
        {
            get { return _Address; }
            set { SetValue(ref _Address, ()=> this.Address, value ); }
        }

     
    }
}
