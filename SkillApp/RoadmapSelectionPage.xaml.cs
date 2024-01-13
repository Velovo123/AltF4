namespace SkillApp;

public partial class RoadmapSelectionPage : ContentPage
{
    List<string> roadmapList;

    public RoadmapSelectionPage()
	{
		InitializeComponent();
        roadmapList = Operator.GetAllRoadmaps();


        foreach( string i in roadmapList )
        {
            if(TL_Label.Text == "new")
            {
                TL_Label.Text = i;
                continue;
            }

            else if (TR_Label.Text == "new")
            {
                TR_Label.Text = i;
                continue;
            }

            else if(BL_Label.Text == "new")
            {
                BL_Label.Text = i;
                continue;
            }

            else if(BR_Label.Text == "new")
            {
                BR_Label.Text = i;
                continue;
            }
        }

            //TL_Label.Text = roadmapList[0];
            //TR_Label.Text = roadmapList[1];
            //BL_Label.Text = roadmapList[2];
            //BR_Label.Text = roadmapList[3];

    }
    async void NatigateBack(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }
    async void NatigateTL(System.Object sender, System.EventArgs e)
    {
        if (TL_Label.Text == "new")
        {
            await Navigation.PushAsync(new BroadRequestPage(), true);
        }
        else
        {
            var obj = Operator.ReadRoadMapFromFile(roadmapList[0]);
            await Navigation.PushAsync(new RoadmapPage(obj), true);
        }
    }
    async void NatigateTR(System.Object sender, System.EventArgs e)
    {
        if (TR_Label.Text == "new")
        {
            await Navigation.PushAsync(new BroadRequestPage(), true);
        }
        else
        {
            var obj = Operator.ReadRoadMapFromFile(roadmapList[1]);
            await Navigation.PushAsync(new RoadmapPage(obj), true);
        }
    }
    async void NatigateBL(System.Object sender, System.EventArgs e)
    {
        if (BL_Label.Text == "new")
        {
            await Navigation.PushAsync(new BroadRequestPage(), true);
        }
        else
        {
            var obj = Operator.ReadRoadMapFromFile(roadmapList[2]);
            await Navigation.PushAsync(new RoadmapPage(obj), true);
        }
    }
    async void NatigateBR(System.Object sender, System.EventArgs e)
    {
        if (BR_Label.Text == "new")
        {
            await Navigation.PushAsync(new BroadRequestPage(), true);
        }
        else
        {
            var obj = Operator.ReadRoadMapFromFile(roadmapList[3]);
            await Navigation.PushAsync(new RoadmapPage(obj), true);
        }
    }
}