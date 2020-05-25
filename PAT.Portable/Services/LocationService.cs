using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PAT.Portable.Services;
using Xamarin.Essentials;

[assembly: Xamarin.Forms.Dependency(typeof(LocationService))]
namespace PAT.Portable.Services
{
    public class LocationService : ILocationService
    {
        public async Task<Location> GetLastLocationAsync()
        {
            try
            {
                return await Geolocation.GetLastKnownLocationAsync();
            }
            catch (Exception)
            {
                return new Location();
            }
        }

        public async Task<Location> GetAcurateLocationAsync(GeolocationAccuracy accuracy)
        {
            try
            { 
                var request = new GeolocationRequest(accuracy);
                return await Geolocation.GetLocationAsync(request);
            }
            catch (Exception)
            {
                return new Location();
            }
        }

        //public async Task<Position> GetAcuratePositionAsync(GeolocationAccuracy accuracy)
        //{
        //    try
        //    {
        //        var request = new GeolocationRequest(accuracy);
        //        var location = await Geolocation.GetLocationAsync(request);
        //        return new Position(location.Latitude, location.Longitude);
        //    }
        //    catch (Exception exception)
        //    {
        //        throw exception;
        //    }
        //}

        public async Task<Location> GetFirstLocationForAddressAsync(string address)
        {
            try
            {
                var locations = await Geocoding.GetLocationsAsync(address);
                return locations.FirstOrDefault();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<Location>> GetLocationsForAddressAsync(string address)
        {
            try
            {
                var locations = await Geocoding.GetLocationsAsync(address);
                return locations;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        //public async Task<Position> GetFirstPositionForAddressAsync(string address)
        //{
        //    try
        //    {
        //        var locations = await Geocoding.GetLocationsAsync(address);
        //        var location = locations.FirstOrDefault();
        //        return new Position(location.Latitude, location.Longitude);
        //    }
        //    catch (Exception exception)
        //    {
        //        throw exception;
        //    }
        //}
        //public async Task<IEnumerable<Position>> GetPositionsForAddressAsync(string address)
        //{
        //    try
        //    {
        //        var locations = await Geocoding.GetLocationsAsync(address);
        //        return locations.Select(l => new Position(l.Latitude, l.Longitude));
        //    }
        //    catch (Exception exception)
        //    {
        //        throw exception;
        //    }
        //}
    }
}
