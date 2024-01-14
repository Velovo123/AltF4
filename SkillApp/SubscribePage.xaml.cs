namespace SkillApp;

public partial class SubscribePage : ContentPage
{
	public SubscribePage()
	{
		InitializeComponent();

	}

    async void NatigateBack(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }
}