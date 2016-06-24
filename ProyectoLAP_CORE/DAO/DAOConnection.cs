using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
   public static class DAOConnection
    {
        private static SqlConnection CON;

        public static SqlConnection getConnectionInstance() {
            if (CON == null)
            {
                CON  = new SqlConnection(DAO.Properties.Settings.Default.ConnectionString);
            }
            return CON;
        }

    }
}
