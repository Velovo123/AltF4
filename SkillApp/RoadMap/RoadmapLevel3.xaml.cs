namespace SkillApp;

public partial class RoadmapLevel3 : ContentPage
{
    RootObject obj;
    public RoadmapLevel3(RootObject obj)
	{
		InitializeComponent();

        this.obj = obj;

        AdvancedTask0.Text = obj.Roadmap.Advanced.Tasks[0].TaskDescription;
        AdvancedSubtask0_0.Text = obj.Roadmap.Advanced.Tasks[0].Subtasks[0];
        AdvancedSubtask0_1.Text = obj.Roadmap.Advanced.Tasks[0].Subtasks[1];
        AdvancedSubtask0_2.Text = obj.Roadmap.Advanced.Tasks[0].Subtasks[2];

        int counter = 1;

        foreach (var link in obj.Roadmap.Advanced.Tasks[0].Resources)
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
            Advanced0LabelStackLayout.Children.Add(labelBegginerResource);
            counter++;
        }

        AdvancedTask1.Text = obj.Roadmap.Advanced.Tasks[1].TaskDescription;
        AdvancedSubtask1_0.Text = obj.Roadmap.Advanced.Tasks[1].Subtasks[0];
        AdvancedSubtask1_1.Text = obj.Roadmap.Advanced.Tasks[1].Subtasks[1];
        AdvancedSubtask1_2.Text = obj.Roadmap.Advanced.Tasks[1].Subtasks[2];

        counter = 1;

        foreach (var link in obj.Roadmap.Advanced.Tasks[1].Resources)
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
            Advanced1LabelStackLayout.Children.Add(labelBegginerResource);
            counter++;
        }

        AdvancedTask2.Text = obj.Roadmap.Advanced.Tasks[2].TaskDescription;
        AdvancedSubtask2_0.Text = obj.Roadmap.Advanced.Tasks[2].Subtasks[0];
        AdvancedSubtask2_1.Text = obj.Roadmap.Advanced.Tasks[2].Subtasks[1];
        AdvancedSubtask2_2.Text = obj.Roadmap.Advanced.Tasks[2].Subtasks[2];

        counter = 1;

        foreach (var link in obj.Roadmap.Advanced.Tasks[2].Resources)
        {
            var labelAdvancedResource = new Label
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
            Advanced2LabelStackLayout.Children.Add(labelAdvancedResource);
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