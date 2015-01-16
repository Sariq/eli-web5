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
        RemoveObject(mettingId, "Meeting");
    }

    public void UpdateMeeting(Meeting metting)
    {
        UpdateObject(metting, "Meeting");
    }

    public Meeting GetMeeting(string mettingId)
    {
        return GetObject<Meeting>(mettingId, "Meeting").Result;
    }

    public List<Meeting> GetAllMeetings()
    {
        return GetAllObject<Meeting>("Meeting");
    }

    public List<Assignment> GetAllAssignmentsOfMeeting(string meetingId)
    {
        Meeting meeting = GetMeeting(meetingId);

        List<Assignment> assignments = new List<Assignment>(meeting.assignments);

        return assignments;
    }

}