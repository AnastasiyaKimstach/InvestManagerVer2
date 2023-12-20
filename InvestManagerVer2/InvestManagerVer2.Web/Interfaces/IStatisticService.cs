using InvestManagerVer2.Web.Models;

namespace InvestManagerVer2.Web.Interfaces
{
    public interface IStatisticService
    {
        Task<List<StatisticsViewModel>> GetStatisticAsync();
    }
}
