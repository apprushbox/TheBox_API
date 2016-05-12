using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TheBox_API
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IServiceUser
    {
        
        
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "FindAll")]
        List<User> FindAll();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Find/{id}", RequestFormat = WebMessageFormat.Json)]
        User Find(string id);        

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "FindUser/{userName}")]
        User FindUser(string userName);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "LogIn", RequestFormat = WebMessageFormat.Json)]
        User LogIn(User user);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Create", RequestFormat = WebMessageFormat.Json)]
        ResponseOperation Create(User user);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Edit", RequestFormat = WebMessageFormat.Json)]
        bool Edit(User user);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Delete", RequestFormat = WebMessageFormat.Json)]
        bool Delete(User user);
    }
}
