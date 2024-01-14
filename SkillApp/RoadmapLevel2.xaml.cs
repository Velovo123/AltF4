namespace SkillApp;

public partial class RoadmapLevel2 : ContentPage
{
    RootObject obj;
    public RoadmapLevel2(RootObject obj)
	{
		InitializeComponent();

        this.obj = obj;

        IntermediateTask0.Text = obj.Roadmap.Intermediate.Tasks[0].TaskDescription;
        IntermediateSubtask0_0.Text = obj.Roadmap.Intermediate.Tasks[0].Subtasks[0];
        IntermediateSubtask0_1.Text = obj.Roadmap.Intermediate.Tasks[0].Subtasks[1];
        IntermediateSubtask0_2.Text = obj.Roadmap.Intermediate.Tasks[0].Subtasks[2];

        int counter = 1;

        foreach (var link in obj.Roadmap.Intermediate.Tasks[0].Resources)
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
            Intermediate0LabelStackLayout.Children.Add(labelBegginerResource);
            counter++;
        }

        IntermediateTask1.Text = obj.Roadmap.Intermediate.Tasks[1].TaskDescription;
        IntermediateSubtask1_0.Text = obj.Roadmap.Intermediate.Tasks[1].Subtasks[0];
        IntermediateSubtask1_1.Text = obj.Roadmap.Intermediate.Tasks[1].Subtasks[1];
        IntermediateSubtask1_2.Text = obj.Roadmap.Intermediate.Tasks[1].Subtasks[2];

        counter = 1;

        foreach (var link in obj.Roadmap.Intermediate.Tasks[1].Resources)
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
            Intermediate1LabelStackLayout.Children.Add(labelBegginerResource);
            counter++;
        }

        IntermediateTask2.Text = obj.Roadmap.Intermediate.Tasks[2].TaskDescription;
        IntermediateSubtask2_0.Text = obj.Roadmap.Intermediate.Tasks[2].Subtasks[0];
        IntermediateSubtask2_1.Text = obj.Roadmap.Intermediate.Tasks[2].Subtasks[1];
        IntermediateSubtask2_2.Text = obj.Roadmap.Intermediate.Tasks[2].Subtasks[2];

        counter = 1;

        foreach (var link in obj.Roadmap.Intermediate.Tasks[2].Resources)
        {
            var labelIntermediateResource = new Label
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
            Intermediate2LabelStackLayout.Children.Add(labelIntermediateResource);
            counter++;
        }
    }
    async void NavigateBack(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }
}