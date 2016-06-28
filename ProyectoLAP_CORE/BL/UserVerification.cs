using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BL
{
    public class UserVerification
    {
        public bool verifyPassword(int id, string password)
        {
            return new DAOUserVerification().userVerification(id, password);
        }
    }
}
