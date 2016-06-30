using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;

namespace BL
{
   public class Order
    {
        public string ORDERID { get; set; }
        public int ORDERSTATEID { get; set; }
        public DateTime DATETTIME { get; set; }
        public string FULLNAME { get; set; }
        public string PICTUREURL { get; set; }
        public string ADDRESS { get; set; }
        public string EMAIL { get; set; }
        public Double TOTAL { get; set; }
    

        public Order() { }

        public Order(string oRDERID, int oRDERSTATEID, DateTime dATETTIME, string fULLNAME, string pICTUREURL, string aDDRESS, string eMAIL, double tOTAL)
        {
            ORDERID = oRDERID;
            this.ORDERSTATEID = oRDERSTATEID;
            DATETTIME = dATETTIME;
            FULLNAME = fULLNAME;
            PICTUREURL = pICTUREURL;
            ADDRESS = aDDRESS;
            EMAIL = eMAIL;
            TOTAL = tOTAL;
        }

        public Boolean addOrder(String email, string prods, double total, string coord) {
          
            return new DAOorder().addOrder(email,prods,total,coord);
        }

        public List<Order> searchOrders() {
            List<TOorder> toList = new DAOorder().searchOrders();
            List<Order> orders = new List<Order>();
            foreach (TOorder o in toList)
            {
                
                orders.Add(new Order(o.ORDERID, o.ORDERSTATEID, o.DATETTIME, o.FULLNAME, o.PICTUREURL, o.ADDRESS, o.EMAIL, o.TOTAL));
            }
            return orders;
        }
    }
}
