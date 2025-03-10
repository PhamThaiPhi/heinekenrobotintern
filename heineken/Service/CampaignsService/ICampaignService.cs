using heineken.Data;
using heineken.Models;

namespace heineken.Service.CampaignsService
{
    public interface ICampaignService
    {
        List<Campaign> GetAllCamp();
        Campaign GetCampById(int id);
        Campaign CreateCamp(CampaignModel model);
        Campaign UpdateCamp(int id, CampaignModel model);
        bool DeleteCamp(int id);
    }
}
