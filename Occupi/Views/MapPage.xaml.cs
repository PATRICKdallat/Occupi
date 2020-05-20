using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using System.Collections.Generic;
using Occupi.Portable.Models;
using System.Threading.Tasks;
using Xamarin.Essentials;
using PAT.Services;

namespace Occupi.Views
{
    public partial class MapPage : ContentPage
    {
        private ILocationService _locationService = DependencyService.Get<ILocationService>();
        private IPermissionService _permissionService = DependencyService.Get<IPermissionService>();

        private List<Venue> Venues = new List<Venue>();
        private Xamarin.Forms.GoogleMaps.Map GoogleMap;

        public MapPage()
        {
            InitializeComponent();
        }

        public MapPage(List<Venue> venues)
        {
            InitializeComponent();

            Venues = venues;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            
            Title = "Venue Map";

            var permission = await _permissionService.CheckAndRequestPermissionAsync<Permissions.LocationWhenInUse>();
            
            if (permission)
            {
                InitializeGoogleMap();

                MapContainer.Children.Add(GoogleMap);

                UpdateVenuePinOnMap(Venues);

                InitializeMapUISettings();

                await MoveCameraToCurrentLocationAsync();
            }
        }

        private void InitializeMapUISettings()
        {
            GoogleMap.UiSettings.MyLocationButtonEnabled = true;
            GoogleMap.UiSettings.CompassEnabled = true;
            GoogleMap.UiSettings.ZoomControlsEnabled = true;
            GoogleMap.MyLocationEnabled = true;
        }

        private void UpdateVenuePinOnMap(List<Venue> Venues)
        {
            Venues.ForEach((venue) =>
            {
                GoogleMap.Pins.Add(new Pin
                {
                    Label = venue.Name
                });
            });
        }

        private async Task MoveCameraToCurrentLocationAsync()
        {
            var location = await _locationService.GetAcurateLocationAsync(GeolocationAccuracy.Best);
            var position = new Position(location.Latitude,location.Longitude);
            GoogleMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMeters(10000)), false);
        }

        private void InitializeGoogleMap()
        {
            GoogleMap = new Xamarin.Forms.GoogleMaps.Map
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
        }
    }
}
