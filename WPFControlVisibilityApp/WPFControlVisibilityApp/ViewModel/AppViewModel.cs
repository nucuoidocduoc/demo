using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WPFControlVisibilityApp.ViewModel
{
    public class AppViewModel : INotifyPropertyChanged
    {
        private bool _isPanelVisible;
        private bool _isConnected;
        private bool _isPlay;
        private bool _isStop;
        private ICommand _showPanelCommand;
        private ICommand _hidePanelCommand;

        public AppViewModel()
        {
            // Set Default Panel Visibility //
            IsPanelVisible = false;
        }

        // Panel Visibility Property //
        public bool IsPanelVisible
        {
            get
            {
                return _isPanelVisible;
            }
            set
            {
                _isPanelVisible = value;
                OnPropertyChanged();
            }
        }

        public bool IsConnected
        {
            get => _isConnected;
            set
            {
                _isConnected = value;
                OnPropertyChanged();
            }
        }

        public bool IsPlay
        {
            get => _isPlay;
            set
            {
                _isPlay = value;
                OnPropertyChanged();
            }
        }

        public bool IsStop
        {
            get => _isStop;
            set
            {
                _isStop = value;
                OnPropertyChanged();
            }
        }

        // Show Panel Method //
        public void ShowPanel()
        {
            IsPanelVisible = true;
        }

        // Show Panel Command //
        public ICommand ShowPanelCommand
        {
            get
            {
                if (_showPanelCommand == null)
                {
                    _showPanelCommand = new RelayCommand(p => IsPanelVisible = true);
                }
                return _showPanelCommand;
            }
        }

        // Hide Panel Method //
        public void HidePanel()
        {
            IsPanelVisible = false;
        }

        // Hide Panel Command //
        public ICommand HidePanelCommand
        {
            get
            {
                if (_hidePanelCommand == null)
                {
                    _hidePanelCommand = new RelayCommand(p => HidePanel());
                }
                return _hidePanelCommand;
            }
        }

        // Close App Command //
        private ICommand _closeCommand;

        public ICommand CloseAppCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new RelayCommand(p => ((MainWindow)p).Close());
                }
                return _closeCommand;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            if (!string.IsNullOrEmpty(propName))
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }

        private RelayCommand _connectCommand;

        public ICommand ConnectCommand
        {
            get
            {
                if (_connectCommand == null)
                {
                    _connectCommand = new RelayCommand(sender => IsConnected = true);
                }

                return _connectCommand;
            }
        }

        private RelayCommand playCommand;

        public ICommand PlayCommand
        {
            get
            {
                if (playCommand == null)
                {
                    playCommand = new RelayCommand(sender => IsPlay = !IsPlay);
                }

                return playCommand;
            }
        }

        private RelayCommand stopCommand;

        public ICommand StopCommand
        {
            get
            {
                if (stopCommand == null)
                {
                    stopCommand = new RelayCommand(sender => IsStop = true);
                }

                return stopCommand;
            }
        }
    }
}