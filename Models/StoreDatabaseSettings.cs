namespace backend.Models
{
    public class StoreDatabaseSettings : IStoreDatabseSettings
    {
        public string UsersCollectionName {get; set;} = String.Empty;
        public string FuelStationsCollectionName {get; set;} = String.Empty;
        public string ConnectionString {get; set;} = String.Empty;
        public string DatabaseName {get; set;} = String.Empty;
    }
}