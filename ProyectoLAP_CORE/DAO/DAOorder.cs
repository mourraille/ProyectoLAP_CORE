using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;

namespace DAO
{
    public class DAOorder
    {
        public Boolean addOrder(int id, List<TOproduct> products) {
            try
            {
                SqlCommand com = new SqlCommand("EXECUTE addOrder @PersonID=@id, @Time=@thistime; SELECT * FROM [ORDER] ORDER BY ORDERID DESC", DAOConnection.getConnectionInstance());
                com.Parameters.AddWithValue("@id",id);
                com.Parameters.AddWithValue("@thistime", DateTime.Now);
                DAOConnection.getConnectionInstance().Open();
                String orderid = com.ExecuteScalar()+"";
                double total = 0;
                foreach (TOproduct i in products)
                {
                    SqlCommand com2 = new SqlCommand("INSERT INTO Order_Product (ORDERID,PRODUCT_ID) VALUES(@order_id,@prod_id)", DAOConnection.getConnectionInstance());
                    com2.Parameters.AddWithValue("@order_id", orderid);
                    com2.Parameters.AddWithValue("@prod_id", i.PRODUCT_ID);
                    com2.ExecuteNonQuery();
                    com2 = null;
                    total += i.PRICE;
                }
                com = new SqlCommand("UPDATE [ORDER] SET TOTAL =" + total + " WHERE ORDERID ="+orderid+";");
                DAOConnection.getConnectionInstance().Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<TOorder> searchOrders(String orderID) {
            SqlCommand com = new SqlCommand("EXECUTE searchOrder @param=@id", DAOConnection.getConnectionInstance());
            com.Parameters.AddWithValue("@id", orderID);
            DAOConnection.getConnectionInstance().Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = com;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            List<TOorder> list = new List<TOorder>();
            foreach (DataRow i in dt.Rows)
            {
                list.Add(new TOorder(i[0].ToString(),i[1].ToString(),DateTime.Parse(i[2].ToString()),i[3].ToString(),i[4].ToString(),i[5].ToString(),i[6].ToString(),double.Parse(i[7].ToString())));
            }
            return list;
        }

    }
}
