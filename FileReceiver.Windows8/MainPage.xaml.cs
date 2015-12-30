using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Xamarin.Forms.Platform.WinRT;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

namespace FileReceiver.Windows8
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : WindowsPage
    {
        FileReceiver.App _app;
        public MainPage()
        {
            this.InitializeComponent();
            _app = new FileReceiver.App();
            LoadApplication(_app);
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            StorageFile storageFile = e.Parameter as StorageFile;
            if (storageFile != null)
            {
                string content = await FileIO.ReadTextAsync(storageFile);
                var incomingFile = new IncomingFile
                {
                    Name = storageFile.DisplayName,
                    Content = content
                };
                _app.IncomingFile = incomingFile;
            }
            base.OnNavigatedTo(e);
        }
    }
}
