
using Microsoft.AspNetCore.Components.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace BlazorECommerceWeb_Server.Services;

public class FileUpload : IFileUpload
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileUpload(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<string> UploadFile(IBrowserFile file)
    {
        FileInfo fileInfo = new FileInfo(file.Name);

        var fileName = Guid.NewGuid().ToString() + fileInfo.Extension;

        var folderDirectory = $"{_webHostEnvironment.WebRootPath}\\upload\\images\\products";

        if (!Directory.Exists(folderDirectory))
        {
            Directory.CreateDirectory(folderDirectory);
        }

        var filePath = Path.Combine(folderDirectory, fileName);

        await using FileStream fs = new FileStream(filePath, FileMode.Create);
        await file.OpenReadStream().CopyToAsync(fs);

        var fullPath = $"/upload/images/products/{fileName}";

        return fullPath;



    }
    public async Task<bool> DeleteFile(string fileName)
    {
        var filePath = Path.Combine($"{_webHostEnvironment.WebRootPath}\\upload\\images\\products\\{fileName}");
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            return await Task.FromResult(true);
        }
        return await Task.FromResult(false);
    }
}
