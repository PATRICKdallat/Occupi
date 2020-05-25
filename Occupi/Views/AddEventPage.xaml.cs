using System;
using Occupi.Models;
using Xamarin.Forms;

namespace Occupi.Views
{
    public partial class AddEventPage : ContentPage
    {
        public Event Event { get; set; }

        public AddEventPage()
        {
            InitializeComponent();

            Event = new Event
            {
                Name = "Event name",
                DateCreated = DateTimeOffset.UtcNow,
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddEvent", Event);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}