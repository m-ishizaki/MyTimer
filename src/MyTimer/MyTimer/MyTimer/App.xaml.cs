using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MyTimer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // NavigationPage を使用する
            MainPage = new NavigationPage(new MyTimer.MainPage());
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
