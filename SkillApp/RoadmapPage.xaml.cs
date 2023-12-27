namespace SkillApp;

public partial class RoadmapPage : ContentPage
{
    RootObject obj = Operator.ReadRoadMapFromFile("Test.json");
    public RoadmapPage()
	{
		InitializeComponent();
	}
    private void OnCreateRoadmapClicked(object sender, EventArgs e)
    {

        //foreach (var task in obj.roadmap.beginner.tasks)
        //{
        //    var labelBegginerTask = new Label
        //    {
        //        Text = task.task,
        //        FontSize = 16,
        //        Margin = new Thickness(10, 10, 0, 0),
        //        TextColor = Colors.White,
        //    };
        //    labelStackLayout.Children.Add(labelBegginerTask);

        //    foreach (var subtask in task.subtasks)
        //    {
        //        var labelBegginerSubtask = new Label
        //        {
        //            Text = subtask,
        //            FontSize = 16,
        //            Margin = new Thickness(10, 10, 0, 0),
        //            TextColor = Colors.White,
        //        };

        //        labelStackLayout.Children.Add(labelBegginerSubtask);
        //    }

        //    foreach (var resource in task.resources)
        //    {
        //        var labelBegginerResource = new Label
        //        {
        //            Text = resource.resource,
        //            FontSize = 16,
        //            Margin = new Thickness(10, 10, 0, 0),
        //            TextColor = Colors.White,
        //        };

        //        labelStackLayout.Children.Add(labelBegginerResource);

        //        var labelBegginerUrl = new Label
        //        {
        //            Text = resource.url,
        //            FontSize = 16,
        //            Margin = new Thickness(10, 10, 0, 0),
        //            TextColor = Colors.White,
        //        };

        //        labelStackLayout.Children.Add(labelBegginerUrl);
        //    }

        //    foreach (var milestone in obj.roadmap.beginner.milestones)
        //    {
        //        var labelBegginerMilestones = new Label
        //        {
        //            Text = milestone,
        //            FontSize = 16,
        //            Margin = new Thickness(10, 10, 0, 0),
        //            TextColor = Colors.White,
        //        };

        //        labelStackLayout.Children.Add(labelBegginerMilestones);
        //    }
        //}

        //foreach (var task in obj.roadmap.intermediate.tasks)
        //{
        //    var labelIntermediateTask = new Label
        //    {
        //        Text = task.task,
        //        FontSize = 16,
        //        Margin = new Thickness(10, 10, 0, 0),
        //        TextColor = Colors.White,
        //    };
        //    labelStackLayout.Children.Add(labelIntermediateTask);

        //    foreach (var subtask in task.subtasks)
        //    {
        //        var labelIntermediateSubtask = new Label
        //        {
        //            Text = subtask,
        //            FontSize = 16,
        //            Margin = new Thickness(10, 10, 0, 0),
        //            TextColor = Colors.White,
        //        };

        //        labelStackLayout.Children.Add(labelIntermediateSubtask);
        //    }

        //    foreach (var resource in task.resources)
        //    {
        //        var labelIntermediateResource = new Label
        //        {
        //            Text = resource.resource,
        //            FontSize = 16,
        //            Margin = new Thickness(10, 10, 0, 0),
        //            TextColor = Colors.White,
        //        };

        //        labelStackLayout.Children.Add(labelIntermediateResource);

        //        var labelIntermediateUrl = new Label
        //        {
        //            Text = resource.url,
        //            FontSize = 16,
        //            Margin = new Thickness(10, 10, 0, 0),
        //            TextColor = Colors.White,
        //        };

        //        labelStackLayout.Children.Add(labelIntermediateUrl);
        //    }

        //    foreach (var milestone in obj.roadmap.intermediate.milestones)
        //    {
        //        var labelIntermediateMilestones = new Label
        //        {
        //            Text = milestone,
        //            FontSize = 16,
        //            Margin = new Thickness(10, 10, 0, 0),
        //            TextColor = Colors.White,
        //        };

        //        labelStackLayout.Children.Add(labelIntermediateMilestones);
        //    }
        //}

        //foreach (var task in obj.roadmap.advanced.tasks)
        //{
        //    var labelAdvancedTask = new Label
        //    {
        //        Text = task.task,
        //        FontSize = 16,
        //        Margin = new Thickness(10, 10, 0, 0),
        //        TextColor = Colors.White,
        //    };
        //    labelStackLayout.Children.Add(labelAdvancedTask);

        //    foreach (var subtask in task.subtasks)
        //    {
        //        var labelAdvancedSubtask = new Label
        //        {
        //            Text = subtask,
        //            FontSize = 16,
        //            Margin = new Thickness(10, 10, 0, 0),
        //            TextColor = Colors.White,
        //        };

        //        labelStackLayout.Children.Add(labelAdvancedSubtask);
        //    }

        //    foreach (var resource in task.resources)
        //    {
        //        var labelAdvancedResource = new Label
        //        {
        //            Text = resource.resource,
        //            FontSize = 16,
        //            Margin = new Thickness(10, 10, 0, 0),
        //            TextColor = Colors.White,
        //        };

        //        labelStackLayout.Children.Add(labelAdvancedResource);

        //        var labelAdvancedUrl = new Label
        //        {
        //            Text = resource.url,
        //            FontSize = 16,
        //            Margin = new Thickness(10, 10, 0, 0),
        //            TextColor = Colors.White,
        //        };

        //        labelStackLayout.Children.Add(labelAdvancedUrl);
        //    }

        //    foreach (var milestone in obj.roadmap.advanced.milestones)
        //    {
        //        var labelAdvancedMilestones = new Label
        //        {
        //            Text = milestone,
        //            FontSize = 16,
        //            Margin = new Thickness(10, 10, 0, 0),
        //            TextColor = Colors.White,
        //        };

        //        labelStackLayout.Children.Add(labelAdvancedMilestones);
        //    }
        //}
    }
}