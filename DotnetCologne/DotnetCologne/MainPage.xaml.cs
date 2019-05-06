using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;

namespace DotnetCologne
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LblBildId.Text = "BuildId " + AppConstants.AppCenterBuildId;
        }

        private void OnHoldMeButtonClicked(object sender, EventArgs e)
        {
            Analytics.TrackEvent("Hold Me clicked");
        }

        private void OnThrillMeButtonClicked(object sender, EventArgs e)
        {
            Analytics.TrackEvent("Thrill me clicked");
            try
            {
                int y = (int) sender;
            } catch (Exception exception) {
                Crashes.TrackError(exception);
            }
        }

        private void OnKissMeButtonClicked(object sender, EventArgs e)
        {
            Analytics.TrackEvent("Kiss Me clicked");
        }

        private void OnKillMeButtonClicked(object sender, EventArgs e)
        {
            Analytics.TrackEvent("Kill me clicked");
            Crashes.GenerateTestCrash();
        }
    }
}