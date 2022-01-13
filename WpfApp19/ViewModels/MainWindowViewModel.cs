using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp19.Models;

namespace WpfApp19.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private double pole1;
        public double Pole1
        {
            get => pole1;
            set
            {
                pole1 = value;
                OnPropertyChanged();
            }
        }
        private double pole2;
        public double Pole2
        {
            get => pole2;
            set
            {
                pole2 = value;
                OnPropertyChanged();
            }
        }
        public ICommand CalcCommand { get; }
        private void OnCalcCommandExecuted(object p)
        {
            Pole2 = Result.Calc(Pole1);
        }
        private bool CanCalcCommandExecuted(object p)
        {
            if (Pole1 != 0 || Pole2 != 0)
                return true;
            else return false;
        }
        public MainWindowViewModel()
        {
            CalcCommand = new MyRelayCommand(OnCalcCommandExecuted, CanCalcCommandExecuted);
        }
    }
}
