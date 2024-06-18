namespace MediaPicker.Maui.Services;

public interface ICapturePhotoService
{
    public Task<Stream?> CaptureAndCompressPhotoAsync(float quality = 0.8f);
}
