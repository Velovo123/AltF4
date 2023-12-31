namespace SkillApp
{
    public partial class MainPage : ContentPage
    {
        //int count = 0;
        
        public MainPage()
        {
            InitializeComponent();
        }
        async void NavigateRoadmapPage(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new RoadmapPage(), true);
        }
        async void NavigateRequestPage(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new RequestPage(), true);
        }
    }

}
