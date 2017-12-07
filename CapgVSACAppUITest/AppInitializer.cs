using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace CapgVSACAppUITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                string currentFile = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
                FileInfo fi = new FileInfo(currentFile);
                string dir = fi.Directory.Parent.Parent.Parent.FullName;

                // PathToAPK is a property or an instance variable in the test class
             // string  PathToAPK = Path.Combine(dir, "MySolution.Droid", "bin", "debug", "CapgVSACApp.Droid.APK");
                string PathToAPK = @"D:\RahulT\Project\VSAC\APKs\com.capgvsacapp.apk";
                return ConfigureApp.Android.ApkFile(PathToAPK).StartApp();
            }

            return ConfigureApp
                .iOS
                .StartApp();
        }
    }
}

