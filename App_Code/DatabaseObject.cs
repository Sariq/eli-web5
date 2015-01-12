using MongoDB.Bson;
using System;
using System.Runtime.Serialization;

[DataContract]
public class DatabaseObject
{
    public String _id;

    public DatabaseObject()
    {
        _id = Convert.ToString((ObjectId.GenerateNewId()));
    }
}