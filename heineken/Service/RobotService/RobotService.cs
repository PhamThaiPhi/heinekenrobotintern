using heineken.Data;
using heineken.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace heineken.Service.RobotService
{
    public class RobotService : IRobotService
    {
        private readonly MyDbHei _context;

        public RobotService(MyDbHei context)
        {
            _context = context;
        }

        // ✅ Lấy tất cả robots
        public List<Robots> GetAllRobots()
        {
            return _context.Robots.ToList();
        }

        // ✅ Lấy robot theo ID
        public Robots GetRobotsById(int id)
        {
            return _context.Robots.Find(id);
        }

        // ✅ Thêm robot mới
        public Robots CreateRobots(RobotModel model)
        {
            var newRobot = new Robots
            {
                RobotName = model.RobotName,
                ActivityLocation = model.ActivityLocation,
                BatteryLevel = model.BatteryLevel,
                LastConnectionTime = model.LastConnectionTime,
                //RobotStatus = model.RobotStatus
            };

            _context.Robots.Add(newRobot);
            _context.SaveChanges();
            return newRobot;
        }

        // ✅ Cập nhật robot
        public Robots UpdateRobots(int id, RobotModel robots)
        {
            var existingRobot = _context.Robots.SingleOrDefault(f => f.RobotID == id);
            if (existingRobot == null)
                throw new KeyNotFoundException("Robot không tồn tại!");

            existingRobot.RobotName = robots.RobotName;
            existingRobot.ActivityLocation = robots.ActivityLocation;
            existingRobot.BatteryLevel = robots.BatteryLevel;
            existingRobot.LastConnectionTime = robots.LastConnectionTime;
            existingRobot.RobotStatus = (Robots.Status)robots.RobotStatus;
            existingRobot.LastUpdate = robots.LastUpdate;
            _context.SaveChanges();
            return existingRobot;
        }


        // ✅ Xóa robot
        public bool DeleteRobots(int id)
        {
            var robot = _context.Robots.Find(id);
            if (robot == null) return false;

            _context.Robots.Remove(robot);
            _context.SaveChanges();
            return true;
        }
    }
}
