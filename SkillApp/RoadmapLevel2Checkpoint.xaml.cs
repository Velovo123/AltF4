namespace SkillApp;

public partial class RoadmapLevel2Checkpoint : ContentPage
{
    RootObject obj;
    public RoadmapLevel2Checkpoint(RootObject obj)
	{
		InitializeComponent();

        this.obj = obj;

        IntermediateMilestone0.Text = obj.Roadmap.Intermediate.Milestones[0];
        IntermediateMilestone1.Text = obj.Roadmap.Intermediate.Milestones[1];
        IntermediateMilestone2.Text = obj.Roadmap.Intermediate.Milestones[2];
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