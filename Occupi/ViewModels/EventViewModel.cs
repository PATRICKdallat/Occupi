using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Occupi.Portable.Models;
using Occupi.Views;
using Xamarin.Forms;

namespace Occupi.ViewModels
{
    public class EventViewModel : BaseViewModel
    {
        public ObservableCollection<Event> Events { get; set; }
        public Command LoadItemsCommand { get; set; }

        public EventViewModel()
        {
            Title = "Events";
            Events = new ObservableCollection<Event>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<AddEventPage, Event>(this, "AddEvent", async (obj, eventItem) =>
            {
                var newEvent = eventItem as Event;
                Events.Add(newEvent);
                await EventDataStore.AddItemAsync(newEvent);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Events.Clear();
                var events = await EventDataStore.GetItemsAsync(true);
                foreach (var eventItem in events)
                {
                    Events.Add(eventItem);
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
