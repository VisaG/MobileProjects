/**
 * Second Navigation Modeless Page:-ImageListPage
 
 * The class implemets the following: - 
 * 
 * - Display image detail and the image information is binding to actual ImageBody
 * - Can change the sequence of 
 * - User can add images to the list
 * - On select of image
 * 		- If default image is selected, context menu will display move up, move down and view functionality
 * 		- Other non default images will have remove menu in addition to the above mentioned
 * - User can remove images, move images, add images
 * - On click of view menu, user can navigate to ImageDetailPage
 * - All user actions like move, remove, add are saved to xml file and retrieved when app restarts
 *
 * @author Visalakshi Gopalakrishnan Student Id - 00000976426.
 * 
 *         Project 3 : Photo Frame, COEN 268 - WINTER 2017 
 * 
 */


using System;
using System.Xml.Serialization;
using Xamarin.Forms;
using System.IO;
using System.Reflection;




namespace DynamicPhotoFrame
{
	public partial class ImageListPage : ContentPage
	{
		//Preserve application state
		App app = Application.Current as App;
		String url;



		public ImageListPage()
		{
			InitializeComponent();

			//Set binding context
			BindingContext = new ImageViewModel();
		}

		public ImageListPage(ImageViewModel imv)
		{
			//BindingContext = imv;
		}


		//Manipulate image cells to remove menu option from default images
		private void OnBindingContextChanged(object sender, EventArgs e)
		{
			base.OnBindingContextChanged();

			if (BindingContext == null)
				return;

			ImageCell theImageCell = ((ImageCell)sender);
			Image item = theImageCell.BindingContext as Image;

			if (item == null)
				return;

			int item_type = Int32.Parse(item.Type);

			//For 4 default images remove menu is not added
			if (item_type < 5 )
			{
				theImageCell.ContextActions.RemoveAt(3);
			
			}

		}


		//User input of data for image add
		void ImageSourceCompleted(object sender, EventArgs e)
		{
			url = ImageSourceText.Text;
		}

	

		//On add new image is stored to file
		void onAddButtonClicked(object sender, EventArgs e)
		{
			ImageViewModel i = BindingContext as ImageViewModel;
			ImageBody k = i.ImageBody;

			Image im = new Image();

			//Does to chk if no empty string
			if ((url != null) && (url.Length > 0))
			{
				warn.IsVisible = false;
				im.ImgSource = url;
				im.ImageFileName = url;
				im.Title = "Title";
				im.Detail = "Detail";
				im.Date = "mm/dd/yyyy";
				im.ImageBody = i.ImageBody;
				im.Type = "5";
				k.Images.Add(im);
				ImageSourceText.Text = "";
			}
			else {
				
				warn.IsVisible = true;
			}

			//Commits user new added image to xml file
			string s = ConversionExt.SerializeObject(k);
			ConversionExt.Commit("visaPJ3.xml", s);
			app.RefreshImage = 1;
		}
	}
}
