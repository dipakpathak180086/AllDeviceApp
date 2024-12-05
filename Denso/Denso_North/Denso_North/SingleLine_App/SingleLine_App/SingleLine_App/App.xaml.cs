using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ThreePointCheck_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
           
            if (File.Exists(CommonClass.CommonVariable.Path + "//" + "Lock.txt"))
            {
                App.Current.MainPage = new Pages.Lock_Screen();
            }
            else
            {
                MainPage = new Pages.Login();
            }
        }

        protected override void OnStart()
        {
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
