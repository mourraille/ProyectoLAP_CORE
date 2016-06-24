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
    public class DAOorderState
    {
        public List<TOorderState> getOrderStates() {
            SqlCommand com = new SqlCommand("SELECT * FROM ORDERSTATE", DAOConnection.getConnectionInstance());
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            try
            {
                DAOConnection.getConnectionInstance().Open();
                adapter.SelectCommand = com;
                adapter.Fill(dt);
                DAOConnection.getConnectionInstance().Close();
                List<TOorderState> list = new List<TOorderState>();
                foreach (DataRow item in dt.Rows)
                {
                    list.Add(new TOorderState(item[0].ToString(), DateTime.Parse(item[1].ToString()), int.Parse(item[2].ToString())));
                }
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Boolean setOrderTime(int id, DateTime time) {
            SqlCommand com = new SqlCommand("EXECUTE dbo.updateOrderStatus @id = @orderid , @time = @ordertime", DAOConnection.getConnectionInstance());
            com.Parameters.AddWithValue("@orderid", id);
            com.Parameters.AddWithValue("@time", time);
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


    }
}
