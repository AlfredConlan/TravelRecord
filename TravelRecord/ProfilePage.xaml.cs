using TravelRecord.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecord
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            //base.OnAppearing();

            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{
            //    var postTable = conn.Table<Visited>().ToList();

            //    postCountLabel.Text = postTable.Count.ToString();
            //}
        }
    }
}