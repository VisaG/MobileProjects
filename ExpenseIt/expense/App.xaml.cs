using Xamarin.Forms;

namespace expense
{
	public partial class App : Application
	{
		const string streList = "streList";

		public App()
		{
			InitializeComponent();

			if (Properties.ContainsKey(streList))
			{
				StreList = (string)Properties[streList];
			}

			MainPage = new Login();
		}

		public string StreList { set; get; }

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
