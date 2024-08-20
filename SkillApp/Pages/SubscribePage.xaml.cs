namespace SkillApp;

public partial class SubscribePage : ContentPage
{
	public SubscribePage()
	{
		InitializeComponent();

	}
    async void NavigateMenu(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new MenuPage(), true);
    }
    async void NatigateBack(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }
}