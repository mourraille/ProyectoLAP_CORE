using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    public class TOperson
    {
        public int PERSON_ID { set; get; }
        public string FULLNAME { set; get; }
        public string PASSWORD { set; get; }

        public TOperson() { }

        public TOperson(string fullname)
        {
            this.FULLNAME = fullname;
        }
    }
}
