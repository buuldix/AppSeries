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
        public IRelayCommand EditButton { get; }
        public IRelayCommand DeleteButton { get; }


        //private WSService wSService = new ("https://apiseriesbubu.azurewebsites.net/api/");
        private WSService wSService = new("https://localhost:44388/api/");
        private Serie serie;

        public Serie Serie
        {
            get { return serie; }
            set { serie = value; OnPropertyChanged("Serie"); }
        }


        private List<Serie> series;

        public List<Serie> Series
        {
            get { return series; }
            set { series = value; OnPropertyChanged("Series"); }
        }

        public AddSerieViewModel()
        {
            BtnAdd = new RelayCommand(PostSerie);
            SeeAll = new RelayCommand(ChangeWindow);
            EditButton = new RelayCommand(PutSerie);
            DeleteButton = new RelayCommand(DeleteSerie);
            Serie = new Serie();
            Series = new List<Serie>();
            loadData();

        }

        private async void DeleteSerie()
        {
            Console.WriteLine("Deleting...");
            await wSService.DeleteAsync("Series", Serie.Serieid);
            Console.WriteLine("Serie delete !");
            loadData();
        }

        private async void PutSerie()
        {
            Console.WriteLine("Updating...");
            await wSService.PutAsync("Series", Serie);
            Console.WriteLine("Serie Update !");
            loadData();
        }

        private void ChangeWindow()
        {
            App.rootFrame.Navigate(typeof(SeeAllSeries));



        }

        private async void loadData()
        {
            Console.WriteLine("loading...");
            Series = await wSService.GetDevisesAsync("Series");

            if (Series == null)
                Console.WriteLine("y a r");
            else
                Serie = Series[0];

        }

        private async void PostSerie()
        {
            try
            {
                await wSService.PostAsync("series", Serie);
                Serie = new();
            }
            catch
            {
                Console.WriteLine("non");
            }

        }


        
    }
}
