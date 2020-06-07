using System.Threading.Tasks;

namespace PAT.Portable.Services.Interfaces
{
    public interface IFileService
    {
        string GetCacheDirectoryFilePath(string fileName);
        string GetDataDirectoryFilePath(string fileName);
        Task<string> ReadFileFromAppPackage(string fileName);
        void SaveFileToCacheDirectory(string fileName, string text);
        void SaveFileToDataDirectory(string fileName, string text);
    }
}
