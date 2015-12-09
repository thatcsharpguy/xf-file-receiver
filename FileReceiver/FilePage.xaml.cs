using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FileReceiver
{
	public partial class FilePage : ContentPage
	{
		public FilePage ()
		{
			InitializeComponent ();
		}

		public void SetIncomingFile(IncomingFile file)
		{
			FileName.Text = file.Name;
			FileContent.Text = file.Content;
		}
	}
}

