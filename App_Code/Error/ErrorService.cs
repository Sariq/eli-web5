using System.Net;
using System.ServiceModel.Web;
public class ErrorService : DatabaseActions, IError
{
    public void AddError(Error.ErrorType error)
    {
        Error e = new Error(error);
        InsertObject(e, "Error");
    }

    public Error GetError(Error.ErrorType errorType)
    {
        try
        {
            return GetObject<Error>("_errorDescription", errorType.ToString(), "Error").Result;
        }
        catch
        {
            var error = new Error(Error.ErrorType.ErrorIsNotExist);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }
    }
}