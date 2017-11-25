/**
 * The program below provides a simulation of Photo Frame. 
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
 * - Tap on frame, set that image as current image and highlight frame
 * - On tap disable switch
 * - Co-ordinate slider, steepr and entry values
 * - User can add and remove images 
 * - On image only when string is not empty, starts with basic Url format
 * 	 https://www. or hhtp://www.
 * - User cannot add duplicate images
 * - Preserve 4 default images and any new image added after the application closes
 *   
 * @author Visalakshi Gopalakrishnan Student Id - 00000976426.
 * 
 *         Project 2 : Photo Frame, COEN 268 - WINTER 2017
 */





using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using Xamarin.Forms;


namespace StaticPhotoFrame
{
	public partial class PhotoFrame : ContentPage
	{

		//Provide shared access to the Application instance for the current AppDomain
		App app = Application.Current as App;

		//Store Image Source string and Image store 
		List<KeyValuePair<String, ImageSource>> imageSourceDict =
			new List<KeyValuePair<String, ImageSource>>();

		int imageDisplayed = 1;
		int displayTimeInterval = 8;
		int currImageIndex = 0;
		bool _stopTimer = false;
		int _timerInterval = 1;
		StringBuilder imageStringBuilderUris = new StringBuilder();
		String imageStringUris = null;

		public PhotoFrame()
		{
			InitializeComponent();


			//Image from Uri
			String uriStr = "https://www.gstatic.com/webp/gallery3/1_webp_a.sm.png";
			uriImage.Source = ImageSource.FromUri(new Uri(uriStr));

			imageSourceDict.Add(new KeyValuePair<String, ImageSource>(uriStr, uriImage.Source));

			//From File
			String fileStr = "brooklynmuseum.jpg";
			fileImage.Source = ImageSource.FromFile(fileStr);

			imageSourceDict.Add(new KeyValuePair<String, ImageSource>(fileStr, fileImage.Source));

			//Image from Resource
			String resStr = "StaticPhotoFrame.EmbImage.jpg";
			EmbImage.Source = ImageSource.FromResource(resStr);
			imageSourceDict.Add(new KeyValuePair<String, ImageSource>(resStr, EmbImage.Source));


			//Image from Stream
			String streamId = "StaticPhotoFrame.StreamImage.jpg";
			streamImage.Source = ImageSource.FromStream(() =>
			{
				Assembly assembly = GetType().GetTypeInfo().Assembly;
				Stream stream = assembly.GetManifestResourceStream(streamId);
				return stream;
			});

			imageSourceDict.Add(new KeyValuePair<String, ImageSource>(streamId, streamImage.Source));


			// At start of application
			if (app.SliderValue == 0)
			{
				app.SliderValue = 8;
				displayTimeInterval = app.SliderValue;
				timeSlider.Value = app.SliderValue;
				imageCount.Text = 1 + " / " + (imageStack.Children.Count);

			}

			// Restore app values
			currImageIndex = app.CurrImageIndex;
			imageDisplayed = app.ImageDisplayed;
			timeSlider.Value = app.SliderValue;
			imageStringUris = app.StrUris;
			if (app.SwitchToggledStatus == 2)
			{
				switchToggle.IsToggled = false;
			}

			//Restore images from app data
			RestoreUris();

			imageCount.Text = imageDisplayed + " / " + (imageStack.Children.Count);




			//Point to the Current Image Source
			KeyValuePair<String, ImageSource> t = imageSourceDict[currImageIndex];
			CurrentImage.Source = t.Value;

			//Method to invoke Device.StartTimer()
			myTimer();
		}

		//Method to restore newly added stack on app closing
		void RestoreUris()
		{
			if (imageStringUris != null)
			{
				string[] imageStringUriArrray = imageStringUris.Split(' ');
				foreach (string uri in imageStringUriArrray)
				{
					String str = uri.TrimStart();
					if ((str != null) && (str.Length > 0))
					{
						ImageSource addImageSource = createImageWithFrame(uri);
						imageSourceDict.Add(new KeyValuePair<String, ImageSource>(uri, addImageSource));
					}
				}
			}
		}

