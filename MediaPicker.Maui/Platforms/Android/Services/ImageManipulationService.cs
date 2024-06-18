using Android.Graphics;
using MediaPicker.Maui.Services;

namespace MediaPicker.Maui.Platforms.Android.Services;

public class ImageManipulationService : IImageManipulationService
{
    public async Task<Stream?> CompressImageAsync(string imagePath, float quality)
    {
        Bitmap? originalImage = await BitmapFactory.DecodeFileAsync(imagePath);

        if (originalImage == null)
        {
            Console.WriteLine("Compress photo failed: could not decode image");
            return null;
        }

        string extension = System.IO.Path.GetExtension(imagePath).ToLower();
        Bitmap.CompressFormat compressFormat = extension switch
        {
            ".png" => Bitmap.CompressFormat.Png,
            ".webp" => Bitmap.CompressFormat.Webp,
            _ => Bitmap.CompressFormat.Jpeg
        };

        var compressedStream = new MemoryStream();
        originalImage.Compress(compressFormat, (int)(quality * 100), compressedStream);
        compressedStream.Seek(0, SeekOrigin.Begin);

        return compressedStream;
    }
}
