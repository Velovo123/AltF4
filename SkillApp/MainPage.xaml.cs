namespace SkillApp
{
    public partial class MainPage : ContentPage
    {
        //int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        async void NavigateSettings(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new StettingsPage(), true);
        }

        async void NavigatePremium(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PremiumPage(), true);
        }

    }

}
