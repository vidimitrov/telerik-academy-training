using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Threading;
using System.IO;
using System.Linq;

namespace VideoPlayer.Controls
{
    public partial class VideoPlayer : UserControl
    {
        DispatcherTimer timer;
        public delegate void timerTick();
        timerTick tick;
        string sec, min, hours;
        bool isDragging = false;
        bool fileIsPlaying = false;

        public VideoPlayer()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(timer_Tick);
            tick = new timerTick(changeStatus);
        }

        void timer_Tick(object sender, EventArgs e)   
           {   
              Dispatcher.Invoke(tick);   
           }

        public string CurrentVideoElement
        {
            get
            {
                return (string)GetValue(CurrentVideoElementProperty);
            }
            set
            {
                SetValue(CurrentVideoElementProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for CurrentVideoElement.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentVideoElementProperty =
        DependencyProperty.Register("CurrentVideoElement",
                                    typeof(string),
                                    typeof(VideoPlayer),
                                    new UIPropertyMetadata("", new PropertyChangedCallback(
                                        (DependencyObject obj, DependencyPropertyChangedEventArgs args) =>
                                        {
                                            var mediaElement = obj as VideoPlayer;
                                            mediaElement.videoElement.Source = new Uri(args.NewValue.ToString());
                                            mediaElement.Play();
                                        })));

        public IEnumerable<string> ItemsSources
        {
            get
            {
                return (IEnumerable<string>)GetValue(ItemsSourcesProperty);
            }
            set
            {
                SetValue(ItemsSourcesProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for ItemsSources.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourcesProperty =
        DependencyProperty.Register("ItemsSources", typeof(IEnumerable<string>), typeof(VideoPlayer), new UIPropertyMetadata(
        new List<string>(), new PropertyChangedCallback((DependencyObject obj, DependencyPropertyChangedEventArgs args) =>
                                                        {
                                                            var videoPlayer = obj as VideoPlayer;
                                                            videoPlayer.ListBoxPlaylist.ItemsSource = args.NewValue as List<string>;
                                                        })));

        public void Play()
        {
            this.videoElement.Play();
        }

        private void ButtonBrowse_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowserDiaglog = new System.Windows.Forms.FolderBrowserDialog();
            folderBrowserDiaglog.RootFolder = Environment.SpecialFolder.Desktop;
            folderBrowserDiaglog.ShowDialog();
            string folderPath = folderBrowserDiaglog.SelectedPath;
            if (folderPath != string.Empty)
            {
                var files = Directory.GetFiles(folderPath).Where(file => file.ToLower().EndsWith("mp4") || file.ToLower().EndsWith("avi")).ToList<string>();
                this.ItemsSources = files;
            }
        }

        private void ListBoxPlaylist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.CurrentVideoElement = ListBoxPlaylist.SelectedItem.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.ListBoxPlaylist.Visibility == Visibility.Collapsed)
            {
                this.ListBoxPlaylist.Visibility = Visibility.Visible;
            }
            else
            {
                this.ListBoxPlaylist.Visibility = Visibility.Collapsed;
            }
        }

        public void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up && this.videoElement.Volume < 1)
            {
                this.videoElement.Volume += 0.01;
            }
            else if (e.Key == Key.Down && this.videoElement.Volume > 0)
            {
                this.videoElement.Volume -= 0.01;
            }
            else if (e.Key == Key.Right)
            {
                this.videoElement.Position.Add(new TimeSpan(0, 0, 3));
            }
            else if (e.Key == Key.Left)
            {
                this.videoElement.Position.Add(new TimeSpan(0, 0, -3));
            }
        }

        private void PositionChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
        } 

        private void OnPlayButtonClick(object sender, RoutedEventArgs e)
        {
            this.videoElement.Play();
            fileIsPlaying = true;
            timer.Start();
        }

        private void OnPauseButtonClick(object sender, RoutedEventArgs e)
        {
            this.videoElement.Pause();
            fileIsPlaying = false;
            timer.Stop();
        }

        private void OnStopButtonClick(object sender, RoutedEventArgs e)
        {
            this.videoElement.Stop();
            fileIsPlaying = false;
            timer.Stop();
            seekSlider.Value = 0;
            progressBar.Value = 0;
            currentTime.Text = "00:00";
        }

        private void VolumeChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            videoElement.Volume = volumeSlider.Value;
        }

        void changeStatus()   
       {   
           if (fileIsPlaying)   
           {   
 
               #region customizeTime   
               if (videoElement.Position.Seconds < 10)
                   sec = "0" + videoElement.Position.Seconds.ToString();   
                else
                   sec = videoElement.Position.Seconds.ToString();


               if (videoElement.Position.Minutes < 10)
                   min = "0" + videoElement.Position.Minutes.ToString();   
                else
                   min = videoElement.Position.Minutes.ToString();

               if (videoElement.Position.Hours < 10)
                   hours = "0" + videoElement.Position.Hours.ToString();   
                else
                   hours = videoElement.Position.Hours.ToString();  
 
                #endregion customizeTime   
  
               seekSlider.Value = videoElement.Position.TotalMilliseconds;
               progressBar.Value = videoElement.Position.TotalMilliseconds;

               if (videoElement.Position.Hours == 0)   
                {   
  
                    currentTime.Text = min + ":" + sec;   
                }   
                else  
                {   
                    currentTime.Text = hours + ":" + min + ":" + sec;   
                }   
            }   
        }

        private void seekSlider_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, (int)seekSlider.Value);

            changePostion(ts);   
        }

        void changePostion(TimeSpan ts)   
        { 
            videoElement.Position = ts;   
        }

        private void seekSlider_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            fileIsPlaying = false;
        }

        private void seekSlider_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isDragging)   
            {   
                TimeSpan ts = new TimeSpan(0, 0, 0, 0, (int)seekSlider.Value);   
                changePostion(ts);
                fileIsPlaying = true;
            }   
            isDragging = false; 
        }

        private void videoElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            timer.Start();
            fileIsPlaying = true;
            openMedia();
        }

        public void openMedia()
        {
            InitializePropertyValues();
            try
            {
                #region customizeTime
                if (videoElement.NaturalDuration.TimeSpan.Seconds < 10)
                    sec = "0" + videoElement.Position.Seconds.ToString();
                else
                    sec = videoElement.NaturalDuration.TimeSpan.Seconds.ToString();

                if (videoElement.NaturalDuration.TimeSpan.Minutes < 10)
                    min = "0" + videoElement.NaturalDuration.TimeSpan.Minutes.ToString();
                else
                    min = videoElement.NaturalDuration.TimeSpan.Minutes.ToString();

                if (videoElement.NaturalDuration.TimeSpan.Hours < 10)
                    hours = "0" + videoElement.NaturalDuration.TimeSpan.Hours.ToString();
                else
                    hours = videoElement.NaturalDuration.TimeSpan.Hours.ToString();
                
                #endregion customizeTime
            }
            catch { }
            string path = videoElement.Source.LocalPath.ToString();

            double duration = videoElement.NaturalDuration.TimeSpan.TotalMilliseconds;
            seekSlider.Maximum = duration;
            progressBar.Maximum = duration;

            videoElement.Volume = volumeSlider.Value;
            videoElement.ScrubbingEnabled = true;

            volumeSlider.ValueChanged += new RoutedPropertyChangedEventHandler<double>(VolumeChanged);
        } 

        private void videoElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            videoElement.Stop();
            volumeSlider.ValueChanged -= new RoutedPropertyChangedEventHandler<double>(VolumeChanged);
        }

        void InitializePropertyValues()
        {
            videoElement.Volume = (double)volumeSlider.Value;
        }

    }
}