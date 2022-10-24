namespace backend.Models
{
    public interface IStoreDatabseSettings
    {
        string UsersCollectionName {get; set;}
        string ConnectionString {get; set;}
        string DatabaseName {get; set;}

    }
}