﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Warhammer_Army_Manager.Services;
using Warhammer_Army_Manager.ViewModels;
using Warhammer_Army_Manager.Views;
using Warhammer_Army_Manager.Database;
using Warhammer_Army_Manager.Database.Models;
using System.Windows.Input;

namespace Warhammer_Army_Manager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            ServiceCollection services = new();

            services.AddSingleton<MainWindow>(provider => new MainWindow()
            {
                DataContext = provider.GetRequiredService<MainWindowViewModel>()
            }); 

            // view models
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<DashboardViewModel>();
            services.AddSingleton<ArmyViewModel>();
            services.AddSingleton<ArmyAddViewModel>();
            services.AddSingleton<UnitViewModel>();
            services.AddSingleton<WeaponViewModel>();
            services.AddSingleton<KeywordViewModel>();
            services.AddSingleton<KeywordAddViewModel>();
            services.AddSingleton<KeywordAddView>(provider => new KeywordAddView()
            {
                DataContext = provider.GetRequiredService<KeywordAddViewModel>()
            });
            services.AddSingleton<UnitAddViewModel>();
            services.AddSingleton<UnitAddView>(provider => new UnitAddView()
            {
                DataContext = provider.GetRequiredService<UnitAddViewModel>()
            });


            // actual services
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<Func<Type, ViewModel>>(serviceProvider => viewModelType => (ViewModel)serviceProvider.GetRequiredService(viewModelType));
            services.AddSingleton<ViewModelLocator>();


            _serviceProvider = services.BuildServiceProvider();

            /* save for later
            addSampleData();
            */
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow mw = _serviceProvider.GetService<MainWindow>()!;
            mw.Show();
        }

        private static void addSampleData()
        {

            using (var context = new ApplicationDbContext())
            {
                context.Database.EnsureCreated();

                string unitName = "TestBlubberDUmpfbacke";
                if (!context.Units.Any(unit => unit.Name == unitName))
                {
                    var unitHorses = new Unit
                    {
                        Name = unitName,
                        Wounds = 10,
                        Move = 8,
                        Bravery = 9,
                        Save = "1+",
                    };
                    context.Units.Add(unitHorses);
                }

                if (!context.Keywords.Any(keyword => keyword.Name == "Tag01"))
                {
                    var tagTest = new Keyword
                    {
                        Name = "TestKeywordAKATagROFLOL"
                    };
                    context.Keywords.Add(tagTest);
                }

                context.SaveChanges();
            }
        }
    }
}
