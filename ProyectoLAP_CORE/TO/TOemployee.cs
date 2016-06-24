using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    public class TOemployee: TOperson
    {
        public string USERNAME { set; get; }
        public Boolean isADMIN { get; set; }

        public TOemployee(string username, string password, string fullname)
        {
            this.FULLNAME = fullname;
            this.USERNAME = username;
            this.PASSWORD = password;
        }

        public TOemployee(string username, bool isadmin , string fullname)
        {
            this.FULLNAME = fullname;
            this.USERNAME = username;
            this.isADMIN = isadmin;
        }

        public TOemployee() { }
        public override string ToString()
        {
            return this.FULLNAME;
        }
    }

    
}
