namespace SkillApp;

public partial class ExistingRoadmapPage : ContentPage
{
    RootObject obj;
    public ExistingRoadmapPage(RootObject obj)
	{
		InitializeComponent();

        this.obj = obj;

        string beginnerResources0 = string.Empty;
        foreach (var i in obj.Roadmap.Beginner.Tasks[0].Resources)
        {
            beginnerResources0 += '\n' + i;
        }

        string beginnerResources1 = string.Empty;
        foreach (var i in obj.Roadmap.Beginner.Tasks[1].Resources)
        {
            beginnerResources1 += '\n' + i;
        }

        string beginnerResources2 = string.Empty;
        foreach (var i in obj.Roadmap.Beginner.Tasks[2].Resources)
        {
            beginnerResources2 += '\n' + i;
        }

        BeginerTask0.Text = obj.Roadmap.Beginner.Tasks[0].TaskDescription;
        BegginerSubtask0_0.Text = obj.Roadmap.Beginner.Tasks[0].Subtasks[0];
        BegginerSubtask0_2.Text = obj.Roadmap.Beginner.Tasks[0].Subtasks[1];
        BegginerSubtask0_2.Text = obj.Roadmap.Beginner.Tasks[0].Subtasks[2];
        BegginerResource0_0.Text = beginnerResources0;

        BeginerTask1.Text = obj.Roadmap.Beginner.Tasks[1].TaskDescription;
        BegginerSubtask1_0.Text = obj.Roadmap.Beginner.Tasks[1].Subtasks[0];
        BegginerSubtask1_2.Text = obj.Roadmap.Beginner.Tasks[1].Subtasks[1];
        BegginerSubtask1_2.Text = obj.Roadmap.Beginner.Tasks[1].Subtasks[2];
        BegginerResource1_0.Text = beginnerResources1;

        BeginerTask2.Text = obj.Roadmap.Beginner.Tasks[2].TaskDescription;
        BegginerSubtask2_0.Text = obj.Roadmap.Beginner.Tasks[2].Subtasks[0];
        BegginerSubtask2_2.Text = obj.Roadmap.Beginner.Tasks[2].Subtasks[1];
        BegginerSubtask2_2.Text = obj.Roadmap.Beginner.Tasks[2].Subtasks[2];
        BegginerResource2_0.Text = beginnerResources2;

        BegginerMilestone0.Text = obj.Roadmap.Beginner.Milestones[0];
        BegginerMilestone1.Text = obj.Roadmap.Beginner.Milestones[1];
        BegginerMilestone2.Text = obj.Roadmap.Beginner.Milestones[2];


        string intermediateResources0 = string.Empty;
        foreach (var i in obj.Roadmap.Intermediate.Tasks[0].Resources)
        {
            intermediateResources0 += '\n' + i;
        }

        string intermediateResources1 = string.Empty;
        foreach (var i in obj.Roadmap.Intermediate.Tasks[1].Resources)
        {
            intermediateResources1 += '\n' + i;
        }

        string intermediateResources2 = string.Empty;
        foreach (var i in obj.Roadmap.Intermediate.Tasks[2].Resources)
        {
            intermediateResources2 += '\n' + i;
        }

        IntermediateTask0.Text = obj.Roadmap.Intermediate.Tasks[0].TaskDescription;
        IntermediateSubtask0_0.Text = obj.Roadmap.Intermediate.Tasks[0].Subtasks[0];
        IntermediateSubtask0_2.Text = obj.Roadmap.Intermediate.Tasks[0].Subtasks[1];
        IntermediateSubtask0_2.Text = obj.Roadmap.Intermediate.Tasks[0].Subtasks[2];
        IntermediateResource0_0.Text = intermediateResources0;

        IntermediateTask1.Text = obj.Roadmap.Intermediate.Tasks[1].TaskDescription;
        IntermediateSubtask1_0.Text = obj.Roadmap.Intermediate.Tasks[1].Subtasks[0];
        IntermediateSubtask1_2.Text = obj.Roadmap.Intermediate.Tasks[1].Subtasks[1];
        IntermediateSubtask1_2.Text = obj.Roadmap.Intermediate.Tasks[1].Subtasks[2];
        IntermediateResource1_0.Text = intermediateResources1;

        IntermediateTask2.Text = obj.Roadmap.Intermediate.Tasks[2].TaskDescription;
        IntermediateSubtask2_0.Text = obj.Roadmap.Intermediate.Tasks[2].Subtasks[0];
        IntermediateSubtask2_2.Text = obj.Roadmap.Intermediate.Tasks[2].Subtasks[1];
        IntermediateSubtask2_2.Text = obj.Roadmap.Intermediate.Tasks[2].Subtasks[2];
        IntermediateResource2_0.Text = intermediateResources2;

        IntermediateMilestone0.Text = obj.Roadmap.Intermediate.Milestones[0];
        IntermediateMilestone1.Text = obj.Roadmap.Intermediate.Milestones[1];
        IntermediateMilestone2.Text = obj.Roadmap.Intermediate.Milestones[2];


        string advancedResources0 = string.Empty;
        foreach (var i in obj.Roadmap.Advanced.Tasks[0].Resources)
        {
            advancedResources0 += '\n' + i;
        }

        string advancedResources1 = string.Empty;
        foreach (var i in obj.Roadmap.Advanced.Tasks[0].Resources)
        {
            advancedResources1 += '\n' + i;
        }

        string advancedResources2 = string.Empty;
        foreach (var i in obj.Roadmap.Advanced.Tasks[0].Resources)
        {
            advancedResources2 += '\n' + i;
        }

        AdvancedTask0.Text = obj.Roadmap.Advanced.Tasks[0].TaskDescription;
        AdvancedSubtask0_0.Text = obj.Roadmap.Advanced.Tasks[0].Subtasks[0];
        AdvancedSubtask0_2.Text = obj.Roadmap.Advanced.Tasks[0].Subtasks[1];
        AdvancedSubtask0_2.Text = obj.Roadmap.Advanced.Tasks[0].Subtasks[2];
        AdvancedResource0_0.Text = advancedResources0;

        AdvancedTask1.Text = obj.Roadmap.Advanced.Tasks[1].TaskDescription;
        AdvancedSubtask1_0.Text = obj.Roadmap.Advanced.Tasks[1].Subtasks[0];
        AdvancedSubtask1_2.Text = obj.Roadmap.Advanced.Tasks[1].Subtasks[1];
        AdvancedSubtask1_2.Text = obj.Roadmap.Advanced.Tasks[1].Subtasks[2];
        AdvancedResource1_0.Text = advancedResources1;

        AdvancedTask2.Text = obj.Roadmap.Advanced.Tasks[2].TaskDescription;
        AdvancedSubtask2_0.Text = obj.Roadmap.Advanced.Tasks[2].Subtasks[0];
        AdvancedSubtask2_2.Text = obj.Roadmap.Advanced.Tasks[2].Subtasks[1];
        AdvancedSubtask2_2.Text = obj.Roadmap.Advanced.Tasks[2].Subtasks[2];
        AdvancedResource2_0.Text = advancedResources2;

        AdvancedMilestone0.Text = obj.Roadmap.Advanced.Milestones[0];
        AdvancedMilestone1.Text = obj.Roadmap.Advanced.Milestones[1];
        AdvancedMilestone2.Text = obj.Roadmap.Advanced.Milestones[2];


        SupplementarySkill0.Text = obj.Supplementary_skills[0];
        SupplementarySkill1.Text = obj.Supplementary_skills[1];
        SupplementarySkill2.Text = obj.Supplementary_skills[2];


        StayAbreastStrategy0.Text = obj.Stay_abreast_strategies[0];
        StayAbreastStrategy1.Text = obj.Stay_abreast_strategies[1];
        StayAbreastStrategy2.Text = obj.Stay_abreast_strategies[2];
    }
    async void NatigateBack(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new RoadmapSelectionPage(), true);
    }
}