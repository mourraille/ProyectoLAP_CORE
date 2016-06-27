using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace WebServices
{
    /// <summary>
    /// Summary description for webservicesASMX
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Rogers_API : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string searchClients(String param)
        {
            return new JavaScriptSerializer().Serialize(new RogersWS().WSgetAllClients(param));
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void addClient(string fullname, string password, string profilepictureurl, string email, string address)
        {
            new RogersWS().WSaddClient(fullname, password, profilepictureurl, email, address);

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Boolean updateBasicData(string fullname, string address, string password, string email) {
            return new RogersWS().WSupdateBasicData(fullname, address, password, email);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Boolean changeState(Boolean state, string email) {
            return new RogersWS().WSchangeState(state, email);

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Boolean updateEmployee(string fullname, string password, string username, bool isadmin) {
            return new RogersWS().WSupdateEmployee(fullname,password,username, isadmin);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public String searchEmployee(string filter) {
            return new JavaScriptSerializer().Serialize( new RogersWS().WSfindEmployee(filter));
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool addEmployee(string fullname, string password, string username, bool isadmin) {
            return new RogersWS().WSaddEmployee(fullname, password, username,isadmin);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string searchOrderStates() {
            return new JavaScriptSerializer().Serialize(new RogersWS().WSgetOrderStates());
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool setTime(int id, DateTime time) {
            return new RogersWS().WSsetTime(id, time);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool addproduct(string productname, string description, double price, string image, bool isoutofstoc, int category) {
            return new RogersWS().WSaddproduct(productname, description, price, image, isoutofstoc, category);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool deleteProduct(int id) {
            return new RogersWS().WSdeleteProduct(id);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public String searchProduct(string productname) {
            return new JavaScriptSerializer().Serialize(new RogersWS().WSsearchProduct(productname));
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool updateProduct(int id, string name, string descr, double price, string imageuri, int stock, int cat) {
            return new RogersWS().WSupdateProduct(id, name, descr, price, imageuri,stock, cat);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool addOrder(int id, List<Product> prods) {
            return new RogersWS().WSaddOrder(id, prods);
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        List<Order> searchOrders(string id) {
            return new RogersWS().WSsearchOrders(id);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool deletePerson(string person_id)
        {
            return new RogersWS().WSdeletePerson(person_id);
        }

    }
}
