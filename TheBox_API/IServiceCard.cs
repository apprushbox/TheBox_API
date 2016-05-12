using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TheBox_API
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICardService" in both code and config file together.
    [ServiceContract]
    public interface IServiceCard
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "FindById/{id}", RequestFormat = WebMessageFormat.Json)]
        CreditCard FindById(string iduserId);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "FindByUserId/{id}", RequestFormat = WebMessageFormat.Json)]
        List<CreditCard> FindByUserId(string iduserId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Create", RequestFormat = WebMessageFormat.Json)]
        ResponseOperation Create(CreditCard creditCard);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Edit", RequestFormat = WebMessageFormat.Json)]
        bool Edit(CreditCard creditCard);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Delete", RequestFormat = WebMessageFormat.Json)]
        bool Delete(CreditCard creditCard);
    }
}
