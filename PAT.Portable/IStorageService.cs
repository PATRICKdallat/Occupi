using System;
using System.Threading.Tasks;

namespace PAT.Portable.Services
{
    public interface IStorageService
    {
        void ClearPreferences();
        void ClearPreferences(string containerToClear);
        void ClearSecuredStorageValue();
        Task CopyToClipboard(string text);
        string GetCacheDirectoryFilePath(string fileName);
        string GetDataDirectoryFilePath(string fileName);
        int GetPreference(string key, int value);
        bool GetPreference(string key, bool value);
        long GetPreference(string key, long value);
        float GetPreference(string key, float value);
        double GetPreference(string key, double value);
        string GetPreference(string key, string value);
        DateTime GetPreference(string key, DateTime value);
        int GetPreference(string key, int value, string container);
        bool GetPreference(string key, bool value, string container);
        long GetPreference(string key, long value, string container);
        float GetPreference(string key, float value, string container);
        double GetPreference(string key, double value, string container);
        string GetPreference(string key, string value, string container);
        DateTime GetPreference(string key, DateTime value, string container);
        Task<string> GetSecuredStorageValue(string key);
        Task<string> PasteFromClipboard(string text);
        Task<string> ReadFileFromAppPackage(string fileName);
        void RemovePreference(string key);
        void RemovePreferences(string key, string container);
        void SaveFileToCacheDirectory(string fileName, string text);
        void SaveFileToDataDirectory(string fileName, string text);
        void SetPreference(string key, int value);
        void SetPreference(string key, long value);
        void SetPreference(string key, bool value);
        void SetPreference(string key, float value);
        void SetPreference(string key, double value);
        void SetPreference(string key, string value);
        void SetPreference(string key, DateTime value);
        void SetPreference(string key, int value, string container);
        void SetPreference(string key, long value, string container);
        void SetPreference(string key, bool value, string container);
        void SetPreference(string key, float value, string container);
        void SetPreference(string key, double value, string container);
        void SetPreference(string key, string value, string container);
        void SetPreference(string key, DateTime value, string container);
        Task SetSecuredStorageValue(string key, string value);
    }
}