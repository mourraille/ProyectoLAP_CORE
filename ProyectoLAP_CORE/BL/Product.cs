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
        public string category { get; set; }

        public Product(int prodid, string productname, string description, Double price, string image, Boolean isoutofstock, string cat)
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


        public bool addproduct(string productname, string description, double price, string image, Boolean isoutofstoc, string category)
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

        public Product searchProductById(string id)
        {
            var ToProduct = new DAOproduct().searchProductById(id);
            if (ToProduct != null)
            {
               return new Product(ToProduct.PRODUCT_ID, ToProduct.PRODUCTNAME, ToProduct.DESCRIPTION, ToProduct.PRICE, ToProduct.IMAGEURI, ToProduct.isoutofstock, ToProduct.category);
            }
            return null;
        }

        public Boolean updateProduct(int id, string name, string descr, double price, string imageuri, int stock, string cat) 
        {
            return new DAOproduct().updateProduct(id, name, descr, price , imageuri, stock, cat);
        }

        public bool changeState(int id, bool state)
        {
            new DAOproduct().changeProductState(id, state);
            return true;
        }
    }
}


