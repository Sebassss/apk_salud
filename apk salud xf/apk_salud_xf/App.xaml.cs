using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace apk_salud_xf
{
    public partial class App : Application
    {
        public static NavigationPage mypage;

        public App()
        {
            InitializeComponent();

            MainPage = new apk_salud_xf.MainPage();

            
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
