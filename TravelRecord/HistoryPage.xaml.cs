using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecord.Model;
using TravelRecord.Logic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TravelRecord.Helpers;
using System.Net.Http;

namespace TravelRecord
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var results = await VisitedLogic.RetrievePost();

            postListView.ItemsSource = results;
        }
    }
}
