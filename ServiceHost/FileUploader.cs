using _0_Framework.Application;

namespace ServiceHost
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUploader(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public OperationResult Delete(string path)
        {
            var operation = new OperationResult();
            if (path == null || path == "") return operation.Failed("");

            var directoryPath = $"{_webHostEnvironment.WebRootPath}//Uploader//{path}";

            File.Delete(directoryPath);
            return operation.Succedded();
        }

        public string Upload(IFormFile file, string path, string name)
        {
            if (file == null) return "";

            var directoryPath = $"{_webHostEnvironment.WebRootPath}//Uploader//{path}";

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            string type = Path.GetExtension(file.FileName);
            if (type != ".webp" && type != ".ico")
                return "no";

            var fileName = $"{name}{type}";
            var filePath = $"{directoryPath}//{fileName}";
            using var output = File.Create(filePath);
            file.CopyTo(output);
            return $"{path}/{fileName}";
        }
    }
}