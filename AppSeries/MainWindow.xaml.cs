// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using AppSeries.Models;
using AppSeries.Services;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace AppSeries
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {

        private WSService wSService;
        public MainWindow()
        {
            this.InitializeComponent();

            wSService = new("https://localhost:44388/api/");

            
        }

        private async void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Clicked";
            Console.WriteLine("clické");
            List<Serie> series = await wSService.GetDevisesAsync("Series");
            Serie serie = await wSService.GetDeviseAsync("Series", 1);
            foreach(Serie s in series)
                Console.WriteLine(s);
            Console.WriteLine(serie);
        }
    }
}
