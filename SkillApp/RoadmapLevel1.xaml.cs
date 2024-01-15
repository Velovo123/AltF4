namespace SkillApp;

public partial class RoadmapLevel1 : ContentPage
{
    RootObject obj;
    public RoadmapLevel1(RootObject obj)
	{
		InitializeComponent();

        this.obj = obj;

        BeginerTask0.Text = obj.Roadmap.Beginner.Tasks[0].TaskDescription;
        BegginerSubtask0_0.Text = obj.Roadmap.Beginner.Tasks[0].Subtasks[0];
        BegginerSubtask0_1.Text = obj.Roadmap.Beginner.Tasks[0].Subtasks[1];
        BegginerSubtask0_2.Text = obj.Roadmap.Beginner.Tasks[0].Subtasks[2];

        int counter = 1;

        foreach (var link in obj.Roadmap.Beginner.Tasks[0].Resources)
        {
            var labelBegginerResource = new Label
            {
                Text = $"Resourse link {counter}",
                FontSize = 11,
                TextDecorations = TextDecorations.Underline,
                FontFamily = "InterSemiBold",
                Margin = new Thickness(0, 10, 0, 0),
                TextColor = Color.FromArgb("#1D3A70"),
                GestureRecognizers =
                {
                    new TapGestureRecognizer
                    {
                        Command = new Command(() =>
                        {
                            Browser.OpenAsync(link);
                        })
                    }
                }
            };
            Beginer0LabelStackLayout.Children.Add(labelBegginerResource);
            counter++;
        }

        BeginerTask1.Text = obj.Roadmap.Beginner.Tasks[1].TaskDescription;
        BegginerSubtask1_0.Text = obj.Roadmap.Beginner.Tasks[1].Subtasks[0];
        BegginerSubtask1_1.Text = obj.Roadmap.Beginner.Tasks[1].Subtasks[1];
        BegginerSubtask1_2.Text = obj.Roadmap.Beginner.Tasks[1].Subtasks[2];

        counter = 1;

        foreach (var link in obj.Roadmap.Beginner.Tasks[1].Resources)
        {
            var labelBegginerResource = new Label
            {
                Text = $"Resourse link {counter}",
                FontSize = 11,
                TextDecorations = TextDecorations.Underline,
                FontFamily = "InterSemiBold",
                Margin = new Thickness(0, 10, 0, 0),
                TextColor = Color.FromArgb("#1D3A70"),
                GestureRecognizers =
                {
                    new TapGestureRecognizer
                    {
                        Command = new Command(() =>
                        {
                            Browser.OpenAsync(link);
                        })
                    }
                }
            };
            Beginer1LabelStackLayout.Children.Add(labelBegginerResource);
            counter++;
        }

        BeginerTask2.Text = obj.Roadmap.Beginner.Tasks[2].TaskDescription;
        BegginerSubtask2_0.Text = obj.Roadmap.Beginner.Tasks[2].Subtasks[0];
        BegginerSubtask2_1.Text = obj.Roadmap.Beginner.Tasks[2].Subtasks[1];
        BegginerSubtask2_2.Text = obj.Roadmap.Beginner.Tasks[2].Subtasks[2];

        counter = 1;

        foreach (var link in obj.Roadmap.Beginner.Tasks[2].Resources)
        {
            var labelBegginerResource = new Label
            {
                Text = $"Resourse link {counter}",
                FontSize = 11,
                TextDecorations = TextDecorations.Underline,
                FontFamily = "InterSemiBold",
                Margin = new Thickness(0, 10, 0, 0),
                TextColor = Color.FromArgb("#1D3A70"),
                GestureRecognizers =
                {
                    new TapGestureRecognizer
                    {
                        Command = new Command(() =>
                        {
                            Browser.OpenAsync(link);
                        })
                    }
                }
            };
            Beginer2LabelStackLayout.Children.Add(labelBegginerResource);
            counter++;
        }
    }
    async void NavigateBack(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }
    async void NavigateMenu(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new MenuPage(), true);
    }
}