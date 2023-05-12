using System.Windows;
using System.Windows.Controls;

namespace WPFControlVisibilityApp.Controls
{
    public class MediaPlayer : MediaElement
    {
        public static DependencyProperty IsPlayProperty;

        public static DependencyProperty IsStopProperty;

        static MediaPlayer()
        {
            IsPlayProperty = DependencyProperty.Register("IsPlay", typeof(bool), typeof(MediaPlayer), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(OnPlayChanged)));
            IsStopProperty = DependencyProperty.Register("IsStop", typeof(bool), typeof(MediaPlayer), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(OnStopChanged)));
        }

        public bool IsPlay
        {
            get => (bool)GetValue(IsPlayProperty);
            set => SetValue(IsPlayProperty, value);
        }

        public bool IsStop
        {
            get { return (bool)GetValue(IsStopProperty); }
            set { SetValue(IsStopProperty, value); }
        }

        private static void OnPlayChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var mediaPlayer = (MediaPlayer)sender;
            if (mediaPlayer.IsPlay)
            {
                mediaPlayer.Play();
            }
            else
            {
                if (mediaPlayer.CanPause)
                {
                    mediaPlayer.Pause();
                }
            }
        }

        private static void OnStopChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var mediaPlayer = (MediaPlayer)sender;
            mediaPlayer.Stop();
        }
    }
}