		void myTimer()
		{
			Device.StartTimer(TimeSpan.FromSeconds(1), () =>
				  {
					  //Set app.CurrImageIndex to recover after sleep.
					  imageDisplayed = currImageIndex + 1;
					  app.CurrImageIndex = currImageIndex;
					  app.ImageDisplayed = imageDisplayed;

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
						  if (switchToggle.IsToggled)
							  app.SwitchToggledStatus = 1;
						  if ((displayTimeInterval - _timerInterval) == 3)
						  {
							  ActivityIndicatorSetStatus(true);
						  }

						  //Display next image after time interval
						  if (_timerInterval >= displayTimeInterval)
						  {
							  currImageIndex++;
							  if (currImageIndex >= imageSourceDict.Count)
								  currImageIndex = 0;

							  KeyValuePair<String, ImageSource> imageKv = imageSourceDict[currImageIndex];
							  CurrentImage.Source = imageKv.Value;
							  ActivityIndicatorSetStatus(false);

							  imageDisplayed = currImageIndex + 1;
							  imageCount.Text = imageDisplayed + " / " + (imageStack.Children.Count);

							  _timerInterval = 1;
						  }
						  else {
							  _timerInterval++;

						  }

					  }
					  return true;
				  });
		}

		//User can toggle switch
		void OnSwitchToggled(object sender, ToggledEventArgs e)
		{
			if (!e.Value)
			{
				_stopTimer = true;
				app.SwitchToggledStatus = 2;

			}
			else {
				if (_stopTimer)
				{
					_stopTimer = false;

				}
			}

		}

		//Create new Frame with stacklayout for newly added image
		private ImageSource createImageWithFrame(String uri)
		{
			Image addImage = new Image
			{
				Source = new UriImageSource
				{
					Uri = new Uri(uri)
				},

				WidthRequest = 30
			};


			Label label = new Label
			{
				Text = uri,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				LineBreakMode = LineBreakMode.MiddleTruncation
			};

			int index = imageSourceDict.Count;

			Frame frame = new Frame
			{
				//Classid is the frame identifier
				ClassId = index + "",
				OutlineColor = Color.Accent,
				Padding = new Thickness(5, 5, 5, 5),

				Content = new StackLayout
				{
					Orientation = StackOrientation.Horizontal,
					Children = {
						addImage,
						label
					}
				}

			};
			TapGestureRecognizer tapGesture = new TapGestureRecognizer();
			tapGesture.Tapped += OnFrameTapped;
			frame.GestureRecognizers.Add(tapGesture);

			imageStack.Children.Add(frame);
			return addImage.Source;

		}



		void addButtonClicked(object sender, EventArgs e)
		{

			//String uri = "https://www.gstatic.com/webp/gallery3/1_webp_a.sm.png";
			//String uri = "http://www.scrubtheweb.com/images/home-icon.png";

			String uri = uriImageSourceText.Text;

			//Control user input
			if ((uri != null) && ((uri.StartsWith("https://www.", StringComparison.Ordinal))
								  || (uri.StartsWith("http://www.", StringComparison.Ordinal)))
				&& !(uri.Contains(" ")))
			{

				bool createFrame = true;
				for (int i = 0; i < imageSourceDict.Count; i++)
				{
					//Avoid add of duplicate image
					if (string.Compare(uri, imageSourceDict[i].Key, StringComparison.CurrentCulture) == 0)
					{
						DisplayAlert("Error", "Duplicate Image ", "OK");
						uriImageSourceText.Text = " ";
						createFrame = false;
						break;
					}
				}

				//Create new frame with StackLayout only if user input valid string Url
				if (createFrame)
				{
					ImageSource addImageSource = createImageWithFrame(uri);
					imageSourceDict.Add(new KeyValuePair<String, ImageSource>(uri, addImageSource));
					imageStringBuilderUris.Append(uri).Append(" ");
					imageStringUris = imageStringBuilderUris.ToString();
					app.StrUris = imageStringUris;
					uriImageSourceText.Text = "";
				}

			}
			else {
				DisplayAlert("Invalid", "Please enter valid string uri: ", "OK");
				uriImageSourceText.Text = "";
			}

		}




		void OnRemoveButtonClicked(object sender, EventArgs e)
		{

			removeButton.IsEnabled = false;
			removeButton.IsVisible = false;

			imageStack.Children.RemoveAt(currImageIndex);
			imageSourceDict.RemoveAt(currImageIndex);

			//delete and rebuilt Url string to store in app and retrieve after app closes
			imageStringBuilderUris.Clear();
			for (int i = 4; i < imageSourceDict.Count; i++)
			{
				imageStringBuilderUris.Append(imageSourceDict[i].Key).Append(" ");
			}

			imageStringUris = imageStringBuilderUris.ToString();
			app.StrUris = imageStringUris;

			currImageIndex = currImageIndex - 1;
			imageDisplayed = currImageIndex;

			app.CurrImageIndex = currImageIndex;
			app.ImageDisplayed = imageDisplayed;


			KeyValuePair<String, ImageSource> newImageKv = imageSourceDict[currImageIndex];
			CurrentImage.Source = newImageKv.Value;


			//Get frame identifier
			for (int i = 0; i < imageStack.Children.Count; i++)
			{


				if (Int32.Parse(imageStack.Children[i].ClassId) != i)
				{
					imageStack.Children[i].ClassId = i + "";
				}
			}

			switchToggle.IsToggled = true;


		}



