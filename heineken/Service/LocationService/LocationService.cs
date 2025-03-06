using heineken.Data;
using heineken.Models;

namespace heineken.Service.LocationService
{
    public class LocationService : ILocationService
    {
        private readonly MyDbHei _context;

        public LocationService(MyDbHei context)
        {
            _context = context;
        }

        public List<Locations> GetAll()
        {
            return _context.Locations.ToList();
        }
        public Locations GetById(int id)
        {
            return _context.Locations.Find(id);
        }
        public Locations Create(LocationModel model)
        {
            var newlocation = new Locations
            {
                Address = model.Address,
                TotalPoints = model.TotalPoints,
                Area = model.Area,
                DateAdded = model.DateAdded,
                RobotCount = model.RobotCount,
            };
            _context.Locations.Add(newlocation);
            _context.SaveChanges();
            return newlocation;
        }
        public Locations Update(int id, LocationModel model)
        {
            var existing = _context.Locations.SingleOrDefault(f => f.LocationID == id);
            if (existing == null)
                throw new KeyNotFoundException("Location không tồn tại!");

            existing.Address = model.Address;
            existing.TotalPoints = model.TotalPoints;
            existing.Area = model.Area;
            existing.DateAdded = model.DateAdded;
            existing.RobotCount = model.RobotCount;

            _context.SaveChanges();
            return existing;
        }
        public bool Delete(int id)
        {
            var gift = _context.Locations.Find(id);
            if (gift == null) return false;

            _context.Locations.Remove(gift);
            _context.SaveChanges();
            return true;
        }
    }
}
