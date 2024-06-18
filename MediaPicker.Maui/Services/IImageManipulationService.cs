namespace MediaPicker.Maui.Services;

public interface IImageManipulationService
{
    public Task<Stream?> CompressImageAsync(string imagePath, float quality);
}
