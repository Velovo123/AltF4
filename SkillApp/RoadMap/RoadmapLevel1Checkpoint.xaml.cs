namespace SkillApp;

public partial class RoadmapLevel1Checkpoint : ContentPage
{
    RootObject obj;
    public RoadmapLevel1Checkpoint(RootObject obj)
	{
		InitializeComponent();

        this.obj = obj;

        BegginerMilestone0.Text = obj.Roadmap.Beginner.Milestones[0];
        BegginerMilestone1.Text = obj.Roadmap.Beginner.Milestones[1];
        BegginerMilestone2.Text = obj.Roadmap.Beginner.Milestones[2];
    }
    async void NavigateBack(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }
    async void NavigateMenu(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new MenuPage(), true);
    }
}