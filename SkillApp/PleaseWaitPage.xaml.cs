using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace SkillApp
{
    public partial class PleaseWaitPage : ContentPage
    {
        RootObject obj;
        public PleaseWaitPage(RootObject obj)
        {
            InitializeComponent();
            this.obj = obj;
            CheckRoadmap();
        }

        async void CheckRoadmap()
        {
            if (Operator.GenerationSuccess)
            {
                await Navigation.PushAsync(new RoadmapPage(obj), true);
            }
            else
            {
                await Navigation.PushAsync(new FailedPage(), true);
            }
        }
    }
}