using Wpf.ViewModels;

namespace Wpf.Commands
{
    internal class StartCommand : CommandBase
    {
        private MainViewModel _model;

        public StartCommand(MainViewModel model)
        {
            _model = model;
        }

        public override void Execute(object parameter)
        {
            _model.Timeable.Start();
            _model.Timer.Start();
            _model.StopEnabled = false;
        }
    }
}
