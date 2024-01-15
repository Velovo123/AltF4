namespace SkillApp;

public partial class MenuPage : ContentPage
{
	public MenuPage()
	{
		InitializeComponent();
	}
    async void NavigateBack(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }
    async void NavigateMenu(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new MenuPage(), true);
    }
    async void NavigateHomePage(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new MainPage(), true);
    }
    async void NavigateListPage(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new RoadmapSelectionPage(), true);
    }
    //async void NavigateSubscribePage(System.Object sender, System.EventArgs e)
    //{
    //    await Navigation.PushAsync(new SubscribePage(), true);
    //}
}