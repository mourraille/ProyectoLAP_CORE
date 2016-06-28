using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;

namespace BL
{
    public class Client : Person
    {

        public string PROFILEPICTUREURL { set; get; }
        public string EMAIL { set; get; }
        public Boolean isACTIVE { set; get; }
        public string ADDRESS { set; get; }

        public Client(string fullname, string pictureURL, string email, string address, int id)
        {
            this.PERSON_ID = id;
            this.FULLNAME = fullname;
            this.PROFILEPICTUREURL = pictureURL;
            this.EMAIL = email;
            this.ADDRESS = address;

        }

        public Client(string email, string password)
        {
            this.EMAIL = email;
            this.PASSWORD = password;
    
        }

        public Client() { }
        public Boolean addClient(string fullname, string password, string profilepictureurl, string email,string address)
        {
            Encryptor.MD5Hash(password);
            return new DAOclient().addClient(fullname, password,profilepictureurl,email,address);

        }

        public Boolean updateBasicData(string fullname, string address, string password, string email) {
            Encryptor.MD5Hash(password);
            return new DAOclient().updateBasicData(fullname, address, password, email);
        }

        public bool changeState(Boolean state, int id) {
            new DAOclient().changeState(id, state);
            return true;
        }

        public List<Client> getClients(string filter)
        {
            List<Client> clients = new List<Client>();
            List<TOclient> toc = new DAOclient().getClients(filter);
            foreach (TOclient i in toc)
            {
                clients.Add(new Client(i.FULLNAME,i.PROFILEPICTUREURL,i.EMAIL,i.ADDRESS,i.PERSON_ID));
            }
            return clients;
        }

       
    }
}
