// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using AppSeries.ViewModels;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.Extensions.DependencyInjection;
using AppSeries.Views;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace AppSeries
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {

        public static FrameworkElement MainRoot { get; private set; }
        public static Frame rootFrame;
        public AddSerieViewModel AddSerieVM
        {
            get { return Ioc.Default.GetService<AddSerieViewModel>(); }
        }

        public SeeAllSeriesViewModel SeeAllSeriesVM
        {
            get { return Ioc.Default.GetService<SeeAllSeriesViewModel>(); }
        }
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            Ioc.Default.ConfigureServices(
                new ServiceCollection().AddSingleton<AddSerieViewModel>().BuildServiceProvider());
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();

            rootFrame = new Frame();

            m_window.Content = rootFrame;

            MainRoot = m_window.Content as FrameworkElement;

            rootFrame.Navigate(typeof(AddSeriePage), args.Arguments);

            m_window.Activate();
        }

        private Window m_window;
    }
}
