namespace SkillApp;
public partial class RequestPage : ContentPage
{
    string requestField;
    string desiredKnowledgeLevel;

    public RequestPage(string requestField, string desiredKnowledgeLevel)
	{
		InitializeComponent();
        this.requestField = requestField;
        this.desiredKnowledgeLevel = desiredKnowledgeLevel;
	}
    async void NavigateRoadmapPage(System.Object sender, System.EventArgs e)
    {
        string requestGeneral = RequestEntry.Text;
        if (Operator.IsValidInput(requestGeneral))
        {
			var generateTask = System.Threading.Tasks.Task.Run(async () =>
			{
				int dotsCount = 0;

				while (!Operator.GenerationSuccess)
				{
					Dispatcher.Dispatch(() =>
					{
						CompleteBtn.Text = "Loading" + new string('.', dotsCount % 3 + 1);
						dotsCount++;
					});

					await System.Threading.Tasks.Task.Delay(500);
				}
			});
			var obj = await Operator.GenerateRoadMap(requestField, desiredKnowledgeLevel, requestGeneral);
            await Navigation.PushAsync(new VisualRoadmap(obj), true);
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