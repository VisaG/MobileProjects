using System;

using Xamarin.Forms;

namespace SimplePalette
{
	public class MyPage : ContentPage

	{

		StackLayout outerStack = new StackLayout();

		App app = Application.Current as App;

		Button redButtonAdd, redButtonMinus,
		greenButtonAdd, greenButtonMinus,
		blueButtonAdd, blueButtonMinus;

		BoxView currentBoxView;
		Color currentColor;

		Label redLabel, greenLabel, blueLabel,
		warnRedLabel, warnGreenLabel, warnBlueLabel, HSLLabel, RGBLabel;

		int redCompositon = 0;
		int greenCompositon = 0;
		int blueCompositon = 0;



		public MyPage()
		{
			Padding = new Thickness(5, Device.OnPlatform(20, 0, 0), 5, 5);

			redCompositon = app.RedComposition;
			greenCompositon = app.GreenComposition;
			blueCompositon = app.BlueComposition;


			currentColor = Color.FromRgb(redCompositon, greenCompositon, blueCompositon);


			redLabel = new Label
			{
				Text = redCompositon.ToString(),
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			greenLabel = new Label
			{
				Text = greenCompositon.ToString(),
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			blueLabel = new Label
			{
				Text = blueCompositon.ToString(),
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			warnRedLabel = new Label
			{
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				TextColor = Color.Red

			};

			warnGreenLabel = new Label
			{

				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				TextColor = Color.Red
			};

			warnBlueLabel = new Label
			{

				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				TextColor = Color.Red
			};

			HSLLabel = new Label()
			{
				Text = "HSL Value:- " + String.Format("{0:F2}, {1:F2}, {2:F2}",
														 currentColor.Hue,
														 currentColor.Saturation,
														   currentColor.Luminosity),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
			};

			RGBLabel = new Label()
			{
				Text = "RGB Value:- " + String.Format("{0:X2}-{1:X2}-{2:X2}",
														 (int)(255 * currentColor.R),
														 (int)(255 * currentColor.G),
													   (int)(255 * currentColor.B)),
				
				VerticalOptions = LayoutOptions.CenterAndExpand,
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
			};

			redButtonAdd = new Button
			{
				Text = "+",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				FontAttributes = FontAttributes.Bold,
				TextColor = Color.Red,
				BorderWidth = 1,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest = 75

			};
			redButtonAdd.Clicked += onButtonClicked;



			redButtonMinus = new Button
			{
				Text = "-",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				FontAttributes = FontAttributes.Bold,
				TextColor = Color.Red,
				BorderWidth = 1,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest = 75

			};
			redButtonMinus.Clicked += onButtonClicked;

			greenButtonAdd = new Button
			{
				Text = "+",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				FontAttributes = FontAttributes.Bold,
				TextColor = Color.Green,
				BorderWidth = 1,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest = 75

			};
			greenButtonAdd.Clicked += onButtonClicked;



			greenButtonMinus = new Button
			{
				Text = "-",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				FontAttributes = FontAttributes.Bold,
				TextColor = Color.Green,
				BorderWidth = 1,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest = 75

			};

			greenButtonMinus.Clicked += onButtonClicked;

			blueButtonAdd = new Button
			{
				Text = "+",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				FontAttributes = FontAttributes.Bold,
				TextColor = Color.Blue,
				BorderWidth = 1,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest = 75

			};
			blueButtonAdd.Clicked += onButtonClicked;

			blueButtonMinus = new Button
			{
				Text = "-",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				FontAttributes = FontAttributes.Bold,
				TextColor = Color.Blue,
				BorderWidth = 1,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest = 75

			};
			blueButtonMinus.Clicked += onButtonClicked;

			currentBoxView = new BoxView
			{
				Color = Color.FromRgb(redCompositon, greenCompositon, blueCompositon),
				WidthRequest = 75,
				HeightRequest = 75,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			StackLayout title = new StackLayout
			{
				Children =
				{
				 new Label
			{
				Text = "Choose RGB Composition",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center,
			}


				}
			};
			outerStack.Children.Add(title);


			StackLayout redLayout = new StackLayout
			{
				Children =
						{

							new Label
							{
								Text = "Choose Red Composition",
								FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
								VerticalOptions = LayoutOptions.Center,
								HorizontalOptions = LayoutOptions.StartAndExpand
							},

							new StackLayout
							{
								Orientation = StackOrientation.Horizontal,
								HorizontalOptions = LayoutOptions.StartAndExpand,
								VerticalOptions = LayoutOptions.CenterAndExpand,
								Padding = new Thickness (10, 10, 10, 0),
								Spacing = 15,

								Children =
								{

							redButtonAdd,

							redLabel,

							redButtonMinus


								}
							},

							warnRedLabel

				}
			};
			outerStack.Children.Add(redLayout);

			StackLayout greenLayout = new StackLayout
			{
				Children = {

					new Label
							{
								Text = "Choose Green Composition",
								FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
								VerticalOptions = LayoutOptions.Center,
								HorizontalOptions = LayoutOptions.StartAndExpand
							},
							new StackLayout
							{
								Orientation = StackOrientation.Horizontal,
								HorizontalOptions = LayoutOptions.StartAndExpand,
								VerticalOptions = LayoutOptions.CenterAndExpand,
								Padding = new Thickness (10, 10,10,0),
								Spacing = 15,

								Children =
								{

							greenButtonAdd,
							greenLabel,
							greenButtonMinus


								}
							},

							warnGreenLabel


				}
			};

			outerStack.Children.Add(greenLayout);

			StackLayout blueLayout = new StackLayout
			{
				Children = {

					new Label
							{
								Text = "Choose Blue Composition",
								FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
								VerticalOptions = LayoutOptions.Center,
								HorizontalOptions = LayoutOptions.StartAndExpand
							},
							new StackLayout
							{
								Orientation = StackOrientation.Horizontal,
								HorizontalOptions = LayoutOptions.StartAndExpand,
								VerticalOptions = LayoutOptions.CenterAndExpand,
								Padding = new Thickness (10, 10,10,0),
								Spacing = 15,

								Children =
								{

							blueButtonAdd,

							blueLabel,

							blueButtonMinus


								}
							},

							warnBlueLabel
				}
			};

			outerStack.Children.Add(blueLayout);

			StackLayout RGBLayout = new StackLayout
			{
				Children =
				{
					new Label
							{
								Text = "Current Color Composition",
								FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
								VerticalOptions = LayoutOptions.Center,
								HorizontalOptions = LayoutOptions.StartAndExpand
							},
							new StackLayout
							{
								Orientation = StackOrientation.Horizontal,
								HorizontalOptions = LayoutOptions.StartAndExpand,
								VerticalOptions = LayoutOptions.CenterAndExpand,
								Padding = new Thickness (10, 10,10,0),
								Spacing = 15,

								Children =
								{

							currentBoxView,

							new StackLayout
									{
										Children =

										{
											RGBLabel,
											HSLLabel,
										}
									}
								}
							}
				}
			};

			outerStack.Children.Add(RGBLayout);

			Content = new ScrollView
			{
				Content = outerStack
			};

		}

		void onButtonClicked(object sender, EventArgs args)
		{
			Button button = (Button)sender;

			if (button == redButtonAdd)
			{

				if (redCompositon > 255)
				{
					warnRedLabel.Text = "Maximum Red Range is 255!";
					redButtonAdd.IsEnabled = false;

				}
				else
				{
					redCompositon += 1;
					redLabel.Text = String.Format("{0}", redCompositon);
					warnRedLabel.Text = " ";
					redButtonMinus.IsEnabled = true;
				}


			}
			else if (button == redButtonMinus)
			{


				if (redCompositon == 0)
				{
					warnRedLabel.Text = "Minimum Red Range 0!";
					redButtonMinus.IsEnabled = false;
				}
				else {
					redCompositon -= 1;
					redLabel.Text = String.Format("{0}", redCompositon);
					warnRedLabel.Text = " ";
					redButtonAdd.IsEnabled = true;

				}


			}
			else if (button == greenButtonAdd)
			{

				if (greenCompositon == 255)
				{
					warnGreenLabel.Text = "Maximum Green Range is 255!";
					greenButtonAdd.IsEnabled = false;

				}
				else
				{
					greenCompositon += 1;
					greenLabel.Text = String.Format("{0}", greenCompositon);
					warnGreenLabel.Text = " ";
					greenButtonMinus.IsEnabled = true;

				}

			}
			else if (button == greenButtonMinus)
			{


				if (greenCompositon == 0)
				{
					warnGreenLabel.Text = "Minimum Green Range is 0!";
					greenButtonMinus.IsEnabled = false;

				}
				else
				{
					greenCompositon -= 1;
					greenLabel.Text = String.Format("{0}", greenCompositon);
					warnGreenLabel.Text = " ";
					greenButtonAdd.IsEnabled = true;

				}

			}
			else if (button == blueButtonAdd)
			{

				if (blueCompositon == 255)
				{
					warnBlueLabel.Text = "Maximum Blue Range is 255!";
					blueButtonAdd.IsEnabled = false;

				}
				else
				{
					blueCompositon += 1;
					blueLabel.Text = String.Format("{0}", blueCompositon);
					warnBlueLabel.Text = " ";
					blueButtonMinus.IsEnabled = true;
				}


			}
			else if (button == blueButtonMinus)
			{

				if (blueCompositon == 0)
				{
					warnBlueLabel.Text = "Minimum Blue Range is 0!";
					blueButtonMinus.IsEnabled = false;

				}
				else
				{
					blueCompositon -= 1;
					blueLabel.Text = String.Format("{0}", blueCompositon);
					warnBlueLabel.Text = " ";
					blueButtonAdd.IsEnabled = true;

				}
			}

			app.RedComposition = redCompositon;
			app.GreenComposition = greenCompositon;
			app.BlueComposition = blueCompositon;

			currentBoxView.Color = Color.FromRgb(redCompositon, greenCompositon, blueCompositon);

			RGBLabel.Text = RGBLabelMaker(redCompositon, greenCompositon, blueCompositon);

			HSLLabel.Text = HSLLabelMaker(redCompositon, greenCompositon, blueCompositon);


		}




		public String RGBLabelMaker(int redComposition, int greenCompositon, int blueCompositon)
		{


			currentColor = Color.FromRgb(redCompositon, greenCompositon, blueCompositon);


			RGBLabel.Text = "RGB Value:- " + String.Format("{0:X2}-{1:X2}-{2:X2}",
														 (int)(255 * currentColor.R),
														 (int)(255 * currentColor.G),
													   (int)(255 * currentColor.B));
			return RGBLabel.Text;


		}



		public String HSLLabelMaker(int redComposition, int greenCompositon, int blueCompositon)
		{


			currentColor = Color.FromRgb(redCompositon, greenCompositon, blueCompositon);


			HSLLabel.Text = "HSL Value:- " + String.Format("{0:F2}, {1:F2}, {2:F2}",
														 currentColor.Hue,
														 currentColor.Saturation,
														 currentColor.Luminosity);
			return HSLLabel.Text;


		}


	}
}
