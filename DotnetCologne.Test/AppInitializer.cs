using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace DotnetCologne.Test
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android
                    .ApkFile(@"/Users/hoppentt/Projects/GitHub/DotnetCologne/DotnetCologne/DotnetCologne.Android/bin/Debug/com.companyname.DotnetCologne-Signed.apk")
                    .PreferIdeSettings()
                    .EnableLocalScreenshots()
                    .StartApp();
            }

            if (platform == Platform.iOS)
            {
                return ConfigureApp.iOS
                    .AppBundle(@"/Users/hoppentt/Projects/GitHub/DotnetCologne/DotnetCologne/DotnetCologne.iOS/bin/iPhoneSimulator/Debug/DotnetCologne.iOS.app")
                    .PreferIdeSettings()
                    .EnableLocalScreenshots()
                    .StartApp();
            }

            throw new Exception("Unknown platform");
        }
    }
}