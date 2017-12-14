using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CapgVSACApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestingPage : ContentPage
    {
        public TestingPage()
        {
            InitializeComponent();
        }
        private void btnSum_Clicked(object sender, EventArgs e)
        {
            try
            {
                lblresult.Text = (Convert.ToInt32(txt1.Text) + Convert.ToInt32(txt2.Text)).ToString();
                //Applying Analytics

                Dictionary<string, string> properties = new Dictionary<string, string>();
                properties.Add("First Value", txt1.Text);
                properties.Add("Second Value", txt2.Text);
                Analytics.TrackEvent("Sum Button clicked");
                Analytics.TrackEvent("Sum Button Values", properties);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnMultiply_Clicked(object sender, EventArgs e)
        {
            try
            {
                lblresult.Text = (Convert.ToInt32(txt1.Text) * Convert.ToInt32(txt2.Text)).ToString();
                //Applying Analytics
                Dictionary<string, string> properties = new Dictionary<string, string>();
                properties.Add("First Value", txt1.Text);
                properties.Add("Second Value", txt2.Text);
                Analytics.TrackEvent("Multiply Button clicked");
                Analytics.TrackEvent("Multiply Button Values", properties);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}