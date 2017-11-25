using Xamarin.Forms;

namespace StaticPhotoFrame
{
	public partial class App : Application
	{
		const string currImageIndex = "currImageIndex";
		const string imageDisplayed = "imageDisplayed";
		const string sliderValue = "sliderValue";
		const string strUris = "strUris";
		const string switchToggledStatus = "switchToggledStatus";

		public App()
		{
			InitializeComponent();
			if (Properties.ContainsKey(currImageIndex))
			{
				CurrImageIndex = (int)Properties[currImageIndex];
			}
			if (Properties.ContainsKey(imageDisplayed))
			{
				ImageDisplayed = (int)Properties[imageDisplayed];
			}
			if (Properties.ContainsKey(sliderValue))
			{
				SliderValue = (int)Properties[sliderValue];
			}
			if (Properties.ContainsKey(strUris))
			{
				StrUris = (string)Properties[strUris];
			}
			if (Properties.ContainsKey(switchToggledStatus))
			{
				SwitchToggledStatus = (int)Properties[switchToggledStatus];
			}


			MainPage = new PhotoFrame();
		}

		public int CurrImageIndex { set; get; }
		public int ImageDisplayed { set; get; }
		public int SliderValue { set; get; }
		public string StrUris { set; get; }
		public int SwitchToggledStatus { set; get; }

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			//Handle when your app sleeps
			Properties[currImageIndex] = CurrImageIndex;
			Properties[imageDisplayed] = ImageDisplayed;
			Properties[sliderValue] = SliderValue;
			Properties[strUris] = StrUris;
			Properties[switchToggledStatus] = SwitchToggledStatus;
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
