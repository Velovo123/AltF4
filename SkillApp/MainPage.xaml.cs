namespace SkillApp
{
    public partial class MainPage : ContentPage
    {   
        public MainPage()
        {
            InitializeComponent();
        }
        async void NavigateRequestPage(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new RequestPage(), true);
        }
    }

}
