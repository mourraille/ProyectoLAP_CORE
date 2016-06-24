using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;

namespace BL
{
    public class Product
    {
        public int PRODUCT_ID { get; set; }
        public String PRODUCTNAME { get; set; }
        public String DESCRIPTION { get; set; }
        public Double PRICE { get; set; }
        public String IMAGEURI { get; set; }
        public Boolean isoutofstock { get; set; }
        public int category { get; set; }

        public Product(int prodid, string productname, string description, Double price, string image, Boolean isoutofstock, int cat)
        {
            this.PRODUCT_ID = prodid;
            this.PRODUCTNAME = productname;
            this.DESCRIPTION = description;
            this.PRICE = price;
            this.IMAGEURI = image;
            this.isoutofstock = isoutofstock;
            this.category = cat;
        }


        public Product() { }


        public bool addproduct(string productname, string description, double price, string image, Boolean isoutofstoc, int category)
        {
            return new DAOproduct().addProduct(productname, description, price, image, category);
        }

        public bool deleteProduct(int id) {
            return new DAOproduct().deleteProd(id);
        }

        public List<Product> searchProduct(string productname) {
            var list = new DAOproduct().searchProducts(productname);
            var prods = new List<Product>();
            foreach (TOproduct item in list)
            {
                prods.Add(new Product(item.PRODUCT_ID ,item.PRODUCTNAME, item.DESCRIPTION,item.PRICE,item.IMAGEURI,item.isoutofstock,item.category));
            }
            return prods;
        }

        public Boolean updateProduct(int id, string name, string descr, double price, string imageuri, int stock, int cat) 
        {
            return new DAOproduct().updateProduct(id, name, descr, price , imageuri, stock, cat);
             
        }
    }
}


