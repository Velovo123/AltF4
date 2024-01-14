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
            StartLoadingAnimation();
        }

        async void StartLoadingAnimation()
        {

            LoadingLabel.Text="Loading..";


        }
    }
}