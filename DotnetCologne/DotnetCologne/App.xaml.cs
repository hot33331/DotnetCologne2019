using System;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;
using Microsoft.AppCenter.Push;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace DotnetCologne
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            
            // This should come before AppCenter.Start() is called
            // Avoid duplicate event registration:
            if (!AppCenter.Configured)
            {
                Push.PushNotificationReceived += (sender, e) =>
                {
                    // Add the notification message and title to the message
                    var summary =  $"Push notification received:" +
                                   $"\n\tNotification title: {e.Title}" +
                                   $"\n\tMessage: {e.Message}";
    
                    // If there is custom data associated with the notification,
                    // print the entries
                    if (e.CustomData != null)
                    {
                        summary += "\n\tCustom data:\n";
                        foreach (var key in e.CustomData.Keys)
                        {
                            summary += $"\t\t{key} : {e.CustomData[key]}\n";
                        }
                    }

                    // Send the notification summary to debug output
                    System.Diagnostics.Debug.WriteLine(summary);
                };
            }
            AppCenter.Start("ios=" + AppConstants.AppCenterKeyIos + ";uwp=" + AppConstants.AppCenterKeyUwp + ";android=" + AppConstants.AppCenterKeyDroid, typeof(Analytics), typeof(Crashes), typeof(Push), typeof(Distribute));
#if ENABLE_TEST_CLOUD
            Analytics.SetEnabledAsync(false); // no analytics from Denmark ;-)
            Push.SetEnabledAsync(false); // no push during tests
            Distribute.SetEnabledAsync(false); // no distribution during tests
#endif
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}