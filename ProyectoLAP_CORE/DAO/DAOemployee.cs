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

    public class DAOemployee : DAOperson
    {

        public string USERNAME { set; get; }
        public Boolean isADMIN { get; set; }

        public DAOemployee(string username, string password, string fullname)
        {
            this.FULLNAME = fullname;
            this.USERNAME = username;
            this.PASSWORD = password;
        }
        public DAOemployee() { }

        public Boolean addEmployee(string fullname, string password, string username, Boolean isadmin)
        {
            String query;
            if (isadmin)
                query = "EXECUTE dbo.addEmployee @fullName=@FULLNAME, @pass=@PASS, @username=@USERNAME, @isadmin='1'";
            else
                query = "EXECUTE dbo.addEmployee @fullName=@FULLNAME, @pass=@PASS, @username=@USERNAME";

            SqlCommand com = new SqlCommand(query, DAOConnection.getConnectionInstance());
            com.Parameters.AddWithValue("@FULLNAME", fullname);
            com.Parameters.AddWithValue("@PASS", password);
            com.Parameters.AddWithValue("@USERNAME", username);

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

        public Boolean deleteEmployee(string username)
        {
            try
            {
                SqlCommand com = new SqlCommand("DELETE FROM PERSON WHERE PERSON.PERSON_ID = (SELECT EMPLOYEE.PERSON_ID FROM EMPLOYEE WHERE EMPLOYEE.USERNAME=@username);", DAOConnection.getConnectionInstance());
                com.Parameters.AddWithValue("@username", username);
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

        public Boolean updateEmployee(string fullname, string password, string username, Boolean isadmin)
        {
            try
            {
                SqlCommand com = new SqlCommand("UPDATE PERSON SET FULLNAME =@fullname, [PERSON].[PASSWORD] = @pass WHERE person.PERSON_ID = (SELECT EMPLOYEE.PERSON_ID FROM EMPLOYEE WHERE EMPLOYEE.USERNAME = @username);UPDATE EMPLOYEE SET EMPLOYEE.ISADMINISTRATOR = @isadmin where EMPLOYEE.USERNAME = @username;", DAOConnection.getConnectionInstance());
                com.Parameters.AddWithValue("@fullname", fullname);
                com.Parameters.AddWithValue("@pass", password);
                com.Parameters.AddWithValue("@username", username);
                com.Parameters.AddWithValue("@isadmin", isadmin);

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

        public Boolean deletePerson(string personid) {
            SqlCommand com = new SqlCommand("DELETE FROM PERSON WHERE PERSON.PERSON_ID=@param",DAOConnection.getConnectionInstance());
            com.Parameters.AddWithValue("@param", personid);
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

        public List<TOemployee> searchEmployee(string filter)
        {

            try
            {
                SqlCommand com = new SqlCommand("select EMPLOYEE.USERNAME , EMPLOYEE.ISADMINISTRATOR, person.FULLNAME, person.PERSON_ID, person.Password from EMPLOYEE join PERSON on EMPLOYEE.PERSON_ID = PERSON.PERSON_ID WHERE person.FULLNAME like '" + filter + "%' or EMPLOYEE.USERNAME like '" + filter + "%'", DAOConnection.getConnectionInstance());
                DAOConnection.getConnectionInstance().Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = com;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                DAOConnection.getConnectionInstance().Close();
                List<TOemployee> list = new List<TOemployee>();
                foreach (DataRow item in dt.Rows)
                {

                    list.Add(new TOemployee(item[0].ToString(), Boolean.Parse(item[1].ToString()),item[2].ToString(),int.Parse(item[3].ToString()),item[4].ToString()));
                }
                return list;

            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
