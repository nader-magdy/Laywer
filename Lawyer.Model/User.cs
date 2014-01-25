using Lawyer.Core.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lawyer.Model
{
    public class User : StorageEntity
    {
        public User()
        {
            _UserId = GenerateNewKey();
            Created = DateTime.UtcNow;
        }

        private string _UserId;

        [Key]
        [StringLength(128, ErrorMessage = "Only 128 characters allowed.")]
        public string UserId
        {
            get { return _UserId; }
            set { SetValue(ref _UserId, () => this.UserId, value); }
        }


        private string _Name;

        [StringLength(128, ErrorMessage = "Only 128 characters allowed.")]
        public string Name
        {
            get { return _Name; }
            set { SetValue(ref _Name, () => this.Name, value); }
        }


        private string _Username;

        [StringLength(128, ErrorMessage = "Only 128 characters allowed.")]
        public string Username
        {
            get { return _Username; }
            set { SetValue(ref _Username, () => this.Username, value); }
        }

        private string _Password;

        [StringLength(128, ErrorMessage = "Only 128 characters allowed.")]
        [DataType(DataType.Password)]
        public string Password
        {
            get { return _Password; }
            set { SetValue(ref _Password, () => this.Password, value); }
        }
    }
}
