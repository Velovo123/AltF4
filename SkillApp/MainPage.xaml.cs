namespace SkillApp
{
    public partial class MainPage : ContentPage
    {   
        public MainPage()
        {
            InitializeComponent();
        }
        async void NavigateBroadRequestPage(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new BroadRequestPage(), true);
        }
        async void NavigateRoadmapSelectionPage(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new RoadmapSelectionPage(), true);
        }
    }

}
