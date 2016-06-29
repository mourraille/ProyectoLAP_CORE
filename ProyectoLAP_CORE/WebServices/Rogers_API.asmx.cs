using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using BL;

namespace WebServices
{
    /// <summary>
    /// Summary description for webservicesASMX
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Rogers_API : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string searchClientsJSON(String param)
        {
            return new JavaScriptSerializer().Serialize(new RogersWS().WSgetAllClients(param));
        }

        [WebMethod]
        public List<Client> searchClientsSOAP(String param)
        {
            return new RogersWS().WSgetAllClients(param);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void addClientJSON(string fullname, string password, string profilepictureurl, string email, string address)
        {
            new RogersWS().WSaddClient(fullname, password, profilepictureurl, email, address);

        }

        [WebMethod]
        public void addClientSOAP(string fullname, string password, string profilepictureurl, string email, string address)
        {
            new RogersWS().WSaddClient(fullname, password, profilepictureurl, email, address);

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Boolean updateBasicDataJSON(string fullname, string address, string password, string email) {
            return new RogersWS().WSupdateBasicData(fullname, address, password, email);
        }

        [WebMethod]
        public Boolean updateBasicDataSOAP(string fullname, string address, string password, string email)
        {
            return new RogersWS().WSupdateBasicData(fullname, address, password, email);
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Boolean changeStateJSON(int id, Boolean state) {
            return new RogersWS().WSchangeState(id, state);
        }

        [WebMethod]
        public Boolean changeStateSOAP(int id, Boolean state)
        {
            return new RogersWS().WSchangeState(id, state);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Boolean updateEmployeeJSON(string fullname, string password, string username, bool isadmin) {
            return new RogersWS().WSupdateEmployee(fullname,password,username, isadmin);
        }

        [WebMethod]
        public Boolean updateEmployeeSOAP(string fullname, string password, string username, bool isadmin)
        {
            return new RogersWS().WSupdateEmployee(fullname, password, username, isadmin);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public String searchEmployeeJSON(string filter) {
            return new JavaScriptSerializer().Serialize( new RogersWS().WSfindEmployee(filter));
        }

        [WebMethod]
        public List<Employee> searchEmployeeSOAP(string filter)
        {
            return new RogersWS().WSfindEmployee(filter);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool addEmployeeJSON(string fullname, string password, string username, bool isadmin) {
            return new RogersWS().WSaddEmployee(fullname, password, username,isadmin);
        }

        [WebMethod]
        public bool addEmployeeSOAP(string fullname, string password, string username, bool isadmin)
        {
            return new RogersWS().WSaddEmployee(fullname, password, username, isadmin);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string searchOrderStatesJSON() {
            return new JavaScriptSerializer().Serialize(new RogersWS().WSgetOrderStates());
        }

        [WebMethod]
        public List<OrderState> searchOrderStatesSOAP()
        {
            return new RogersWS().WSgetOrderStates();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool setTimeJSON(int id, DateTime time) {
            return new RogersWS().WSsetTime(id, time);
        }

        [WebMethod]
        public bool setTimeSOAP(int id, DateTime time)
        {
            return new RogersWS().WSsetTime(id, time);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool addproductJSON(string productname, string description, double price, string image, bool isoutofstoc, string category) {
            return new RogersWS().WSaddproduct(productname, description, price, image, isoutofstoc, category);
        }

        [WebMethod]
        public bool addproductSOAP(string productname, string description, double price, string image, bool isoutofstoc, string category)
        {
            return new RogersWS().WSaddproduct(productname, description, price, image, isoutofstoc, category);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool deleteProductJSON(int id) {
            return new RogersWS().WSdeleteProduct(id);
        }

        [WebMethod]
        public bool deleteProductSOAP(int id)
        {
            return new RogersWS().WSdeleteProduct(id);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void searchProductJSON(string productname) {

         Context.Response.Write( new JavaScriptSerializer().Serialize(new RogersWS().WSsearchProduct(productname)));
        }

        [WebMethod]
        public List<Product> searchProductSOAP(string productname)
        {
            return new RogersWS().WSsearchProduct(productname);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void searchProductByIdJSON(string id)
        {
            Context.Response.Write(new JavaScriptSerializer().Serialize(new Product().searchProductById(id)));
        }

        [WebMethod]
        public Product searchProductByIdSOAP(string id)
        {
            return new Product().searchProductById(id);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool updateProductJSON(int id, string name, string descr, double price, string imageuri, int stock, string cat) {
            return new RogersWS().WSupdateProduct(id, name, descr, price, imageuri,stock, cat);
        }

        [WebMethod]
        public bool updateProductSOAP(int id, string name, string descr, double price, string imageuri, int stock, string cat)
        {
            return new RogersWS().WSupdateProduct(id, name, descr, price, imageuri, stock, cat);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool addOrderJSON(int id, List<Product> prods) {
            return new RogersWS().WSaddOrder(id, prods);
        }

        [WebMethod]
        public bool addOrderSOAP(int id, List<Product> prods)
        {
            return new RogersWS().WSaddOrder(id, prods);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string searchOrdersJSON(string id) {
            return new JavaScriptSerializer().Serialize(new RogersWS().WSsearchOrders(id));
        }

        [WebMethod]
         public List<Order> searchOrdersSOAP(string id)
        {
            return new RogersWS().WSsearchOrders(id);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool deletePersonJSON(string person_id)
        {
            return new RogersWS().WSdeletePerson(person_id);
        }

        [WebMethod]
        public bool deletePersonSOAP(string person_id)
        {
            return new RogersWS().WSdeletePerson(person_id);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Boolean changeProductStateJSON(int id, Boolean state)
        {
            return new Product().changeState(id, state);
        }

        [WebMethod]
        public Boolean changeProductStateSOAP(int id, Boolean state)
        {
            return new Product().changeState(id, state);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Boolean verifyPasswordJSON(int id, string password)
        {
            return new UserVerification().verifyPassword(id, password);
        }

        [WebMethod]
        public Boolean verifyPasswordSOAP(int id, string password)
        {
            return new UserVerification().verifyPassword(id, password);
        }



    }
}
