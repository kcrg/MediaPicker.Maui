using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediaPicker.Maui.Sample.Models;
using MediaPicker.Maui.Services;
using System.Collections.ObjectModel;

namespace MediaPicker.Maui.Sample.ViewModels;

public partial class MainViewModel(ICapturePhotoService capturePhotoService) : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<ImageModel> _images = [];

    [RelayCommand]
    private async Task PickImages()
    {
        var imageStream = await capturePhotoService.CaptureAndCompressPhotoAsync(0.01f);

        if(imageStream is null)
        {
            return;
        }

        Images.Add(new(imageStream));
    }

    [RelayCommand]
    private void DeleteAll()
    {
       Images.Clear();
    }
}
