using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace expense
{
	public partial class Profile : ContentPage
	{

		public Profile()
		{
			InitializeComponent();
		}


		void onAddNoteClicked(object sender, EventArgs e)
		{
			String t = myNote.Text;
			if (myNote.Text != null && myNote.Text.Length != 0 )
			{
				
				Label label = new Label
				{
					Text = myNote.Text,
					VerticalOptions = LayoutOptions.StartAndExpand,
					FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
					WidthRequest = 200

				};

				Button delete = new Button
				{
					
					Text = "X",
					Font = Font.SystemFontOfSize(NamedSize.Micro),
					FontAttributes = FontAttributes.Bold,
					TextColor = Color.Red,
					BorderWidth = 1,
					HorizontalOptions = LayoutOptions.End,
					VerticalOptions = LayoutOptions.EndAndExpand,
					WidthRequest = 15,
						HeightRequest= 15
				};
				delete.Clicked += deleteButtonClicked;

				StackLayout note = new StackLayout
				{
					Orientation = StackOrientation.Horizontal,
					Children = {
						
						label,
						delete
					}
			};
				noteStack.Children.Add(note);
				myNote.Text = "";


			}
			else
			{
				DisplayAlert("Invalid", "Please enter note", "OK");

			}
		}

		void deleteButtonClicked(object sender, EventArgs e)
		{

			Button button = (Button)sender;

	
			noteStack.Children.Remove((Xamarin.Forms.View)button.Parent);

		}

	}
}
