using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using School.Service.Abstract;

namespace School.Service.Implemintation
{
    public class FileService : IFileService
    {
        #region Fileds
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _baseUrl;


        #endregion
        #region Constructors
        public FileService(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
            var request = _httpContextAccessor.HttpContext?.Request;
            _baseUrl = request != null ? $"{request.Scheme}://{request.Host}/" : "";

        }



        #endregion
        #region Handle Functions
        public async Task<string> UploadImage(string Location, IFormFile file)
        {
            var path = _webHostEnvironment.WebRootPath + "/" + Location + "/";
            var extention = Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid().ToString().Replace("-", string.Empty) + extention;
            if (file.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream filestreem = File.Create(path + fileName))
                    {
                        await file.CopyToAsync(filestreem);
                        await filestreem.FlushAsync();
                        return $"/{Location}/{fileName}";
                    }
                }
                catch (Exception)
                {
                    return "FailedToUploadImage";
                }
            }
            else
            {
                return "NoImage";
            }
        }
        public async Task<bool> DeleteImage(string imageUrl)
        {
            try
            {
                var filePath = imageUrl.Replace(_baseUrl, "").TrimStart('/');
                var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, filePath);

                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }

        }
        #endregion
    }
}
