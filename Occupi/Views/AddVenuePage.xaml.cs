using System;
using Xamarin.Forms;
using Occupi.Portable.Models;

namespace Occupi.Views
{
    public partial class AddVenuePage : ContentPage
    {
        public Venue Venue { get; set; }

        public AddVenuePage()
        {
            InitializeComponent();

            Venue = new Venue
            {
                Name = "Room name",
                Description = "New room description."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddVenue", Venue);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}