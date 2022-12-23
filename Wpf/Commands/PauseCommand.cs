using Wpf.ViewModels;

namespace Wpf.Commands
{
    internal class PauseCommand : CommandBase
    {
        private MainViewModel _model;

        public PauseCommand(MainViewModel model)
        {
            _model = model;
        }

        public override void Execute(object parameter)
        {
            _model.Timeable.Pause();
            _model.Timer.Stop();
            _model.StopEnabled = true;
        }
    }
}
