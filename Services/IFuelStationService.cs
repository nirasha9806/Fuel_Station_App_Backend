using backend.Models;

namespace backend.Services
{
    public interface IFuelStationService
    {
        List<FuelStation> Get();
        FuelStation Get(string id);
        List<FuelStation> GetByName(string name);
        FuelStation Create(FuelStation fuelStation);
        void Update(string id, FuelStation fuelStation);
        void Remove(string id);
    }
}