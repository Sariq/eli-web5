using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Web;

public class AssignmentService : DatabaseActions, IAssignment
{
    public Assignment AddAssignment(Assignment assignment)
    {
        InsertObject(assignment, "Assignment");
        var dbAssignment = GetAssignment(assignment._id);
        return dbAssignment;
    }
    public List<Assignment> AddAssignment2(string[] assignments)
    {
        return GetAllObject<Assignment>("Assignment");
    }

    public void RemoveAssignment(string assignmentId)
    {
        RemoveObject(assignmentId, "Assignment");
    }

    public void UpdateAssignment(Assignment assignment)
    {
        UpdateObject(assignment, "Assignment");
    }

    public Assignment GetAssignment(string assignmentId)
    {
        return GetObject<Assignment>(assignmentId, "Assignment").Result;
    }

    public List<Assignment> GetAllAssignments()
    {
        return GetAllObject<Assignment>("Assignment");
    }
}