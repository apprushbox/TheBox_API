using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TheBox_API
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductService" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "FindAll")]
        List<Product> FindAll();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Find/{id}", RequestFormat = WebMessageFormat.Json)]
        Product Find(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Create", RequestFormat = WebMessageFormat.Json)]
        ResponseOperation Create(Product product);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Edit", RequestFormat = WebMessageFormat.Json)]
        bool Edit(Product product);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Delete", RequestFormat = WebMessageFormat.Json)]
        bool Delete(Product product);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "FindProductNames")]
        string[] FindProductNames(RequestTheBoxApp requestTheBoxApp);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "FindProductByLocation", RequestFormat = WebMessageFormat.Json)]
        ProductProvider FindProductByLocation(RequestTheBoxApp requestTheBoxApp);
    }
}
