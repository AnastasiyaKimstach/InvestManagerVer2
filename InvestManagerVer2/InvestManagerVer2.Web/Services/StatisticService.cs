using AutoMapper;
using InvestManager.ApplicatoinCore.Interfaces;
using InvestManager.ApplicatoinCore.Models;
using InvestManager.ApplicatoinCore.QueryOptions;
using InvestManagerVer2.Web.Interfaces;
using InvestManagerVer2.Web.Models;

namespace InvestManagerVer2.Web.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StatisticService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<StatisticsViewModel>> GetStatisticAsync()
        {
            var options = new QueryEntityOptions<Statistics>().AddSortOption(false, x => x.Id);
            var entities = await _unitOfWork.Statistics.GetAllAsync(options);
            var statistics = _mapper.Map<List<StatisticsViewModel>>(entities);

            return statistics;
        }
    }
}
