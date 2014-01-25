using Lawyer.Data;
using Lawyer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyer.Helper
{
    public class UserHelper
    {
        private UserRepository _UserRepository;

        public UserHelper()
        {
            _UserRepository = new UserRepository();
        }

        
        public User FindUser(string userName, string password)
        {
            return _UserRepository.Users.FirstOrDefault(u => u.Username.Equals(userName) && u.Password.Equals(password));
        }
    }
}
