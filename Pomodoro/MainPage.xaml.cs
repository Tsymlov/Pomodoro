using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Pomodoro
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        DispatcherTimer timer = new DispatcherTimer();
        TimeSpan pomodoroTime;
        bool isClockTicking = false;

        public MainPage()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            pomodoroTime = TimeSpan.FromMinutes(25);
            RefreshTimeBoard();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(1);
        }

        private void Timer_Tick(object sender, object e)
        {
            pomodoroTime = pomodoroTime.Subtract(TimeSpan.FromSeconds(1));
            RefreshTimeBoard();
            if (isTimeUp)
            {
                Stop();
            }
        }

        private void RefreshTimeBoard()
        {
            timeBoard.Text = pomodoroTime.ToString(@"mm\:ss");
        }

        private bool isTimeUp
        {
            get
            {
                return pomodoroTime.Minutes <= 0 && pomodoroTime.Seconds <= 0;
            }
        }

        private void Stop()
        {
            timer.Stop();
            StartStop.Content = "Start";
            isClockTicking = false;
        }

        private void StartStop_Click(object sender, RoutedEventArgs e)
        {
            if (isClockTicking)
            {
                Stop();
                InitializeTimer();
            }
            else
            {
                Start();
            }
        }

        private void Start()
        {
            isClockTicking = true;
            timer.Start();
            StartStop.Content = "Stop";
        }
    }
}
