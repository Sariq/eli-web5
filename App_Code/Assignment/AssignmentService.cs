using System.Net;
using System.ServiceModel.Web;

public class AssignmentService : DatabaseActions, IAssignment
{
    public void AddAssignment(Assignment assignment)
    {
        var dbAssignment = GetAssignment(assignment._id);
        if (dbAssignment == null)
            InsertObject(assignment, "Assignment");
        else
        {
            var error = new Error(Error.ErrorType.AssignmentIsAlreadyExist);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }
    }

    public void RemoveAssignment(string assignmentId)
    {
        var dbAssignment = GetAssignment(assignmentId);
        if (dbAssignment != null)
            RemoveObject(dbAssignment, "Assignment");
        else
        {
            var error = new Error(Error.ErrorType.AssignmentIsNotExist);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }
    }

    public void UpdateAssignment(Assignment assignment)
    {
        var dbAssignment = GetAssignment(assignment._id);
        if (dbAssignment != null)
            UpdateObject(assignment, "Assignment");
        else
        {
            var error = new Error(Error.ErrorType.AssignmentIsNotExist);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }
    }

    public Assignment GetAssignment(string assignmentId)
    {
        try
        {
            return GetObject<Assignment>(assignmentId, "Assignment").Result;
        }
        catch
        {
            var error = new Error(Error.ErrorType.AssignmentIsNotExist);
            throw new WebFaultException<Error>(error, HttpStatusCode.BadRequest);
        }
    }   
}