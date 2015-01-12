using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.ServiceModel.Web;
using System.Web;
using JWT;
using System.Diagnostics;
using System.Threading;
using System.Web;


public class EmployeeService : DatabaseActions, IEmployee
{
    ClientServerCommunicationActions communication = new ClientServerCommunicationActions();

    public Employee SignIn(Employee employee)
    {
        var dbEmployee = GetEmployee(employee);

        if (dbEmployee == null)
        {
            var error = new Error(Error.ErrorType.UserIsNotExist);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }

        if (employee._password != dbEmployee._password)
        {
            var error = new Error(Error.ErrorType.PasswordIsIncorrect);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }

        if (employee._isRememberMe)
        {
            dbEmployee._isRememberMe = true;
            UpdateEmployee(dbEmployee);
        }
        else
        {
            dbEmployee._isRememberMe = false;
            UpdateEmployee(dbEmployee);
        }

        communication.SetTokenToHeader(dbEmployee);

        //// Example
        //var token2 = new ClientServerCommunicationActions().GetTokenFromHeader();
        //new ClientServerCommunicationActions().SetTokenToHeader(token2);
        //new ClientServerCommunicationActions().SetTokenToHeader_AllDetails_OnlyForExample(token2);
        //// End Example

        return dbEmployee;
    }

    public void SignOut()
    {
        if (HttpContext.Current.Request.Cookies["TokenId"] != null)
        {
            HttpCookie myCookie = new HttpCookie("TokenId");
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            HttpContext.Current.Response.Cookies.Add(myCookie);
        }
    }

    public Employee GetEmployee()
    {
        Employee employee;
        try
        {
            new ClientServerCommunicationActions().GetTokenFromHeader();
        }
        catch
        {
            var error = new Error(Error.ErrorType.NoUserInHeader);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }

        var tokenId = new ClientServerCommunicationActions().GetID_FromTokenInHeader();

        try
        {
            employee = GetObject<Employee>(tokenId, "Employee").Result;
        }
        catch
        {
            var error = new Error(Error.ErrorType.UserInHeaderIsNotExist);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }

        return employee;
    }

    public void AddEmployee(Employee employee)
    {
        var dbEmployee = GetEmployee(employee);
        if (dbEmployee == null)
            InsertObject(employee, "Employee");
        else
        {
            var error = new Error(Error.ErrorType.UserIsAlreadyExist);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }
    }

    public void RemoveEmployee(Employee employee)
    {
        var dbEmployee = GetEmployee(employee);
        if (dbEmployee != null)
            RemoveObject(dbEmployee, "Employee");
        else
        {
            var error = new Error(Error.ErrorType.UserIsNotExist);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }
    }

    public void UpdateEmployee(Employee employee)
    {
        var dbEmployee = GetEmployee(employee);
        if (dbEmployee != null)
            UpdateObject(employee, "Employee");
        else
        {
            var error = new Error(Error.ErrorType.UserIsNotExist);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }
    }

    public Employee GetEmployee(Employee employee)
    {
        try
        {
           return GetObject<Employee>("_userId", employee._userId, "Employee").Result;
            
        }
        catch
        {
            var error = new Error(Error.ErrorType.UserIsNotExist);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }
    }

    public Employee GetEmployee(string employeeId)
    {
        try
        {
            return GetObject<Employee>(employeeId, "Employee").Result;
        }
        catch
        {
            var error = new Error(Error.ErrorType.UserIsNotExist);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }
    }

    //public List<Employee> GetAllEmployees()
    //{
    //    return GetAllObject<Employee>("Employee").Result;
    //}

}