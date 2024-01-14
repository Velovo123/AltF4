namespace SkillApp;

public partial class RoadmapLevel4 : ContentPage
{
    RootObject obj;
    public RoadmapLevel4(RootObject obj)
	{
		InitializeComponent();

        this.obj = obj;

        SupplementarySkill0.Text = obj.Supplementary_skills[0];
        SupplementarySkill1.Text = obj.Supplementary_skills[1];
        SupplementarySkill2.Text = obj.Supplementary_skills[2];

        StayAbreastStrategy0.Text = obj.Stay_abreast_strategies[0];
        StayAbreastStrategy1.Text = obj.Stay_abreast_strategies[1];
        StayAbreastStrategy2.Text = obj.Stay_abreast_strategies[2];
    }
    async void NavigateBack(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }
}