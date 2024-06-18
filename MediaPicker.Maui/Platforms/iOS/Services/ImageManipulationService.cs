using Foundation;
using MediaPicker.Maui.Services;
using UIKit;

namespace MediaPicker.Maui.Platforms.iOS.Services;

public class ImageManipulationService : IImageManipulationService
{
    public async Task<Stream?> CompressImageAsync(string imagePath, float quality)
    {
        var originalImage = UIImage.FromFile(imagePath);

        if (originalImage == null)
        {
            throw new Exception("Failed to load image");
        }

        string extension = Path.GetExtension(imagePath).ToLower();
        NSData? imgData = extension switch
        {
            ".png" => originalImage.AsPNG(),
            ".webp" => originalImage.AsJPEG(quality), // iOS does not natively support WebP
            _ => originalImage.AsJPEG(quality)
        };

        if (imgData == null)
        {
            throw new Exception("Failed to compress image");
        }

        var compressedStream = new MemoryStream([.. imgData]);
        compressedStream.Seek(0, SeekOrigin.Begin);

        return compressedStream;
    }
}