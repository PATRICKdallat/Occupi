using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Occupi.Models;
using PAT.Portable.Services;

namespace Occupi
{
    public class MockDataStore : IDataStore<Venue>
    {
        readonly List<Venue> venues;

        public MockDataStore()
        {
            venues = new List<Venue>()
            {
                new Venue { Id = 1, Name = "Room 1", Description="This is an item description." },
                new Venue { Id = 2, Name = "Hall 2", Description="This is an item description." },
                new Venue { Id = 3, Name = "Arean 3", Description="This is an item description." },
                new Venue { Id = 4, Name = "Basement 4", Description="This is an item description." },
                new Venue { Id = 5, Name = "Attic 5", Description="This is an item description." },
                new Venue { Id = 6, Name = "Garden 6", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(Venue item)
        {
            venues.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Venue item)
        {
            var oldItem = venues.Where((Venue arg) => arg.Id == item.Id).FirstOrDefault();
            venues.Remove(oldItem);
            venues.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = venues.Where((Venue arg) => arg.Id == id).FirstOrDefault();
            venues.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Venue> GetItemAsync(int id)
        {
            return await Task.FromResult(venues.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Venue>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(venues);
        }
    }
}