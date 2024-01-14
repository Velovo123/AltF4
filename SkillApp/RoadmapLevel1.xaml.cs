namespace SkillApp;

public partial class RoadmapLevel1 : ContentPage
{
	public RoadmapLevel1()
	{
		InitializeComponent();
	}
    async void NavigateBack(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }
}