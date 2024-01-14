namespace SkillApp;

public partial class VisualRoadmap : ContentPage
{
    RootObject obj;
    public VisualRoadmap(RootObject obj)
	{
		InitializeComponent();
        this.obj = obj;
    }
    async void NavigateLevel1(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new RoadmapLevel1(obj), true);
    }
    async void NavigateLevel1Checkpoint(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new RoadmapLevel1Checkpoint(obj), true);
    }
    async void NavigateLevel2(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new RoadmapLevel2(obj), true);
    }
    async void NavigateLevel2Checkpoint(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new RoadmapLevel2Checkpoint(obj), true);
    }
    async void NavigateLevel3(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new RoadmapLevel3(obj), true);
    }
    async void NavigateLevel3Checkpoint(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new RoadmapLevel3Checkpoint(obj), true);
    }
    async void NavigateLevel4(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new RoadmapLevel4(obj), true);
    }

    async void NavigateBack(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }
}