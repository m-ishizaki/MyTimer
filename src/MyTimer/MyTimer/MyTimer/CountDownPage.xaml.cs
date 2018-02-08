using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyTimer
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CountDownPage : ContentPage
	{
		public CountDownPage ()
		{
			InitializeComponent ();
		}

        private void CountDownPageAppearing(object sender, EventArgs e)
        {
            MessagingCenter.Subscribe<ViewModels.CountDownPageViewModel>(this, "GoBack", GoBack);
        }

        private void CountDownPageDisappearing(object sender, EventArgs e)
        {
            MessagingCenter.Unsubscribe<ViewModels.CountDownPageViewModel>(this, "GoBack");
        }

        private void GoBack<T>(T sender)
        {
            this.Navigation.PopModalAsync();
        }
    }
}