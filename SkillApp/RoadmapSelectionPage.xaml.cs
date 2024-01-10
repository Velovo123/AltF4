namespace SkillApp;

public partial class RoadmapSelectionPage : ContentPage
{
	public RoadmapSelectionPage()
	{
		InitializeComponent();
	}
    async void NatigateBack(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }
}