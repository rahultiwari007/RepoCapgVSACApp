using Microsoft.AppCenter.Analytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CapgVSACApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnFirst_Clicked(object sender, EventArgs e)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();
            properties.Add("Category", "Music");
            properties.Add("FileName", "favorite.avi");

            Analytics.TrackEvent("Video clicked", properties);
            Button bt = new Button();
            bt.Clicked += Bt_Clicked;
            
        }

        private void Bt_Clicked(object sender, EventArgs e)
        {
             
        }

        private void btnSecond_Clicked(object sender, EventArgs e)
        {
            Analytics.TrackEvent("Second Button clicked");
        }

        private void btnThird_Clicked(object sender, EventArgs e)
        {
            Analytics.TrackEvent("Third Button clicked");
        }
    }
}
