using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace PAT.Portable.Services
{
    public interface ILocationService
    {
        Task<Location> GetLastLocationAsync();
        Task<Location> GetAcurateLocationAsync(GeolocationAccuracy accuracy);
        //Task<Position> GetAcuratePositionAsync(GeolocationAccuracy accuracy);

        Task<Location> GetFirstLocationForAddressAsync(string address);
        Task<IEnumerable<Location>> GetLocationsForAddressAsync(string address);

        //Task<Position> GetFirstPositionForAddressAsync(string address);
        //Task<IEnumerable<Position>> GetPositionsForAddressAsync(string address);
    }
}