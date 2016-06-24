using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
   public class TOclient : TOperson
    {

        public string PROFILEPICTUREURL { set; get; }
        public string EMAIL { set; get; }
        public Boolean isACTIVE { set; get; }
        public string ADDRESS { set; get; }

        public TOclient(string fullname, string pictureURL, string email, string address, int id)
        {
            this.PERSON_ID = id;
            this.FULLNAME = fullname;
            this.PROFILEPICTUREURL = pictureURL;
            this.EMAIL = email;
            this.ADDRESS = address;
        }

        public TOclient(string fullname, bool isActive, string email, string address)
        {
            this.FULLNAME = fullname;
            this.isACTIVE = isACTIVE;
            this.EMAIL = email;
            this.ADDRESS = address;
        }

        public TOclient(string email, string password)
        {
            this.EMAIL = email;
            this.PASSWORD = password;

        }

        public TOclient() { }

        public override string ToString()
        {
            return base.FULLNAME;
        }
    }

  
}
