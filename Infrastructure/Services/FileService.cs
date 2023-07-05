using TaskApi.Shared.DTOs;

namespace TaskApi.Infrastructure.Services
{
    public interface IFileService
    {
        Task<string> AddSiteObjectAsync(IFormFile file, string type);
        bool DeleteSiteObject(string url);
    }
    public class FileService : IFileService
    {
        //object
        public async Task<string> AddSiteObjectAsync(IFormFile file, string type)
        {
            var folderName = Path.Combine("Assets", type);
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (file?.Length > 0)
            {
                var fileName = $"{GetTimestamp()}_{file.FileName}";
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);

                await using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return dbPath;
            }

            return "";
        }

        public bool DeleteSiteObject(string url)
        {
            var response = true;

            var path = Path.Combine(Directory.GetCurrentDirectory(), url);

            try
            {
                File.Delete(path);
            }
            catch (Exception)
            {
                response = false;
            }

            return response;
        }

        private string GetTimestamp()
        {
            var dateToString = DateTime.UtcNow.ToString("yyyyMMddHHmmssffff");
            return dateToString;
        }
    }
}
