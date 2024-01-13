namespace SkillApp;
public partial class BroadRequestPage : ContentPage
{
	public BroadRequestPage()
	{
		InitializeComponent();
	}
    async void NavigateRequestPage(System.Object sender, System.EventArgs e)
    {
        string requestField = RequestFieldEntry.Text;
        string desiredKnowledgeLevel = DesiredKnowledgeLevelEntry.Text;
        await Navigation.PushAsync(new RequestPage(requestField, desiredKnowledgeLevel), true);
    }
    async void NatigateBack(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }
}