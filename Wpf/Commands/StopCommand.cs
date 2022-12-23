using Wpf.ViewModels;

namespace Wpf.Commands
{
    internal class StopCommand : CommandBase
    {
        private MainViewModel _model;

        public StopCommand(MainViewModel model)
        {
            _model = model;
        }

        public override void Execute(object parameter)
        {
            _model.Timeable.Stop();
            _model.ChronometerUpdate();
        }
    }
}
