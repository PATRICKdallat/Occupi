using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Occupi.Models;
using Occupi.Views;
using Xamarin.Forms;

namespace Occupi.ViewModels
{
    public class VenuesViewModel : BaseViewModel
    {
        public ObservableCollection<Venue> Venues { get; set; }
        public Command LoadItemsCommand { get; set; }

        public VenuesViewModel()
        {
            Title = "Venues";
            Venues = new ObservableCollection<Venue>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<AddVenuePage, Venue>(this, "AddVenue", async (obj, venue) =>
            {
                var newVenue = venue as Venue;
                Venues.Add(newVenue);
                await VenueDataStore.AddItemAsync(newVenue);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Venues.Clear();
                var venues = await VenueDataStore.GetItemsAsync(true);
                foreach (var venue in venues)
                {
                    Venues.Add(venue);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
