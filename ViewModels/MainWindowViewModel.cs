using System.Reactive.Subjects;
using System.Windows.Input;
using ReactiveUI;

namespace Avalonia.DisableButtonThroughAMethod.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private bool _isButtonEnabled;
        private Subject<bool> _canExecuteCommand;


        public bool IsButtonEnabled 
        { 
            get => this._isButtonEnabled; 
            set 
            {
                this.RaiseAndSetIfChanged( ref this._isButtonEnabled, value );
                this._canExecuteCommand.OnNext(value);
            } 
        }

        public ICommand ClickMeCommand { get; }

        public MainWindowViewModel()
        {
            this._canExecuteCommand = new Subject<bool>();

            this.ClickMeCommand = ReactiveCommand.Create(this.OnClickMe, canExecute: this._canExecuteCommand);
            
            this.IsButtonEnabled = true;
        }

        private void OnClickMe()
        {
        }
    }
}
