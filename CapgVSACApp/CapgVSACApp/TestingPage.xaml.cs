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
            lblresult.Text = (Convert.ToInt32(txt1.Text) + Convert.ToInt32(txt2.Text)).ToString();
        }

        private void btnMultiply_Clicked(object sender, EventArgs e)
        {
            lblresult.Text = (Convert.ToInt32(txt1.Text) * Convert.ToInt32(txt2.Text)).ToString();
        }
    }
}