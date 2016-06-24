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
    public class DAOclient
    {
        public Boolean addClient(string fullname, string password, string profilepictureurl, string email, string address)
        {
            try
            {
                SqlCommand com = new SqlCommand("EXECUTE DBO.addClient @fullName =@FULLNAME, @pass =@PASS,@email =@EMAIL,@profileurl =@PROFILEURL, @address =@ADDRESS", DAOConnection.getConnectionInstance());
                com.Parameters.AddWithValue("@FULLNAME", fullname);
                com.Parameters.AddWithValue("@PASS", password);
                com.Parameters.AddWithValue("@EMAIL", email);
                com.Parameters.AddWithValue("@ADDRESS", address);
                com.Parameters.AddWithValue("@PROFILEURL", profilepictureurl);

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

        public Boolean updateBasicData(string fullname, string address, string password, string email)
        {
            try
            {
                SqlCommand com = new SqlCommand("update Person set person.FULLNAME = @fullname , person.PASSWORD = @password WHERE PERSON_ID = (SELECT client.PERSON_ID from client where client.EMAIL = @email);update CLIENT SET  CLIENT.ADDRESSS =@address WHERE CLIENT.EMAIL = @email", DAOConnection.getConnectionInstance());
                com.Parameters.AddWithValue("@fullname", fullname);
                com.Parameters.AddWithValue("@password", password);
                com.Parameters.AddWithValue("@address", address);
                com.Parameters.AddWithValue("@email", email);

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

        public void changeState(string email, bool state) {
            SqlCommand com = new SqlCommand("update client set client.ISACTIVEUSER= @isactive where client.EMAIL = @email", DAOConnection.getConnectionInstance());
            com.Parameters.AddWithValue("@isactive", state);
            com.Parameters.AddWithValue("@email", email);
            DAOConnection.getConnectionInstance().Open();
            com.ExecuteNonQuery();
            DAOConnection.getConnectionInstance().Close();

        }

        public List<TOclient> getClients(string filter) {

            try
            {
                SqlCommand com = new SqlCommand("select PERSON.FULLNAME , client.PROFILEPICTUREURL,client.EMAIL,client.ISACTIVEUSER,client.addresss, PERSON.PERSON_ID from PERSON join CLIENT on CLIENT.PERSON_ID = PERSON.PERSON_ID WHERE client.email like '" + filter + "%';", DAOConnection.getConnectionInstance());
                DAOConnection.getConnectionInstance().Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = com;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                DAOConnection.getConnectionInstance().Close();
                List<TOclient> list = new List<TOclient>();
                foreach (DataRow i in dt.Rows)
                {
                    TOclient toc = new TOclient(i["FULLNAME"].ToString(), i["PROFILEPICTUREURL"].ToString(), i["EMAIL"].ToString(), i["addresss"].ToString(), int.Parse(i["PERSON_ID"].ToString()));
                    toc.isACTIVE = (Boolean)i["ISACTIVEUSER"];
                    list.Add(toc);
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
