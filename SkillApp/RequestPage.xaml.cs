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
        CompleteBtn.Text = "Loading...";
        var obj = await Operator.GenerateRoadMap(requestField, desiredKnowledgeLevel, requestGeneral);
        await Navigation.PushAsync(new RoadmapPage(obj), true);
    }

    //async void NavigatePleaseWaitPage(System.Object sender, System.EventArgs e)
    //{
    //    string requestGeneral = RequestEntry.Text;
    //    var obj = await Operator.GenerateRoadMap(requestField, desiredKnowledgeLevel, requestGeneral);
    //    await Navigation.PushAsync(new PleaseWaitPage(obj), true);
    //}
    async void NatigateBack(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }
}