using AppSeries.Models;
using AppSeries.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSeries.ViewModels
{
    public class SeeAllSeriesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<Serie> series;

        public List<Serie> Series
        {
            get { return series; }
            set { series = value; }
        }

        private WSService wSService = new("https://apiseriesbubu.azurewebsites.net/api/");

        public SeeAllSeriesViewModel()
        {
            Console.WriteLine("contructeur");
            loadData();
        }

        private async void loadData()
        {
            Series = await wSService.GetDevisesAsync("Series");

            //foreach (Serie serie in Series)
            //    Console.WriteLine(serie);

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
