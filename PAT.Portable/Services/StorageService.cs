using System;
using System.IO;
using System.Threading.Tasks;
using PAT.Services;
using Xamarin.Essentials;

namespace PAT.Portable.Services
{
    public class StorageService : IStorageService
    {
        public async Task CopyToClipboard(string text) => await Clipboard.SetTextAsync(text);
        public async Task<string> PasteFromClipboard(string text) => await Clipboard.GetTextAsync();

        public int GetPreference(string key, int value) => Preferences.Get(key, value);
        public bool GetPreference(string key, bool value) => Preferences.Get(key, value);
        public long GetPreference(string key, long value) => Preferences.Get(key, value);
        public float GetPreference(string key, float value) => Preferences.Get(key, value);
        public double GetPreference(string key, double value) => Preferences.Get(key, value);
        public string GetPreference(string key, string value) => Preferences.Get(key, value);
        public DateTime GetPreference(string key, DateTime value) => Preferences.Get(key, value);

        public int GetPreference(string key, int value, string container) => Preferences.Get(key, value, container);
        public bool GetPreference(string key, bool value, string container) => Preferences.Get(key, value, container);
        public long GetPreference(string key, long value, string container) => Preferences.Get(key, value, container);
        public float GetPreference(string key, float value, string container) => Preferences.Get(key, value, container);
        public double GetPreference(string key, double value, string container) => Preferences.Get(key, value, container);
        public string GetPreference(string key, string value, string container) => Preferences.Get(key, value, container);
        public DateTime GetPreference(string key, DateTime value, string container) => Preferences.Get(key, value, container);

        public void SetPreference(string key, int value) => Preferences.Set(key, value);
        public void SetPreference(string key, long value) => Preferences.Set(key, value);
        public void SetPreference(string key, bool value) => Preferences.Set(key, value);
        public void SetPreference(string key, float value) => Preferences.Set(key, value);
        public void SetPreference(string key, double value) => Preferences.Set(key, value);
        public void SetPreference(string key, string value) => Preferences.Set(key, value);
        public void SetPreference(string key, DateTime value) => Preferences.Set(key, value);

        public void SetPreference(string key, int value, string container) => Preferences.Set(key, value, container);
        public void SetPreference(string key, long value, string container) => Preferences.Set(key, value, container);
        public void SetPreference(string key, bool value, string container) => Preferences.Set(key, value, container);
        public void SetPreference(string key, float value, string container) => Preferences.Set(key, value, container);
        public void SetPreference(string key, double value, string container) => Preferences.Set(key, value, container);
        public void SetPreference(string key, string value, string container) => Preferences.Set(key, value, container);
        public void SetPreference(string key, DateTime value, string container) => Preferences.Set(key, value, container);

        public void ClearPreferences() => Preferences.Clear();
        public void ClearPreferences(string containerToClear) => Preferences.Clear(containerToClear);

        public void RemovePreference(string key) => Preferences.Remove(key);
        public void RemovePreferences(string key, string container) => Preferences.Remove(key, container);


        public async Task<string> GetSecuredStorageValue(string key) => await SecureStorage.GetAsync(key);

        public async Task SetSecuredStorageValue(string key, string value) => await SecureStorage.SetAsync(key, value);

        public void ClearSecuredStorageValue() => SecureStorage.RemoveAll();

        public async Task<string> ReadFileFromAppPackage(string fileName)
        {
            string file = "";
            using (var stream = await FileSystem.OpenAppPackageFileAsync(fileName))
            {
                using (var reader = new StreamReader(stream))
                {
                    file = await reader.ReadToEndAsync();
                }
            }
            return file;
        }

        public string GetCacheDirectoryFilePath(string fileName)
        {
            var filePath = Path.Combine(FileSystem.CacheDirectory, fileName);
            return File.ReadAllText(filePath);
        }

        public string GetDataDirectoryFilePath(string fileName)
        {
            var filePath = Path.Combine(FileSystem.AppDataDirectory, fileName);
            return File.ReadAllText(filePath);
        }

        public void SaveFileToCacheDirectory(string fileName, string text)
        {
            var filePath = Path.Combine(FileSystem.CacheDirectory, fileName);
            File.WriteAllText(filePath, text);
        }

        public void SaveFileToDataDirectory(string fileName, string text)
        {
            var filePath = Path.Combine(FileSystem.AppDataDirectory, fileName);
            File.WriteAllText(filePath, text);
        }
    }
}
