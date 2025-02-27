using heineken.Data;
using heineken.Models;

namespace heineken.Service
{
    public interface IRobotService
    {
        List<Robots> GetAllRobots();
        Robots GetRobotsById(int id);
        Robots CreateRobots(RobotModel model);
        Robots UpdateRobots(int id, RobotModel robots);
        bool DeleteRobots(int id);
    }
}
