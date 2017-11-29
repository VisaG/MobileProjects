using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace expense
{
	public partial class Login : ContentPage
	{
		App app = Application.Current as App;
		public Login()
		{
			InitializeComponent();
		}

		void OnSubmitButtonClicked(object sender, EventArgs args)
		{

			String userName = username.Text;
			String password = passwordEntry.Text;

			if (userName != null && password !=null)
			{
				if (userName.Equals("visa", StringComparison.OrdinalIgnoreCase) && password.Equals("123", StringComparison.OrdinalIgnoreCase))
				{
					Application.Current.MainPage = new expensePage();
				}
				else
				{
					DisplayAlert("Invalid", "Please enter valid username, password ", "OK");
					username.Text = "";
					passwordEntry.Text = "";
				}
			}


		}

	}
}
