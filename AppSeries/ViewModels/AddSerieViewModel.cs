using AppSeries.Models;
using AppSeries.Services;
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

        private WSService wSService = new ("https://localhost:44388/api/");

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

        private async void PostSerie()
        {

            List<Serie> series = await wSService.GetDevisesAsync("Series");
            foreach (Serie s in series)
                Console.WriteLine(s);
            //try
            //{
            //    await wSService.PostAsync("series", Serie);
            //    Console.WriteLine("oui");
            //}
            //catch
            //{
            //    Console.WriteLine("non");
            //}

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
