using AutoMapper;
using InvestManager.ApplicatoinCore.Interfaces;
using InvestManagerVer2.Web.Interfaces;
using InvestManagerVer2.Web.Models;
using InvestManagerVer2.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InvestManagerVer2.Web.Controllers
{
    public class InvestPortfolioController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStatisticService _statisticService;
        public InvestPortfolioController(IStatisticService statisticService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _statisticService = statisticService;
        }

        public IActionResult IndexInvestor()
        {
            return View();
        }

        public IActionResult Assets()
        {
            return View();
        }
        public IActionResult Transactions()
        {
            return View();
        }
        public IActionResult Statistics()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Statistics(StatisticsViewModel statisticsViewModel)
        {
            var statistics = await _statisticService.GetStatisticAsync();
            List<StatisticsViewModel> listStatistic = new List<StatisticsViewModel>();

            if (statistics == null)
            {
                foreach (var statistic in statistics)
                {
                    var StatisticsViewModel = new StatisticsViewModel()
                    {
                        Id = statistic.Id,
                        PortfolioProfitability = statistic.PortfolioProfitability,
                        PortfolioCost = statistic.PortfolioCost

                    };
                    listStatistic.Add(StatisticsViewModel);
                }
                return View(listStatistic);
            }
            return View();
        }

    }
}
