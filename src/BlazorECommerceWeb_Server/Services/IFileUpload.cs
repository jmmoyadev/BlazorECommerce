using Microsoft.AspNetCore.Components.Forms;

namespace BlazorECommerceWeb_Server.Services;

public interface IFileUpload
{
    Task<string> UploadFile(IBrowserFile file);
    Task<bool> DeleteFile(string filePath);
}
