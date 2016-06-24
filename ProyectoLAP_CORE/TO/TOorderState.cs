using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
public class TOorderState
    {

        public string NAME { get; set; }
        public DateTime TIMEASIGNED { get; set; }
        public int orderStateID { get; set; }

        public TOorderState() { }

        public TOorderState(string NAME, DateTime TIMEASIGNED, int orderStateID)
        {

            this.NAME = NAME;
            this.TIMEASIGNED = TIMEASIGNED;
            this.orderStateID = orderStateID;


        }
    }
}
