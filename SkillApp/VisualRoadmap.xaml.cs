namespace SkillApp;

public partial class VisualRoadmap : ContentPage
{
	public VisualRoadmap()
	{
		InitializeComponent();
	}

    async void NatigateBack(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }
}