namespace backend.Models
{
    public interface IUserStoreDatabseSettings
    {
        string UsersCollectionName {get; set;}
        string ConnectionString {get; set;}
        string DatabaseName {get; set;}

    }
}