using AppSeries.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSeries.ViewModels
{
    public class AddSerieViewModel : ObservableObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public IRelayCommand BtnAdd { get; }


        private Serie serie;

        public Serie Serie
        {
            get { return serie; }
            set { serie = value; }
        }

        public AddSerieViewModel()
        {
            BtnAdd = new RelayCommand(PostSerie);
            Serie = new Serie();
        }

        private void PostSerie()
        {
            Console.WriteLine(Serie);
        }


        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
