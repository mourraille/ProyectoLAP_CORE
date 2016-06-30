using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    public class TOorder
    {
        public string ORDERID { get; set; }
        public int ORDERSTATEID { get; set; }
        public DateTime DATETTIME { get; set; }
        public string FULLNAME { get; set; }
        public string PICTUREURL { get; set; }
        public string ADDRESS { get; set; }
        public string EMAIL { get; set; }
        public Double TOTAL { get; set; }
        public List<TOproduct> TOproducts { get; set; }
        public TOorder() { }

        public TOorder(string oRDERID, int oRDERSTATEID, DateTime dATETTIME, string fULLNAME, string pICTUREURL, string aDDRESS, string eMAIL, double tOTAL)
        {
            ORDERID = oRDERID;
            ORDERSTATEID = oRDERSTATEID;
            DATETTIME = dATETTIME;
            FULLNAME = fULLNAME;
            PICTUREURL = pICTUREURL;
            ADDRESS = aDDRESS;
            EMAIL = eMAIL;
            TOTAL = tOTAL;
        }
    }
}
