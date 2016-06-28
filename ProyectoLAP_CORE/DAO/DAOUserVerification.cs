using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TO;

namespace DAO
{
    public class DAOUserVerification
    {
       
        public bool userVerification(int id, string password)
        {
            SqlCommand command = new SqlCommand("LoginUsuario", DAOConnection.getConnectionInstance());
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@PersonId", id);
            command.Parameters.AddWithValue("@Password", password);


            SqlParameter sqlParam = new SqlParameter("@Result", DbType.Boolean);
            sqlParam.Direction = ParameterDirection.Output;
            command.Parameters.Add(sqlParam);

            DAOConnection.getConnectionInstance().Open();
            command.ExecuteNonQuery();
            DAOConnection.getConnectionInstance().Close();
            return int.Parse(command.Parameters["@Result"].Value.ToString()) == 1 ? true : false;
        }
    }
}
