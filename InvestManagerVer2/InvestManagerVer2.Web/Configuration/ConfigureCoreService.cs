﻿using AutoMapper;
using InvestManager.ApplicatoinCore.Interfaces;
using InvestManager.ApplicatoinCore.Models;
using InvestManager.Infrastructure.Data;
using InvestManagerVer2.Web.Interfaces;
using InvestManagerVer2.Web.Models;
using InvestManagerVer2.Web.Repositories;
using InvestManagerVer2.Web.Services;

namespace InvestManagerVer2.Web.Configuration
{
    public static class ConfigureCoreService
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(InvestManagerRepository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IAssetService), typeof(AssetService));
            services.AddScoped(typeof(IAssetInPortfolioService), typeof(AssetInPortfolioService));
            services.AddScoped(typeof(IClientService), typeof(ClientService));
            services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
            services.AddScoped(typeof(IInvestPortfolioService), typeof(InvestPortfolioService));
            services.AddScoped(typeof(ITransactionService), typeof(TransectionService));
            services.AddScoped(typeof(IStatisticService), typeof(StatisticService));
            var config = new MapperConfiguration(cfg1 =>
            {
                cfg1.CreateMap<Category, CategoryViewModel>();
                cfg1.CreateMap<CategoryViewModel, Category>();
                cfg1.CreateMap<Statistics, StatisticsViewModel>();
                cfg1.CreateMap<StatisticsViewModel, Statistics>();
                cfg1.CreateMap<AssetInPortfolio, AssetInPortfolioService>();
                cfg1.CreateMap<AssetInPortfolioService, AssetInPortfolio>();
                cfg1.CreateMap<ClientService, Client>();
                cfg1.CreateMap<InvestManager.ApplicatoinCore.Models.Client, InvestManagerVer2.Web.Models.RegisterViewModel>();
                
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            return services;            
        }

    }
}
