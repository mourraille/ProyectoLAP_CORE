using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public abstract class Person
    {
        public int PERSON_ID { set; get; }
        public string FULLNAME { set; get; }
        public string PASSWORD { set; get; }

        public Person() { }

        public Person(string fullname)
        {
            this.FULLNAME = fullname;
        }

 
        }
    
}
