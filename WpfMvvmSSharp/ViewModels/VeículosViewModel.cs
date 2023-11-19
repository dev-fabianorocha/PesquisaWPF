using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMvvmSSharp.Models;
using WpfMvvmSSharp.Services;

namespace WpfMvvmSSharp.ViewModels
{
    public class VeículosViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;


        private string _marca;
        public string Marca 
        {
            get => _marca;
            set
            {
                if (_marca != value)
                {
                    _marca = value;
                    NotifyPropertyChanged("Marca");
                }
            }
        }

        public ObservableCollection<Veículos> Veículos { get; set; }

        public ICommand BuscarVeículos { get; set; }



        public VeículosViewModel()
        {
            BuscarVeículos = new RelayCommand(ObterVeículos);
        } 

        public void ObterVeículos(object obj)
        {
            var veículosList = new Veículos().ObterVeículos(Marca);
            Veículos = new ObservableCollection<Veículos>(veículosList as List<Veículos>);
            NotifyPropertyChanged("Veículos");
        }

        public void NotifyPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
