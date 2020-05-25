using System;
using Occupi.ViewModels;
using Occupi.Models;
using Xamarin.Forms;

namespace Occupi.Views
{
    public partial class VenuesPage : ContentPage
    {
        VenuesViewModel viewModel;

        public VenuesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new VenuesViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var venue = (Venue)layout.BindingContext;
            await Navigation.PushAsync(new VenueDetailsPage(new VenueDetailViewModel(venue)));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddVenuePage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Venues.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}