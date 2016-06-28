using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BL;

namespace WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    public class RogersWS : RogersIWS
    {
        public List<Client> WSgetAllClients(String filter) 
        {
            return new Client().getClients(filter);
        }


        public Boolean WSaddClient(string fullname, string password, string profilepictureurl, string email, string address)
        {
            return new Client().addClient(fullname, password, profilepictureurl, email, address);
        }

        public bool WSupdateBasicData(string fullname, string address, string password, string email)
        {
            return new Client().updateBasicData(fullname, address, password, email);
        }

        public Boolean WSchangeState(int id, bool state)
        {
              return new Client().changeState(state, id);
        }



        public bool WSupdateEmployee(string fullname, string password, string username, bool isadmin)
        {
            return new Employee().updateEmployee(fullname, password, username, isadmin);  
        }

        public List<Employee> WSfindEmployee(string filter)
        {
            return new Employee().findEmployee(filter);
        }

        public bool WSaddEmployee(string fullname, string password, string username, bool isadmin)
        {
            return new Employee().addEmployee(fullname, password, username, isadmin);
        }

        public List<OrderState> WSgetOrderStates()
        {
            return new OrderState().getOrderStates();
        }

        public bool WSsetTime(int id, DateTime time)
        {
            return new OrderState().setTime(id,time);
        }

        public bool WSaddproduct(string productname, string description, double price, string image, bool isoutofstoc, string category)
        {
            return new Product().addproduct(productname, description, price, image, isoutofstoc, category);

        }

        public bool WSdeleteProduct(int id)
        {
            return new Product().deleteProduct(id);
        }

        public List<Product> WSsearchProduct(string productname)
        {
            return new Product().searchProduct(productname);
        }

        public bool WSupdateProduct(int id, string name, string descr, double price, string imageuri, int stock, string cat)
        {
            return new Product().updateProduct(id, name,descr,price,imageuri,stock,cat);
        }

        public bool WSaddOrder(int id, List<Product> prods)
        {
            return new Order().addOrder(id, prods);
        }

        public List<Order> WSsearchOrders(string id)
        {
            return new Order().searchOrders(id);
        }

        public bool WSdeletePerson(string id)
        {
            return new Employee().deletePERSON(id);
        }
    }
}
