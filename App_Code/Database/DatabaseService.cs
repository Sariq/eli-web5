using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;

public class DatabaseService : IDatabaseService
{

    public void Initialize()
    {
        CreateCollection("User");
        SetCollectionPrimeryKey("User", "userId");

        CreateCollection("Meeting");

        //CreateCollection("Assignment");

        //CreateCollection("Patient");
        //SetCollectionPrimeryKey("Patient", "identityNumber");

        InitializeUserCollection();
        //InitializePatientCollection();
        InitializeMeetingCollection();
        //InitializeAssignmentCollection();
    }


    //private void InitializeAssignmentCollection()
    //{
    //    var assignmentService = new AssignmentService();

    //    var user = new User("Karin", "123", "Karin", "B", "karin@gmail.com", "K", DateTime.Today, "role", true);

    //    var assignment = new Assignment(user, "AssignmentA", "freeText", false);
    //    assignmentService.AddAssignment(assignment);

    //    assignment = new Assignment(user, "AssignmentB", "freeText", false);
    //    assignmentService.AddAssignment(assignment);
    //}

    //private void InitializePatientCollection()
    //{
    //    var patientService = new PatientService();

    //    var user = new User("Karin", "123", "Karin", "B", "karin@gmail.com", "K", DateTime.Today, "role", true);

    //    var assignment = new Assignment(user, "AssignmentA", "freeText", false);
    //    Assignment[] assignments = new Assignment[] { assignment };

    //    var patient = new Patient("123", "Karin", "B", "karin@gmail.com", "K", DateTime.Today, assignments);
    //    patientService.AddPatient(patient);

    //    patient = new Patient("1233", "Sari", "Q", "sari@gmail.com", "K", DateTime.Today, assignments);
    //    patientService.AddPatient(patient);
    //}

    private void InitializeUserCollection()
    {
        var userService = new UserService();

        var user = new User("Karin", "123", "Karin", "B", "karin@gmail.com", "K", DateTime.Today, "role", true);
        userService.AddUser(user);

        user = new User("Sari", "123", "Sari", "Q", "sari@gmail.com", "K", DateTime.Today, "role", false);
        userService.AddUser(user);
    }

    private void InitializeMeetingCollection()
    {
        var meetingService = new MeetingService();

        var meeting = new Meeting("123", "123", "meetingA", "A", DateTime.Today, "freeText");
        meetingService.AddMeeting(meeting);

        meeting = new Meeting("123", "123", "meetingB", "K", DateTime.Today, "freeText");
        meetingService.AddMeeting(meeting);
    }

    private MongoDatabase GetDatabase()
    {
        MongoClient client = new MongoClient();
        var server = client.GetServer();
        var database = server.GetDatabase("ELI");
        return database;
    }

    private void CreateCollection(string collectionName)
    {
        var database = GetDatabase();
        var collection = database.CreateCollection(collectionName);
    }

    public MongoCollection GetCollection(string collectionName)
    {
        var database = GetDatabase();
        var collection = database.GetCollection(collectionName);
        return collection;
    }

    private void SetCollectionPrimeryKey(string collectionName, string primeryKeyName)
    {
        var collection = GetCollection(collectionName);
        collection.EnsureIndex(new IndexKeysBuilder().Ascending(primeryKeyName), IndexOptions.SetUnique(true));
    }

}