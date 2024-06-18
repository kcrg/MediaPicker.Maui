namespace MediaPicker.Maui.Sample.Models;

public class ImageModel(Stream imageStream)
{
    public Stream? ImageStream { get; set; } = imageStream;

    public ImageSource ImageSource => ImageSource.FromStream(() => ImageStream);
}
