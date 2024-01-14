using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace SkillApp
{
    public partial class PleaseWaitPage : ContentPage
    {
        private int _counter;

        public PleaseWaitPage()
        {
            InitializeComponent();
            StartLoadingAnimation();
        }

        private async void StartLoadingAnimation()
        {
            
            
        }
    }
}