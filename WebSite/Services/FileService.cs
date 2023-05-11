using static System.Net.Mime.MediaTypeNames;

namespace WebSite.Services
{
    public class FileService
    {

        private static readonly string[] allowedExtensions = { ".jpg", ".png", ".gif", ".jpeg", ".jfif", ".webp" };
        private static readonly int maxFileSize = 800000;

        public static string UploadFile(IFormFile file, string webRootPath, string folder, string slug, string oldImg)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }

            string extension = Path.GetExtension(file.FileName);
            string fileName = $"{Path.GetFileNameWithoutExtension(slug)}{extension}";
            string filePath = Path.Combine(webRootPath, "assets", "img", folder, fileName);

            if (!allowedExtensions.Contains(extension))
            {
                throw new ArgumentException($"File extension {extension} is not allowed.");
            }

            if (file.Length > maxFileSize)
            {
                throw new ArgumentException($"File size is too large. Maximum allowed size is {maxFileSize} bytes.");
            }


            string oldFilePath = Path.Combine(webRootPath, oldImg);
            string defaultFilePath = Path.Combine(webRootPath, "assets", "img", folder, "default.jpg").Replace("/", "\\");

            string rootPath = @"C:\Users\Anatolii\source\repos\WebSite-MyPortfolio\WebSite\wwwroot";
            string oldFileAbsPath = Path.Combine(rootPath, oldFilePath.TrimStart('/'));

            if (oldImg != defaultFilePath)
            {
                if (File.Exists(oldFileAbsPath))
                {
                    File.Delete(oldFileAbsPath);
                }
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return $"/assets/img/{folder}/{fileName}";
        }
    }
}