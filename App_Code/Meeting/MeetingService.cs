using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Web;


public class MeetingService : DatabaseActions, IMeeting
{
    public void AddMeeting(Meeting meeting)
    {
    
            InsertObject(meeting, "Meeting");
  
    }

    public void RemoveMeeting(string mettingId)
    {
        var dbMeeting = GetMeeting(mettingId);
        if (dbMeeting != null)
            RemoveObject(dbMeeting, "Meeting");
        else
        {
            var error = new Error(Error.ErrorType.MeetingIsNotExist);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }
    }

    public void UpdateMeeting(Meeting metting)
    {
        var dbMeeting = GetMeeting(metting._id);
        if (dbMeeting != null)
            UpdateObject(metting, "Meeting");
        else
        {
            var error = new Error(Error.ErrorType.MeetingIsNotExist);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }
    }

    public Meeting GetMeeting(string mettingId)
    {
        try
        {
            return GetObject<Meeting>(mettingId, "Meeting").Result;
        }
        catch
        {
            var error = new Error(Error.ErrorType.MeetingIsNotExist);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }
    }


    public List<Meeting> GetMeetingList()
    {
       //return new List<Meeting>();

        return GetAllObject<Meeting>("Meeting");
    }
}