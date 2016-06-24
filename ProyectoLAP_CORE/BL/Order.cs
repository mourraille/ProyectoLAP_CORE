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
        public string ORDERSTATEID { get; set; }
        public DateTime DATETTIME { get; set; }
        public string FULLNAME { get; set; }
        public string PICTUREURL { get; set; }
        public string ADDRESS { get; set; }
        public string EMAIL { get; set; }
        public Double TOTAL { get; set; }
        public List<Product> PRODUCTS { get; set;}

        public Order() { }

        public Order(string oRDERID, string oRDERSTATEID, DateTime dATETTIME, string fULLNAME, string pICTUREURL, string aDDRESS, string eMAIL, double tOTAL)
        {
            ORDERID = oRDERID;
            DATETTIME = dATETTIME;
            FULLNAME = fULLNAME;
            PICTUREURL = pICTUREURL;
            ADDRESS = aDDRESS;
            EMAIL = eMAIL;
            TOTAL = tOTAL;
        }

        public Boolean addOrder(int id, List<Product> prods) {
            List<TOproduct> toprods = new List<TOproduct>();
            foreach (Product r in prods)
            {
                toprods.Add(new TOproduct(r.PRODUCT_ID, r.PRODUCTNAME, r.DESCRIPTION, r.PRICE, r.IMAGEURI, r.isoutofstock, r.category));
            }
            return new DAOorder().addOrder(id,toprods);
        }

        public List<Order> searchOrders(string id) {
            List<TOorder> toList = new DAOorder().searchOrders(id);
            List<Order> orders = new List<Order>();
            foreach (TOorder o in toList)
            {
                orders.Add(new Order(o.ORDERID, o.ORDERSTATEID, o.DATETTIME, o.FULLNAME, o.PICTUREURL, o.ADDRESS, o.EMAIL, o.TOTAL));
            }
            return orders;
        }
    }
}
