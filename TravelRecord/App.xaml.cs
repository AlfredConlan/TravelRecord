using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TravelRecord.Repository;
using TravelRecord.Repository.IRepsitory;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecord
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string databaseLocation)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            DatabaseLocation = databaseLocation;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<IVisitedRepository, VisitedRepository>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
