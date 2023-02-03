using AppSeries.Models;
using AppSeries.Services;
using AppSeries.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
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
        public IRelayCommand SeeAll { get; }

        private List<Serie> series;

        public List<Serie> Series
        {
            get { return series; }
            set { series = value; }
        }

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
            SeeAll = new RelayCommand(ChangeWindow);
            Serie = new Serie();
        }

        private void ChangeWindow()
        {
            App.rootFrame.Navigate(typeof(SeeAllSeries));
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
