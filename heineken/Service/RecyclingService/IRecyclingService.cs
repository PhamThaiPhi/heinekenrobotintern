using heineken.Data;
using heineken.Models;

namespace heineken.Service.RecyclingService
{
    public interface IRecyclingService
    {
        List<RecyclingMachine> GetAllRecy();
        RecyclingMachine GetRecyById(int id);
        RecyclingMachine CreateRecy(RecyclingModel model);
        RecyclingMachine UpdateRecy(int id, RecyclingModel model);
        bool DeleteRecy(int id);
    }
}
