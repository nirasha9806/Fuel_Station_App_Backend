using backend.Models;
using MongoDB.Driver;

namespace backend.Services
{
    public class FuelStationService : IFuelStationService
    {
        private readonly IMongoCollection<FuelStation> _stations;

        public FuelStationService(IStoreDatabseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _stations = database.GetCollection<FuelStation>(settings.FuelStationsCollectionName);
        }

        public FuelStation Create(FuelStation fuelStation)
        {
            _stations.InsertOne(fuelStation);
            return fuelStation;
        }

        public List<FuelStation> Get()
        {
            return _stations.Find(fuelStation => true).ToList();
        }

        public FuelStation Get(string id)
        {
            return _stations.Find(fuelStation => fuelStation.id == id).FirstOrDefault();
        }

        public List<FuelStation> GetByName(string name)
        {
            return _stations.Find(fuelStation => fuelStation.Name == name).ToList();
        }

        public void Remove(string id)
        {
            _stations.DeleteOne(fuelStation => fuelStation.id == id);
        }

        public void Update(string id, FuelStation fuelStation)
        {
             _stations.ReplaceOne(fuelStation => fuelStation.id == id, fuelStation);
        }
    }
}