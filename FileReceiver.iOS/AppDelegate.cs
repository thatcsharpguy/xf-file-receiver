using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace FileReceiver.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
		FileReceiver.App _app;

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
			Console.WriteLine ("Finished launchong");
            global::Xamarin.Forms.Forms.Init();
			_app = new App ();
			LoadApplication(_app);

            return base.FinishedLaunching(app, options);

        }


		// 
		public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{

			string path = "";
			for (int i = 0; i < url.PathComponents.Length; i++) {
				path = System.IO.Path.Combine (path, url.PathComponents [i]);
			}

			var fileName = url.PathComponents [url.PathComponents.Length - 1];

			var fileExists = System.IO.File.Exists (path);
			if(fileExists) {
				var fileContent = System.IO.File.ReadAllText (path);

				_app.IncomingFile = new IncomingFile 
				{
					Name =  fileName,
					Content = fileContent
				};
				
			}
			else{
			}
			return true;
		}
    }
}
