namespace SkillApp;

public partial class RoadmapLevel3Checkpoint : ContentPage
{
    RootObject obj;
    public RoadmapLevel3Checkpoint(RootObject obj)
	{
		InitializeComponent();

        this.obj = obj;

        AdvancedMilestone0.Text = obj.Roadmap.Advanced.Milestones[0];
        AdvancedMilestone1.Text = obj.Roadmap.Advanced.Milestones[1];
        AdvancedMilestone2.Text = obj.Roadmap.Advanced.Milestones[2];
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