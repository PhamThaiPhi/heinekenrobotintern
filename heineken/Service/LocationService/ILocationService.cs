using heineken.Data;
using heineken.Models;

namespace heineken.Service.LocationService
{
    public interface ILocationService
    {
        List<Locations> GetAll();
        Locations GetById(int id);
        Locations Create(LocationModel model);
        Locations Update(int id, LocationModel model);
        bool Delete(int id);
    }
}
