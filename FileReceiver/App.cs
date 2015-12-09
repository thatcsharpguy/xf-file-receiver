using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FileReceiver
{
    public class App : Application
    {


        public App()
        {
            // The root page of your application
			MainPage = new FilePage();
        }

		private IncomingFile _incomingFile;

		public IncomingFile IncomingFile
		{
			get { return _incomingFile; }
			set 
			{
				_incomingFile 	= value; 

				// Call the page's method to refresh the UI
				// this could be avoided with Bindings
				(MainPage as FilePage).SetIncomingFile (_incomingFile);
			}
		}

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
