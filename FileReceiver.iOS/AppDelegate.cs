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
		App _app;

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
			_app = new App ();
			LoadApplication(_app);

            return base.FinishedLaunching(app, options);
        }

		// In your AppDelegate class:
		public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			//Console.WriteLine ("Invoked with OpenUrl: {0}", url.AbsoluteString);
			var name = url.PathComponents [url.PathComponents.Count() - 1];
			var text = "*" + name + "*"; //System.IO.File.ReadAllText(url.AbsoluteString);
			_app.IncomingFile = new IncomingFile 
			{
				Name =  name,
				Content = text
			};
			NSNotificationCenter.DefaultCenter.PostNotificationName ("OpenUrl", url);
			return true;
		}
    }
}
