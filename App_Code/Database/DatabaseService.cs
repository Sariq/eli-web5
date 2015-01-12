using MongoDB.Driver;
using MongoDB.Driver.Builders;

public class DatabaseService : IDatabaseService
{
    public void Initialize()
    {
        CreateCollection("Employee");
        SetCollectionPrimeryKey("Employee", "_userId");

        CreateCollection("Error");
        SetCollectionPrimeryKey("Error", "_errorDescription");

        InitializeEmployeeCollection();
        InitializeErrorCollection();
    }

    private void InitializeErrorCollection()
    {
        var errorService = new ErrorService();

        var error = Error.ErrorType.PasswordIsIncorrect;
        errorService.AddError(error);

        error = Error.ErrorType.UserIsNotExist;
        errorService.AddError(error);

        error = Error.ErrorType.UserIsAlreadyExist;
        errorService.AddError(error);
    }

    private void InitializeEmployeeCollection()
    {
        var employeeService = new EmployeeService();

        var employee = new Employee("Karin", "123", "Karin", "B", "karin@gmail.com", true, true);
        employeeService.AddEmployee(employee);

        employee = new Employee("Sari", "123", "Sari", "Q", "sari@gmail.com", true, true);
        employeeService.AddEmployee(employee);
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