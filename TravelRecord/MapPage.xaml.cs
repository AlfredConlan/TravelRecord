using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using TravelRecord.Logic;
using TravelRecord.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecord
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private bool hasLocationPermission = false;
        public MapPage()
        {
            InitializeComponent();

            GetPermissions();
        }

        private async void GetPermissions()
        {
            try
            {
#pragma warning disable CS0618 // Type or member is obsolete
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);
#pragma warning restore CS0618 // Type or member is obsolete
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
                    {
                        await DisplayAlert("Location Needed", "We need to access your location", "Ok");
                    }
#pragma warning disable CS0618 // Type or member is obsolete
                    var result = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse);
#pragma warning restore CS0618 // Type or member is obsolete
                    if (result.ContainsKey(Permission.LocationWhenInUse))
                    {
                        status = result[Permission.LocationWhenInUse];
                    }
                }
                if (status == PermissionStatus.Granted)
                {
                    hasLocationPermission = true;
                    locationsMap.IsShowingUser = true;

                    GetLocation();
                }
                else
                {
                    await DisplayAlert("Location Needed", "We need to access your location", "Ok");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;

                locator.PositionChanged += Locator_PositionChanged;
                await locator.StartListeningAsync(TimeSpan.Zero, 100);
            }

            GetLocation();

            var results = await VisitedLogic.RetrievePost();

            DisplayInMap(results);
        }

        private void DisplayInMap(List<Visited> posts)
        {
            foreach (var post in posts)
            {
                try
                {
                    var position = new Xamarin.Forms.Maps.Position(post.Latitude, post.Longitude);

                    var pin = new Xamarin.Forms.Maps.Pin()
                    {
                        Type = Xamarin.Forms.Maps.PinType.SavedPin,
                        Position = position,
                        Label = post.VenueName,
                        Address = post.Address
                    };

                    locationsMap.Pins.Add(pin);
                }
                catch (NullReferenceException nre) 
                {
                    DisplayAlert("Error", nre.Message, "Ok");
                }
                catch (Exception ex) 
                {
                    DisplayAlert("Error", ex.Message, "Ok");
                }
            }
        }

        protected override void OnDisappearing()
        {
            CrossGeolocator.Current.StopListeningAsync();
            CrossGeolocator.Current.PositionChanged -= Locator_PositionChanged;
        }

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            MoveMap(e.Position);
        }

        private async void GetLocation()
        {
            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                var position = await locator.GetPositionAsync();

                MoveMap(position);
            }
        }

        private void MoveMap(Position position)
        {
            var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
            locationsMap.MoveToRegion(new Xamarin.Forms.Maps.MapSpan(center, .1, .1));
        }
    }
}