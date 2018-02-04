using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTimer.ViewModels
{
    class CountDownPageViewModel : BindableBase
    {
        private System.Diagnostics.Stopwatch _stopwatch = new System.Diagnostics.Stopwatch();

        private TimeSpan _time;
        public TimeSpan Time
        {
            get { return _time; }
            private set { SetProperty(ref _time, value); }
        }

        public CountDownPageViewModel()
        {
            _stopwatch.Start();
            Xamarin.Forms.Device.StartTimer(TimeSpan.FromMilliseconds(33), OnTimerTick);
        }

        private void UpdateTime()
        {
            var time = Math.Max(0, (TimerSettings.Instance.CountMilliseconds - _stopwatch.ElapsedMilliseconds));
            Console.WriteLine(time);
            Time = TimeSpan.FromMilliseconds(time);
        }

        private bool OnTimerTick()
        {
            UpdateTime();
            if (Time.TotalMilliseconds > 0)
                return true;

            Xamarin.Forms.Device.StartTimer(TimeSpan.FromMilliseconds(100), OnTimerEnd);
            return false;
        }

        private bool OnTimerEnd()
        {
            if (TimerSettings.Instance.UseSpeechText)
                TextToSpeech();
            else
                PlayAudio();
            return false;
        }

        private async void TextToSpeech()
        {
            await Plugin.TextToSpeech.CrossTextToSpeech.Current.Speak(TimerSettings.Instance.SpeechText);
        }

        private async void PlayAudio()
        {
            try
            {
                var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                var assembly = typeof(App).Assembly;
                var name = "MyTimer.Resources.voice.m4a";
                // name 確認
                if (!IsContainsResource(assembly, name)) return;
                using (var stream = assembly.GetManifestResourceStream(name))
                    player.Load(stream);
                player.Loop = true;
                player.Play();
                await System.Threading.Tasks.Task.Delay(3_500);
                player.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private bool IsContainsResource(System.Reflection.Assembly assembly, string name)
        {
            if (assembly.GetManifestResourceNames().Contains(name)) return true;
            Console.WriteLine($"name : {name} はリソースに存在しません。");
            Console.WriteLine("リソースに含まれるファイル：");
            foreach (var resoureName in assembly.GetManifestResourceNames())
                Console.WriteLine(resoureName);
            return false;
        }

    }
}
