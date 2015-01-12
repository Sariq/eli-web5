using System;
using System.Runtime.Serialization;

[DataContract]
public class Employee : DatabaseObject
{
    [DataMember] public String _userId { get; set; }
    [DataMember] public String _password { get; set; }
    [DataMember] public String _firstName { get; set; }
    [DataMember] public String _lastName { get; set; }
    [DataMember] public String _email { get; set; }
    [DataMember] public Boolean _isAdmin { get; set; }
    [DataMember] public Boolean _isRememberMe { get; set; }

    public Employee(string userId, string password, string firstName, string lastName, 
        string email, bool isAdmin, bool isRememberMe) : base()
    {
        _userId = userId;
        _password = password;
        _firstName = firstName;
        _lastName = lastName;
        _email = email;
        _isAdmin = isAdmin;
        _isRememberMe = isRememberMe;
    }
 
}