/**
 * First Navigation Page:-MainPhotoPage
 * 
 * The program below provides a simulation of Photo Frame similar to project 2. 
 * The project is implemented using cross platform mobile app with Xamarin.Forms (Portable)
 * and runs on two different platform emulators : iPhone and Andriod.
 * 
 * The program implements the following: - 
 * 
 * - Display default 4 images: ImageSource from Uri, ImageSource from file, 
 * 	 ImageSource from resource, ImageSource from stream
 * - Display images at certain interval that can be reset by user
 * - Display count down before next image loads
 * - Show activityIndicator between image load.
 * - Display current index of the image
 * - Co-ordinate slider, steepr and entry values using data binding
 * - Preserve data added after the application closes
 *   
 * @author Visalakshi Gopalakrishnan Student Id - 00000976426.
 * 
 *         Project 3 : Photo Frame, COEN 268 - WINTER 2017 
 * 
 */



using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xamarin.Forms;


namespace DynamicPhotoFrame
{
	public partial class MainPhotoPage : ContentPage
	{

		//Provide shared access to the Application instance for the current AppDomain
		App app = Application.Current as App;

		public readonly MainPhotoModel _viewModel;
		int displayTimeInterval;
		int imageDisplayed = 1;
		int currImageIndex = 0;
		bool _stopTimer = false;
		int _timerInterval = 1;


		//Store Image Source string and Image store 
		List<KeyValuePair<String, ImageSource>> imageSourceDict;
		
		
		Image im = new Image();

		public MainPhotoPage()
		{
			//Provides BindingContext for Slider, stepper, entry
			_viewModel = new MainPhotoModel();

			BindingContext = _viewModel;

			InitializeComponent();

			getImageBodyFromXML();

			//At start of app before app data save
			if (app.SliderValue == 0)
			{
				app.SliderValue = 10;
				displayTimeInterval = app.SliderValue;
				slider.Value = app.SliderValue;
			}

			slider.Value = app.SliderValue;
			currImageIndex = app.CurrImageIndex;
			CurrentImage.Source = imageSourceDict[currImageIndex].Value;

			myTimer();		

		}


		//Reads from default xml at start of program
		//Subsequent reads are from saved file
		public ImageBody getImageBodyFromXML()
		{

			ImageBody imb = new ImageBody();
			imageSourceDict =
			new List<KeyValuePair<String, ImageSource>>();

			imb.Images.Add(new Image());

			//Check to see if a new updated file has been created
			bool r = DependencyService.Get<ISaveAndLoad>().IfExists("visaPJ3.xml");
			if (r)
			{
				String serializedStr = DependencyService.Get<ISaveAndLoad>().LoadText("visaPJ3.xml");
				using (TextReader reader = new StringReader(serializedStr))
				{
					XmlSerializer serializer = new XmlSerializer(typeof(ImageBody));
					imb = (ImageBody)serializer.Deserialize(reader);
				}
			}
			else {

				//Read defalut at start of the project
				var assembly = typeof(ImageViewModel).GetTypeInfo().Assembly;
				Stream stream = assembly.GetManifestResourceStream("DynamicPhotoFrame.ImageList.xml");

				StreamReader reader = new StreamReader(stream);
				XmlSerializer xml = new XmlSerializer(typeof(ImageBody));
				imb = xml.Deserialize(reader) as ImageBody;
				stream.Dispose();
			}

			int imageCount = 1;
			foreach (Image i in imb.Images)
			{
				i.ImageBody = imb;
				int item_type = Int32.Parse(i.Type);

				//Retreive default images
				switch (item_type)
				{
					case 1:
						i.ImgSource = ImageSource.FromUri(new Uri(i.ImageFileName));
						break;
					case 2:
						i.ImgSource = ImageSource.FromFile(i.ImageFileName);
						break;
					case 3:
						i.ImgSource = ImageSource.FromResource(i.ImageFileName);
						break;
					case 4:
						String streamId = i.ImageFileName;
						i.ImgSource = ImageSource.FromStream(() =>
						{
							Assembly a = GetType().GetTypeInfo().Assembly;
							Stream s = a.GetManifestResourceStream(streamId);
							return s;
						});
						break;
					default:
						i.ImgSource = i.ImageFileName;
						break;
				}
				imageSourceDict.Add(new KeyValuePair<String, ImageSource>(i.ImageFileName, i.ImgSource));
				imageCount++;
			}
			return imb;
		}

		//Slider value trigger event
		void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
		{
			Slider _slider = (Slider)sender;
		 	displayTimeInterval = (int) _slider.Value;
			app.SliderValue = (int)_slider.Value;
			if (timeSelect != null)
			{
				timeSelect.Text = "Time Interval selected: " + app.SliderValue + " secs";

			}
		}

		//Check for valid entry
		void EntryCompleted(object sender, EventArgs e)
		{
			int outNum;
			bool result = int.TryParse(entryTime.Text, out outNum);

			//Invalid if entry is not integer and if not in between [1-60]
			if (result == false || !(outNum >= 1 && outNum <= 60))
			{

				DisplayAlert("Invalid", "Enter time secs range [1-60] ", "OK");
				entryTime.Text = displayTimeInterval.ToString();
			}
			else {

				entryTime.Text = displayTimeInterval.ToString();
			}

		}

		//User can toggle switch
		void OnSwitchToggled(object sender, ToggledEventArgs e)
		{
			if (!e.Value)
			{
				_stopTimer = true;

			}
			else {
				if (_stopTimer)
				{
					_stopTimer = false;

				}
			}

		}

		//Display images at time interval
		void myTimer()
		{
			Device.StartTimer(TimeSpan.FromSeconds(1), () =>
				  {
					 imageCount.Text = imageDisplayed + " / " + (imageSourceDict.Count);
					 imageDisplayed = currImageIndex + 1;
				      app.CurrImageIndex = currImageIndex;
					
					  Device.BeginInvokeOnMainThread(() =>
					 {

						 countDown.Text = (displayTimeInterval - _timerInterval) + ": secs";

					 });


					  if (_stopTimer)
					  {
						  //Do nothing
						  ;
					  }
					  else {
					
						  ActivityIndicatorSetStatus(true);
						  //Display next image after time interval
						  if (_timerInterval >= displayTimeInterval)
						  {
							  if (app.RefreshImage == 1)
							  {
								  app.RefreshImage = 0;	  
								  getImageBodyFromXML();
							  }
						      currImageIndex++;
							  if (currImageIndex >= imageSourceDict.Count)
								  currImageIndex = 0;

							  KeyValuePair<String, ImageSource> imageKv = imageSourceDict[currImageIndex];
							  CurrentImage.Source = imageKv.Value;
						      ActivityIndicatorSetStatus(false);
							  

							  imageDisplayed = currImageIndex + 1;
							  imageCount.Text = imageDisplayed + " / " + (imageSourceDict.Count);

							  _timerInterval = 1;
						  }
						  else {
							  _timerInterval++;

						  }

					  }
					  return true;
				  });
		}


		void ActivityIndicatorSetStatus(bool status)
		{
			activityIndicator.IsVisible = status;
			activityIndicator.IsRunning = status;
		}


		//Go to page 2 for ImageDetailList
		async void onNavButtonClicked(object sender, EventArgs e)
		{
			
			await Navigation.PushAsync(new ImageListPage{ Title = "Photo NoteBook : Image List " });
		}


	}
}