		void OnFrameTapped(object sender, EventArgs e)
		{

			Frame currFrame = (Frame)sender;
			currFrame.OutlineColor = Color.Fuchsia;
			int imageIndex = Int32.Parse(currFrame.ClassId);
			_stopTimer = true;
			_timerInterval = 1;


			currImageIndex = imageIndex;
			imageDisplayed = imageIndex + 1;

			imageCount.Text = imageDisplayed + " / " + (imageStack.Children.Count);

			app.CurrImageIndex = currImageIndex;
			app.ImageDisplayed = imageDisplayed;

			//Switch toggle off when tapped on new added images
			if (imageIndex > 3)
			{
				switchToggle.IsToggled = false;
			}
			else {

				removeButton.IsVisible = false;
				removeButton.IsEnabled = false;
				switchToggle.IsToggled = true;
			}

			//Delay loading of image to trigger activity indicator
			ActivityIndicatorSetStatus(true);
			Device.StartTimer(TimeSpan.FromSeconds(3), () =>
				{
					currFrame.OutlineColor = Color.Accent;

					// set the timer to false after 3 secs.
					if (!switchToggle.IsToggled)
					{
						removeButton.IsVisible = true;
						removeButton.IsEnabled = true;
						//						_stopTimer = false;
					}

					KeyValuePair<String, ImageSource> imageKvIndex = imageSourceDict[imageIndex];
					CurrentImage.Source = imageKvIndex.Value;

					if (currImageIndex == 0)
					{
						currImageIndex = imageSourceDict.Count - 1;
					}

					_timerInterval = displayTimeInterval;
					ActivityIndicatorSetStatus(false);
					if (switchToggle.IsToggled)
					{
						_stopTimer = false;
						if (currImageIndex != 0)
						{
							if (!_stopTimer)
								currImageIndex--;
						}
					}
					return false;
				});

		}

		void ActivityIndicatorSetStatus(bool status)
		{
			activityIndicator.IsVisible = status;
			activityIndicator.IsRunning = status;
		}

		//Slider value trigger event
		void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
		{

			int sliderValue = (int)timeSlider.Value;
			app.SliderValue = sliderValue;
			stepperValue.Text = "[ " + (int)timeSlider.Value + " ]";
			//stepper.Value = (int)timeSlider.Value;
			entryNum.Text = ((int)timeSlider.Value).ToString();
			entryValue.Text = "[ " + (int)timeSlider.Value + " ]";
			slideLabel.Text = "[ " + (int)timeSlider.Value + " ]";
			displayTimeInterval = (int)timeSlider.Value;

		}

		//Stepper value trigger event
		void OnStepperValueChanged(object sender, ValueChangedEventArgs args)
		{
			entryNum.Text = stepper.Value.ToString();
			timeSlider.Value = stepper.Value;
			entryValue.Text = "[ " + stepper.Value + " ]";
			slideLabel.Text = "[ " + stepper.Value + " ]";
			stepperValue.Text = "[ " + stepper.Value + " ]";
			displayTimeInterval = (int)stepper.Value;
		}

		//Entry value trigger event
		void EntryCompleted(object sender, EventArgs e)
		{

			string prevValue = string.Empty;
			int outNum;
			bool result = int.TryParse(entryNum.Text, out outNum);

			//Invalid if entry is not integer and if not in between [1-60]
			if (result == false || !(outNum >= 1 && outNum <= 60))
			{

				DisplayAlert("Invalid", "Enter time secs range [1-60] ", "OK");
				entryValue.Text = " ";
				entryNum.Text = prevValue;
			}
			else {


				entryNum.Text = outNum.ToString();
				entryValue.Text = "[ " + outNum + " ]";
				timeSlider.Value = outNum;
				slideLabel.Text = "[ " + outNum + " ]";
				stepperValue.Text = "[ " + outNum + " ]";
				stepper.Value = outNum;
				displayTimeInterval = outNum;
			}

		}

	}
}
