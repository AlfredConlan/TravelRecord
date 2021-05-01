using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecord
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void AddItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewTravelPage());
        }
    }
}