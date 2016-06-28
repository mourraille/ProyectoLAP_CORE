using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;

namespace BL
{
  public  class Employee : Person
    {
        public string USERNAME { set; get; }
        public Boolean isADMIN { get; set; }

        public Employee(string username, string password, string fullname) {
            this.FULLNAME = fullname;
            this.USERNAME = username;
            this.PASSWORD = password;
        }

        public Employee(string username, bool isadmin, string fullname, int personid, string password)
        {
            this.PERSON_ID = personid;
            this.FULLNAME = fullname;
            this.USERNAME = username;
            this.isADMIN = isadmin;
            this.PASSWORD = password;
        }


        public Employee() { }

        public Boolean addEmployee(string fullname, string password, string username,Boolean isadmin) {
            Encryptor.MD5Hash(password);
            return new DAOemployee().addEmployee(fullname,password,username, isadmin);
        }

        public Boolean deletePERSON(string ID) {
            return new DAOemployee().deletePerson(ID);
        }

        public Boolean updateEmployee(string fullname, string password, string username, Boolean isadmin) {
            Encryptor.MD5Hash(password);
            return new DAOemployee().updateEmployee( fullname,  password,  username,  isadmin);
        }

        public List<Employee> findEmployee(String filter) {
            List<TOemployee> list = new DAOemployee().searchEmployee(filter);
            List<Employee> employeelist = new List<Employee>();
            foreach (TOemployee item in list)
            {
                employeelist.Add(new Employee(item.USERNAME,item.isADMIN,item.FULLNAME,item.PERSON_ID,item.PASSWORD));
            }
            return employeelist;
        }
    }



}
