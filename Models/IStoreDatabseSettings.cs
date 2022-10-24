namespace backend.Models
{
    public interface IStoreDatabseSettings
    {
        string UsersCollectionName {get; set;}
        string FuelStationsCollectionName {get; set;}
        string QueuesCollectionName {get; set;}
        string ConnectionString {get; set;}
        string DatabaseName {get; set;}

    }
}