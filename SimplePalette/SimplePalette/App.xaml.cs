using Xamarin.Forms;

namespace SimplePalette
{
	public partial class App : Application
	{
		const string redComp = "redComp";
		const string greenComp = "greenComp";
		const string blueComp = "blueComp";


		public App()
		{
			InitializeComponent();

			if (Properties.ContainsKey(redComp)) { RedComposition = (int)Properties[redComp]; }

			if (Properties.ContainsKey(greenComp)) { GreenComposition = (int)Properties[greenComp]; }

			if (Properties.ContainsKey(blueComp)) { BlueComposition = (int)Properties[blueComp]; }

			//Invoke maincontentPage
			MainPage = new SimplePalette();
		}


		//Get color value data and set color value data
		public int RedComposition { set; get; }
		public int GreenComposition { set; get; }
		public int BlueComposition { set; get; }


		protected override void OnStart()
		{


		}

		protected override void OnSleep()
		{
			//Save keypad data on sleep
			Properties[redComp] = RedComposition;
			Properties[greenComp] = GreenComposition;
			Properties[blueComp] = BlueComposition;
		}

		protected override void OnResume()
		{

		}

	}
}
