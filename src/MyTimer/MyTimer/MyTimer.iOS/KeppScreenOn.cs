using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(MyTimer.iOS.KeppScreenOn))]
namespace MyTimer.iOS
{
    class KeppScreenOn : IKeepScreenOn
    {
        public void Set(bool keepOn) => UIApplication.SharedApplication.InvokeOnMainThread(() =>
                        UIApplication.SharedApplication.IdleTimerDisabled = keepOn);
    }
}