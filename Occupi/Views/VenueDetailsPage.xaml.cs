using Occupi.Models;
using Occupi.ViewModels;
using Xamarin.Forms;

namespace Occupi.Views
{
    public partial class VenueDetailsPage : ContentPage
    {
        VenueDetailViewModel viewModel;

        public VenueDetailsPage()
        {
            InitializeComponent();

            var venue = new Venue
            {
                Name = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new VenueDetailViewModel(venue);
            BindingContext = viewModel;
        }

        public VenueDetailsPage(VenueDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}
