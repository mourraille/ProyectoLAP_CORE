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
        public Boolean addOrder(string email, String productIDs, double total, string coord) {
            try
            {

                SqlCommand com = new SqlCommand(" SELECT * FROM CLIENT WHERE client.email = @mail", DAOConnection.getConnectionInstance());
                com.Parameters.AddWithValue("@mail", email);
                DAOConnection.getConnectionInstance().Open();
                string id = com.ExecuteScalar() + "";
                DAOConnection.getConnectionInstance().Close();

              


                 com = new SqlCommand("UPDATE [dbo].[CLIENT] SET [ADDRESSS] = @coords WHERE client.person_id = @id", DAOConnection.getConnectionInstance());
                com.Parameters.AddWithValue("@coords",coord);
                com.Parameters.AddWithValue("@id", id);

                DAOConnection.getConnectionInstance().Open();
                com.ExecuteNonQuery();
                DAOConnection.getConnectionInstance().Close();
                com = new SqlCommand("EXECUTE addOrder @PersonID=@id, @Time=@thistime; SELECT * FROM [ORDER] ORDER BY ORDERID DESC", DAOConnection.getConnectionInstance());
                com.Parameters.AddWithValue("@id",id);
                com.Parameters.AddWithValue("@thistime", DateTime.Now);
                DAOConnection.getConnectionInstance().Open();
                String orderid = com.ExecuteScalar()+"";
                DAOConnection.getConnectionInstance().Close();
                List<String> ids = productIDs.Split('_').ToList();
                ids.RemoveAt(ids.Count -1);

                foreach (String code in ids)
                {

                    SqlCommand com2 = new SqlCommand("INSERT INTO Order_Product (ORDERID,PRODUCT_ID) VALUES(@order_id,@prod_id)", DAOConnection.getConnectionInstance());
                    com2.Parameters.AddWithValue("@order_id", orderid);
                    com2.Parameters.AddWithValue("@prod_id",code);
                    DAOConnection.getConnectionInstance().Open();
                    com2.ExecuteNonQuery();
                    DAOConnection.getConnectionInstance().Close();
                    com2 = null;
       
                }
                com = new SqlCommand("UPDATE [ORDER] SET TOTAL =" + total + " WHERE ORDERID ="+orderid+";", DAOConnection.getConnectionInstance());
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


        public List<TOorder> searchOrders() {
            SqlCommand com = new SqlCommand("EXECUTE searchOrder @param=''", DAOConnection.getConnectionInstance());
          
            DAOConnection.getConnectionInstance().Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = com;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            List<TOorder> list = new List<TOorder>();
            DAOConnection.getConnectionInstance().Close();
            foreach (DataRow i in dt.Rows)
            {
                list.Add(new TOorder(i[0].ToString(), int.Parse(i[1].ToString()), DateTime.Parse(i[2].ToString()),i[3].ToString(),i[4].ToString(),i[5].ToString(),i[6].ToString(),double.Parse(i[7].ToString())));
            }

            return list;
        }

    }
}
