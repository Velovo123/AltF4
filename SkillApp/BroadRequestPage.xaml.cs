using Microsoft.Maui.Controls;
using Microsoft.Maui.Platform;

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

		if (Operator.IsValidInput(requestField) && Operator.IsValidInput(desiredKnowledgeLevel) 
			&& !(RequestFieldEntry.Text == null && DesiredKnowledgeLevelEntry.Text == null))
		{
			await Navigation.PushAsync(new RequestPage(requestField, desiredKnowledgeLevel), true);
		}
		else
		{
			Color color = CompleteBtn.BackgroundColor;
			CompleteBtn.Background = new SolidColorBrush(Colors.Red);
			await System.Threading.Tasks.Task.Delay(400);
			CompleteBtn.Background = new SolidColorBrush(color);
		}

	}


	async void NatigateBack(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }
    async void NavigateMenu(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new MenuPage(), true);
    }
}