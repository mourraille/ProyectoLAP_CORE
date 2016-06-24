using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAO
{
    public class DAOperson
    {
        public int PERSON_ID { set; get; }
        public string FULLNAME { set; get; }
        public string PASSWORD { set; get; }

        public DAOperson() { }

        public DAOperson(string fullname)
        {
            this.FULLNAME = fullname;
        }
    }

}
