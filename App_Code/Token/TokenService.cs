using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using System.Web;

public class TokenService : DatabaseActions, IToken
{
    ClientServerCommunicationActions communication = new ClientServerCommunicationActions();

    public void RefreshToken()
    {
        
        var id = communication.GetID_FromTokenInHeader();
     
        try
        {
            var obj = GetObject<Employee>(id, "Employee");
        }
        catch
        {
            var error = new Error(Error.ErrorType.NoUserInHeader);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }

        Token newToken = new Token(id);
        communication.SetTokenToHeader(newToken);

       
    }


    public Employee SignIn(Employee employee)
    {


        return employee;
    }

}