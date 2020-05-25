using Occupi.Models;

namespace Occupi.ViewModels
{
    public class VenueDetailViewModel : BaseViewModel
    {
        public Venue Venue { get; set; }
        public VenueDetailViewModel(Venue venue = null)
        {
            Title = venue?.Name;
            Venue = venue;
        }
    }
}
