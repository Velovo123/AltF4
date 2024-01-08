namespace SkillApp;

public partial class RoadmapPage : ContentPage
{
    public RoadmapPage()
    {
        InitializeComponent();
    }
    async void NatigateBack(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }
}