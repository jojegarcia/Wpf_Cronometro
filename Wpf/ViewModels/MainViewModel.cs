using Core;
using System.Timers;
using System.Windows.Input;
using Wpf.Commands;

namespace Wpf.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private ITimeable _timeable;
        private Timer _timer;
        private string _time;
        private bool _stopEnabled = true;

        /// <summary>
        /// Provides the elapsed time
        /// </summary>
        public string Time
        { 
            get { return _time; }
            set 
            { 
                _time = value;
                OnPropertyChanged(nameof(Time));
            }
        }

        /// <summary>
        /// Enables or disables Stop button
        /// </summary>
        public bool StopEnabled
        {
            get { return _stopEnabled; }
            set
            {
                _stopEnabled = value;
                OnPropertyChanged(nameof(StopEnabled));
            }
        }

        public ITimeable Timeable { get { return _timeable; } }
        public Timer Timer { get { return _timer; } }

        public ICommand StartCommand { get; }
        public ICommand PauseCommand { get; }
        public ICommand StopCommand { get; }

        public MainViewModel(ITimeable pTimeable)
        {
            _timeable = pTimeable;

            ChronometerUpdate();

            _timer = new Timer(interval: 1000);
            _timer.Elapsed += OnTimerElapsed;

            StartCommand = new StartCommand(this);
            PauseCommand = new PauseCommand(this);
            StopCommand = new StopCommand(this);
        }
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            ChronometerUpdate();
        }

        /// <summary>
        /// Updates the elapsed time
        /// </summary>
        public void ChronometerUpdate()
        {
            this.Time = _timeable.getTime().Value.ToString(Constants.TimeSpan_HHMMSS);
        }

    }

}
