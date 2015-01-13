using System;
using System.Runtime.Serialization;

[DataContract]
public class Meeting : DatabaseObject
{
    [DataMember]
    public string therapistId { get; set; }
    [DataMember]
    public string patientId { get; set; }
    [DataMember] 
    public string title { get; set; }    
    [DataMember]
    public string adress { get; set; }
    [DataMember]
    public DateTime time { get; set; }
    [DataMember]
    public string note { get; set; }


    public Meeting(string therapistId, string patientId, string title, string adress, DateTime time, string note)
        : base()
    {
        this.therapistId = therapistId;
        this.patientId = patientId;
        this.title = title;
        this.adress = adress;
        this.time = time;
        this.note = note;
    }

    public Meeting(Meeting meeting)
    {
        this._id = meeting._id;
        this.therapistId = meeting.therapistId;
        this.patientId = meeting.patientId;
        this.title = meeting.title;
        this.adress = meeting.adress;
        this.time = meeting.time;
        this.note = meeting.note;
    }
 
}