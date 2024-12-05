using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThreePointCheck_App.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainWIndow : ContentPage
    {
        public MainWIndow()
        {
            InitializeComponent();
        }

        CommonClass.SoundPlay obj = DependencyService.Get<CommonClass.SoundPlay>();


        private void BtnSIL_Clicked(object sender, EventArgs e)
        {
            try
            {
                App.Current.MainPage = new Pages.SIL_Scanning();

            }
            catch (Exception ex)
            {
                obj.PlaySound("Error");
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void BtnKanban_Clicked(object sender, EventArgs e)
        {
            try
            {
                App.Current.MainPage = new Pages.PicklistConsolidation();

            }
            catch (Exception ex)
            {
                obj.PlaySound("Error");
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            try
            {
                //btnSIL.IsEnabled = false;

                //if (CommonClass.CommonVariable.UserType == "SUPER USER")
                //{
                //    btnSIL.IsEnabled = true;
                //}
            }
            catch (Exception ex)
            {
                obj.PlaySound("Error");
                DisplayAlert("Error", ex.Message, "OK");
            }

        }
    }
}