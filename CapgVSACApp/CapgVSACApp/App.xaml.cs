using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;
using Microsoft.AppCenter.Push;

namespace CapgVSACApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new CapgVSACApp.MainPage();
        }

        protected override void OnStart()
        {
            //AppCenter.Start("android=6c7f6211-cd8b-4dc1-9cb8-f79cbc47425e;" + "uwp={Your UWP App secret here};" + "ios={Your iOS App secret here}", typeof(Analytics), typeof(Crashes));
             AppCenter.Start("android=6c7f6211-cd8b-4dc1-9cb8-f79cbc47425e;", typeof(Analytics), typeof(Crashes), typeof(Push));
            
            //AppCenter.Start("android=6c7f6211-cd8b-4dc1-9cb8-f79cbc47425e;", typeof(Push));
            // Handle when your app starts
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
