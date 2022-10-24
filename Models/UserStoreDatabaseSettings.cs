namespace backend.Models
{
    public class UserStoreDatabaseSettings : IUserStoreDatabseSettings
    {
        public string UsersCollectionName {get; set;} = String.Empty;
        public string ConnectionString {get; set;} = String.Empty;
        public string DatabaseName {get; set;} = String.Empty;
    }
}