using Xamarin.Forms;

namespace DynamicPhotoFrame
{
	public partial class App : Application
	{
		const string sliderValue = "sliderValue";
		const string currImageIndex = "currImageIndex";
		const string refreshImage = "refreshImage";

		public App()
		{
			InitializeComponent();

			if (Properties.ContainsKey(sliderValue))
			{
				SliderValue = (int)Properties[sliderValue];
			}
			if (Properties.ContainsKey(currImageIndex))
			{
				CurrImageIndex = (int)Properties[currImageIndex];
			}
			if (Properties.ContainsKey(refreshImage))
			{
				RefreshImage = (int)Properties[refreshImage];
			}

			//MainPage = new NavigationPage(new MainPhotoPage());
			this.MainPage = new NavigationPage(new MainPhotoPage { Title = "Photo NoteBook Image Display" });
		}
		public int SliderValue { set; get; }
		public int CurrImageIndex { set; get; }
		public int RefreshImage { set; get; }

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
			Properties[sliderValue] = SliderValue;
			Properties[currImageIndex] = CurrImageIndex;
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
