using MediaPicker.Maui.Services;
using MediaPicker.Maui.Services.Implementations;

#if ANDROID
using MediaPicker.Maui.Platforms.Android.Services;
#endif
#if IOS
using MediaPicker.Maui.Platforms.iOS.Services;
#endif

namespace MediaPicker.Maui;

public static class MediaPickerSetup
{
    public static MauiAppBuilder UseMediaPicker(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<ICapturePhotoService, CapturePhotoService>();
        builder.Services.AddTransient<IImageManipulationService, ImageManipulationService>();
        return builder;
    }
}
