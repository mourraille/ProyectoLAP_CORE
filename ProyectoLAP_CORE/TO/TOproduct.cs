using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
   public class TOproduct
    {
        public int PRODUCT_ID { get; set; }
        public String PRODUCTNAME { get; set; }
        public String DESCRIPTION { get; set; }
        public Double PRICE { get; set; }
        public String IMAGEURI { get; set; }
        public Boolean isoutofstock { get; set; }
        public int category { get; set; }

        public TOproduct(int prodid, string productname, string description, Double price, string image, Boolean isoutofstock,int cat)
        {
            this.PRODUCT_ID = prodid;
            this.PRODUCTNAME = productname;
            this.DESCRIPTION = description;
            this.PRICE = price;
            this.IMAGEURI = image;
            this.isoutofstock = isoutofstock;
            this.category = cat;
        }


        public TOproduct() { }
    }

}
