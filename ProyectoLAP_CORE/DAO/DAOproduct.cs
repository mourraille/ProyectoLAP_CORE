using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TO;
using System.Data;

namespace DAO
{
  public  class DAOproduct
    {

        public Boolean addProduct(string productname, string description, Double price, string image, string category) {
            try
            {
                SqlCommand com = new SqlCommand("EXECUTE  [dbo].[addProduct] @name,@descr,@price,@category,@image", DAOConnection.getConnectionInstance());
                com.Parameters.AddWithValue("@name", productname);
                com.Parameters.AddWithValue("@descr", description);
                com.Parameters.AddWithValue("@price", price);
                com.Parameters.AddWithValue("@image", image);
                com.Parameters.AddWithValue("@category", category);


                DAOConnection.getConnectionInstance().Open();
                com.ExecuteNonQuery();
                DAOConnection.getConnectionInstance().Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<TOproduct> searchProducts(String name) {
            SqlCommand com = new SqlCommand("searchProduct", DAOConnection.getConnectionInstance());
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@param", name);
            try
            {
                DataTable dt = new DataTable();
                DAOConnection.getConnectionInstance().Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = com;
                adapter.Fill(dt);
                DAOConnection.getConnectionInstance().Close();
                List<TOproduct> list = new List<TOproduct>();
                foreach (DataRow item in dt.Rows)
                { var stock = bool.Parse(item[5].ToString());
                    list.Add(new TOproduct(int.Parse(item[0].ToString()), item[1].ToString(), item[2].ToString(), double.Parse(item[3].ToString()), item[4].ToString(), stock, item[6].ToString()));
                }
                return list;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public TOproduct searchProductById(string id)
        {
            SqlCommand com = new SqlCommand("searchProductById", DAOConnection.getConnectionInstance());
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@param", id);
            try
            {
                DAOConnection.getConnectionInstance().Open();
                SqlDataReader reader;
                

                reader = com.ExecuteReader();
                TOproduct platillo = null;

                if (reader.Read())
                {
                    platillo = new TOproduct
                    {
                        PRODUCT_ID = int.Parse(reader["PRODUCT_ID"].ToString()),
                        PRODUCTNAME = reader["PRODUCTNAME"].ToString(),
                        DESCRIPTION = reader["DESCRIPTION"].ToString(),
                        PRICE = double.Parse(reader["PRICE"].ToString()),
                        IMAGEURI = reader["IMAGEURI"].ToString(),
                        isoutofstock = bool.Parse(reader["ISOUTOFSTOCK"].ToString()),
                        category = reader["CATEGORY"].ToString()
                    };
                }
                DAOConnection.getConnectionInstance().Close();
                return platillo;
            }
            catch (Exception)
            {
                return null;
            }

        }


        public Boolean updateProduct(int id, string name, string descr, double price, string imageuri, int stock , string cat) {
            try
            {

                SqlCommand com = new SqlCommand("EXECUTE  [dbo].[updateProduct] @id = @prodid, @name = @prodname "+
                    ", @description =@proddescr , @price =@prodprice , @imageuri = @prodimage ,"+
                    " @isoutofstock = @prodstock, @category = @prodcat" , DAOConnection.getConnectionInstance());

                com.Parameters.AddWithValue("@prodid",id);
                com.Parameters.AddWithValue("@prodname", name);
                com.Parameters.AddWithValue("@proddescr", descr);
                com.Parameters.AddWithValue("@prodprice", price);
                com.Parameters.AddWithValue("@prodimage", imageuri);
                com.Parameters.AddWithValue("@prodstock", stock);
                com.Parameters.AddWithValue("@prodcat", cat);
                DAOConnection.getConnectionInstance().Open();
                com.ExecuteNonQuery();

                DAOConnection.getConnectionInstance().Close();
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public Boolean deleteProd(int id) {
            SqlCommand com = new SqlCommand("DELETE FROM PRODUCT WHERE PRODUCT.PRODUCT_ID = @ID;", DAOConnection.getConnectionInstance());
            com.Parameters.AddWithValue("@ID", id);
            try
            {
                DAOConnection.getConnectionInstance().Open();
                com.ExecuteNonQuery();
                DAOConnection.getConnectionInstance().Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean changeProductState(int id, bool stock)
        {
            try
            {
                SqlCommand com = new SqlCommand("EXECUTE  [dbo].[ChangeProductState] @id = @prodid, @bool = @prodstock", DAOConnection.getConnectionInstance());

                com.Parameters.AddWithValue("@prodid", id);
                com.Parameters.AddWithValue("@prodstock", stock);
                DAOConnection.getConnectionInstance().Open();
                com.ExecuteNonQuery();

                DAOConnection.getConnectionInstance().Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
