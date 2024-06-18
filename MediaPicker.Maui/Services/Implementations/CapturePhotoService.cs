namespace MediaPicker.Maui.Services.Implementations;

public class CapturePhotoService(IImageManipulationService imageManipulationService) : ICapturePhotoService
{
    public async Task<Stream?> CaptureAndCompressPhotoAsync(float quality = 0.8f)
    {
        try
        {
            var photo = await Microsoft.Maui.Media.MediaPicker.CapturePhotoAsync();
            return photo == null ? null : await imageManipulationService.CompressImageAsync(photo.FullPath, quality);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., permissions, no camera, etc.)
            Console.WriteLine($"Capture photo failed: {ex.Message}");
            return null;
        }
    }
}