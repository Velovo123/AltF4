namespace SkillApp;

public partial class RoadmapPage : ContentPage
{
    string contentText = "0";
    int numberOfSteps = 0;
    public RoadmapPage()
	{
		InitializeComponent();
	}
    private void OnAddLabelClicked(object sender, EventArgs e)
    {
        for (int i = 0; i < numberOfSteps; i++)
        {
            var newLabel = new Label
            {
                Text = contentText,
                FontSize = 16,
                Margin = new Thickness(10, 10, 0, 0),
                TextColor = Colors.White,
            };

            labelStackLayout.Children.Add(newLabel);
        }
    }

    private void OnEntryTextChangedContent(object sender, TextChangedEventArgs e)
    {
        contentText = e.NewTextValue;
    }

    private void OnEntryTextChangedSteps(object sender, EventArgs e)
    {
        if (int.TryParse(numbOfSteps.Text, out int result))
        {
            numberOfSteps = result;
        }
        else
        {

        }
    }
}