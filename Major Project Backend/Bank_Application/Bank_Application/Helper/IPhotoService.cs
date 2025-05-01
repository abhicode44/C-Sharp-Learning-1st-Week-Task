using CloudinaryDotNet.Actions;


namespace Bank_Application.Helper


{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
    }
}
