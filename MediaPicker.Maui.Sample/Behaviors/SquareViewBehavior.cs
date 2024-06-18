namespace MediaPicker.Maui.Sample.Behaviors;

public class SquareViewBehavior : Behavior<View>
{
    protected override void OnAttachedTo(View bindable)
    {
        base.OnAttachedTo(bindable);
        bindable.SizeChanged += OnSizeChanged;
    }

    protected override void OnDetachingFrom(View bindable)
    {
        base.OnDetachingFrom(bindable);
        bindable.SizeChanged -= OnSizeChanged;
    }

    private static void OnSizeChanged(object? sender, EventArgs e)
    {
        if (sender is not View view)
        {
            return;
        }

        view.HeightRequest = view.Width;
    }
}
