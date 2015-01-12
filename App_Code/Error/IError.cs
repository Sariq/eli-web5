using System.ServiceModel;
using System.ServiceModel.Web;

[ServiceContract]
public interface IError
{
    [OperationContract]
    [WebInvoke(
        Method = "POST",
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "AddError")
    ]
    void AddError(Error.ErrorType error);
}