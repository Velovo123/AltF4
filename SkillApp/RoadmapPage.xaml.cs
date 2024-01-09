namespace SkillApp;

public partial class RoadmapPage : ContentPage
{
    RootObject obj;
    public RoadmapPage(RootObject obj)
    {
        InitializeComponent();
        this.obj = obj;
        BegginerSubtask1.Text = obj.Roadmap.Beginner.Tasks[0].Subtasks[0];
        BegginerSubtask2.Text = obj.Roadmap.Beginner.Tasks[0].Subtasks[1];
        BegginerSubtask3.Text = obj.Roadmap.Beginner.Tasks[0].Subtasks[2];
    }
    async void NatigateBack(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }
}