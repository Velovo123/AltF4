namespace SkillApp;

public partial class RequestPage : ContentPage
{
	public RequestPage()
	{
		InitializeComponent();
	}
    async void NavigateRoadmapPage(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new RoadmapPage(), true);
    }
    async void NatigateBack(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }
}