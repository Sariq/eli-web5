using System.ServiceModel;
using System.ServiceModel.Web;

[ServiceContract]
public interface IEmployee
{
    [OperationContract]
    [WebInvoke(
        Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "SignIn")
    ]
    Employee SignIn(Employee employee);

    [OperationContract]
    [WebInvoke(
        Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "SignOut")
    ]
    void SignOut();

    [OperationContract]
    [WebInvoke(
         Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Bare,
         UriTemplate = "GetEmployee")
    ]
    Employee GetEmployee();

    [OperationContract]
    [WebInvoke(
         Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Bare,
         UriTemplate = "AddEmployee")
    ]
    void AddEmployee(Employee employee);

    [OperationContract]
    [WebInvoke(
         Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Bare,
         UriTemplate = "RemoveEmployee")
    ]
    void RemoveEmployee(Employee employee);

    [OperationContract]
    [WebInvoke(
         Method = "POST",
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Bare,
         UriTemplate = "UpdateEmployee")
    ]
    void UpdateEmployee(Employee employee);



    //[OperationContract]
    //[WebInvoke(
    //    Method = "POST",
    //    ResponseFormat = WebMessageFormat.Json,
    //    BodyStyle = WebMessageBodyStyle.Bare,
    //    UriTemplate = "EmployeeList")
    //]
    //List<Employee> EmployeeList(Employee employee);  
}