using System.IO;
using System.Threading.Tasks;
using PAT.Portable.Services.Interfaces;
using Xamarin.Essentials;

namespace PAT.Portable.Services
{
    public class FileService : IFileService
    {
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
