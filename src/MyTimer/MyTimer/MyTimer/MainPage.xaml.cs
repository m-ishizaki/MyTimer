using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyTimer
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void MainPageAppearing(object sender, EventArgs e)
        {
            MessagingCenter.Subscribe<ViewModels.MainPageViewModel, AlertParameter>(this, "DisplayAlert", DisplayAlert);
            MessagingCenter.Subscribe<ViewModels.MainPageViewModel>(this, "Start", StartTimer);
        }

        private void MainPageDisappearing(object sender, EventArgs e)
        {
            MessagingCenter.Unsubscribe<ViewModels.MainPageViewModel, AlertParameter>(this, "DisplayAlert");
            MessagingCenter.Unsubscribe<ViewModels.MainPageViewModel>(this, "Start");
        }

        private async void DisplayAlert<T>(T sender, AlertParameter arg)
        {
            var isAccept = await DisplayAlert(arg.Title, arg.Message, arg.Accept, arg.Cancel);
            arg.Action?.Invoke(isAccept);
        }

        private void StartTimer<T>(T sender)
        {
            this.Navigation.PushModalAsync(new CountDownPage());
        }


    }
}
