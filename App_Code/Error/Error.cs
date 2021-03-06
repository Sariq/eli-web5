﻿using System.Runtime.Serialization;

[DataContract]
public class Error : DatabaseObject
{

    public enum ErrorType
    {
        PasswordIsIncorrect,
        UserIsNotExist,
        UserIsAlreadyExist,
        NoUserInHeader,
        UserInHeaderIsNotExist,

        MeetingIsNotExist,
        MeetingIsAlreadyExist,

        PatientIsNotExist,
        PatientIsAlreadyExist,

        AssignmentIsNotExist,
        AssignmentIsAlreadyExist,
    }

    [DataMember] 
    public string error_description { get; set; }


    public Error(ErrorType errorType) : base()
    {
        error_description = errorType.ToString();
    }

}