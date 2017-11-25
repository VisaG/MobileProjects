/**
 * Third Navigation Modal Page:-ImageDetailPage
 
 * The class implemets the following: - 
 * 
 * - Display image selected using data binding
 * - If default image selected will only display information
 * - Information of defalut images cannot be 
 * - User can add images to the list
 * - On select of image
 * 		- If default image is selected, context menu will display move up, move down and view functionality
 * 		- Other non default images will have remove menu in addition to the above mentioned
 * - User can remove images, move images, add images
 * - On selection of view in the menu, user can navigate to Image Detail Page
 * 		- If default user can only view image details, cannot edit image details, cancel button will navigate
 * 		  to ImageDetailPage
 * 		- if not default, user can change source, detail, title, date. User can either saev or cancel changes
 * 		  On click of button user can navigate back to ImageDetailList
 * 
 * All changes made is saved to xml file and the same information is retrieved after app starts
 * 
 * UNFORTUNATELY DUE TO TIME CONSTRAINTS, DATA ENTRY IS CHECKED ONLY FOR NULL AND EMPTY STRING
 *   
 * @author Visalakshi Gopalakrishnan Student Id - 00000976426.
 * 
 *         Project 3 : Photo Frame, COEN 268 - WINTER 2017 
 * 
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using Xamarin.Forms;

namespace DynamicPhotoFrame
{
	public partial class ImageDetailPage : ContentPage
	{
		//Save App Data
		App app = Application.Current as App;
		String iSource, iTitle, iDetail, iDate;
		String detail, url, title, date;
		Image im;

		public ImageDetailPage()
		{
			InitializeComponent();
		}

		public ImageDetailPage(Image image)
		{
			InitializeComponent();
			BindingContext = image;
			warn.IsVisible = false;

			//Save image detail information, in case user makes changes 
			//and decides to cancel and not save
			iSource = imgSourceText.Text;
			iTitle = imgTitle.Text;
			iDetail = imgDetail.Text;
			iDate = imgDate.Text;
			im = image;


			//item.Type.Contains("Reserved")
			int item_image = Int32.Parse(image.Type);

			//User cannot edit details
			if (item_image < 5)
			{
				save.IsVisible = false;
				cancel.IsVisible = false;
				back.IsVisible = true;
				editLabel.IsVisible = false;
				viewLabel.IsVisible = true;
				warnDate.IsVisible = false;

			}
			else {

				viewLabel.IsVisible = false;
				editLabel.IsVisible = true;
				back.IsVisible = false;
				save.IsVisible = true;
				cancel.IsVisible = true;
				imgSourceText.IsEnabled = true;
				imgTitle.IsEnabled = true;
				imgDetail.IsEnabled = true;
				imgDate.IsEnabled = true;
			}

		}

		async void onBackNavButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync();
		}


		//on cancel reset the textbox to old values
		async void onCancelButtonClicked(object sender, EventArgs e)
		{		   
			imgSourceText.Text = iSource;
			imgTitle.Text = iTitle;
			imgDetail.Text = iDetail;
			imgDate.Text = iDate;
			await Navigation.PopModalAsync();
		}



		//On user confirmaton of changes, save changes to xml file
		async void onSaveClicked(object sender, EventArgs e)
		{
			app.RefreshImage = 1;

			int indx = im.ImageBody.Images.IndexOf(im);
			im.ImageBody.Images[indx].ImgSource = im.ImageFileName;

			string s = ConversionExt.SerializeObject(im.ImageBody);
			ConversionExt.Commit("visaPJ3.xml", s);
			app.RefreshImage = 1;

			await Navigation.PopModalAsync();
		}


		//Check for null
		void imageSourceCompleted(object sender, EventArgs e)
		{
			warn.IsVisible = false;
			 url = imgSourceText.Text;

			if ((url != null) && (url.Length > 0))
			{
				warn.IsVisible = false;
				imgSource.Source = url;

			}
			else {

				warn.IsVisible = true;
				imgSourceText.Text = iSource;
			}
		}



		//Check for null
		void EntryDetailCompleted(object sender, EventArgs e)
		{
			 detail = imgDetail.Text;

			if (detail == null || detail.Length == 0)
			{
				imgDetail.Text = "Detail";
			}
			else {
				imgDetail.Text = detail;
			}

			
		}

		//Check for empty string
		void EntryTitleCompleted(object sender, EventArgs e)
		{
			title = imgTitle.Text;

			if (title == null || title.Length == 0)
			{
				imgTitle.Text = "Title";
			}
			else {
				imgTitle.Text = title;
			}
		}

		//Check for mm/dd/yy format 
		void EntryDateCompleted(object sender, EventArgs e)
		{
			String date = imgDate.Text;

			DateTime Test;
			if (DateTime.TryParseExact(date, "MM/dd/yyyy", null, DateTimeStyles.None, out Test) == true)
			{
				imgDate.Text = date;
				warnDate.IsVisible = false;
			}

			else {
				warnDate.Text = "Please enter in correct format";
				imgDate.Text = "mm/dd/yyyy";
			}
		}

	}
}
