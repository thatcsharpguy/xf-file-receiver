using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;

using Android.Content;

namespace FileReceiver.Droid
{
	[Activity(Label = "FileReceiver", 
		MainLauncher = true, Icon = "@drawable/icon")]
	[IntentFilter(
		new[] { Intent.ActionView },
		Categories = new[]
		{ 
			Intent.CategoryDefault,
			Intent.CategoryBrowsable,
		},
		DataScheme = "file",
		DataMimeType = "*/*",
		DataPathPattern = ".*\\.md"
	)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

			var application = new App ();


			string action = Intent.Action;
			string type = Intent.Type;

			if (Intent.ActionView.Equals(action) && !String.IsNullOrEmpty(type))
			{
				// This app was launched to receive a file
				Android.Net.Uri fileUri = Intent.Data;

				string fileContent = File.ReadAllText(fileUri.Path);
				string fileName = fileUri.LastPathSegment;

				var incomingFile = new IncomingFile { Name = fileName, Content = fileContent };

				application.IncomingFile = incomingFile;
			}

			LoadApplication (application);
        }
    }
}

