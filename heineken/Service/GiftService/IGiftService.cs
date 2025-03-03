using heineken.Data;
using heineken.Models;
namespace heineken.Service.GiftService
{
    public interface IGiftService
    {
        List<Gift> GetAllGift();
        Gift GetGiftById(int id);
        Gift CreateGift(GiftModel model);
        Gift UpdateGift(int id, GiftModel model);
        bool DeleteGift(int id);
    }
}
