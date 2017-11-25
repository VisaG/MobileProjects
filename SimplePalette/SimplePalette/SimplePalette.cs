/**
 * The program below provides a simulation of Simple Palette. 
 * The project is implemented using cross platform mobile app with Xamarin.Forms (Portable)
 * and runs on two different platform emulators : iPhone and Andriod.
 * 
 * The program implements the following: - 
 * 
 * - Display 3 indepenedent buttons to increment red, green and blue value by 1 
 * - Display 3 independent buttons to decrement red, blue and green value by 1 
 * - Display current color element value as label
 * - Disaply Current color composition as boxView 
 * - and will reflect current values of red, blue and green color 
 * - Display Current RGB values as HEX and HSL values as double 
 * - Disable button if color value = 0 or value = 255
 * - Display warning Label if color value = 0 or value = 255
 * - Single method onClickedButton() will manupilate the state and the data of 
 * - all six buttons.
 * 
 * 
 * @author Visalakshi Gopalakrishnan Student Id - 00000976426.
 * 
 *         Project 1 : Simple Palette, COEN 268 - WINTER 2017
 */


using System;

using Xamarin.Forms;

namespace SimplePalette
{
	public class SimplePalette : ContentPage

	{

		StackLayout outerStack = new StackLayout();


		//Provide shared access to the Application instance for the current AppDomain
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



		public SimplePalette()
		{
			//Overall padding 
			Padding = new Thickness(5, Device.OnPlatform(20, 0, 0), 5, 5);

			//Save transicient data by loading previous color value
			redCompositon = app.RedComposition;
			greenCompositon = app.GreenComposition;
			blueCompositon = app.BlueComposition;

			//Display current color composition on start of application
			currentColor = Color.FromRgb(redCompositon, greenCompositon, blueCompositon);


			//Label to store color value
			redLabel = new Label
			{
				Text = redCompositon.ToString(),
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			//Label to store color value
			greenLabel = new Label
			{
				Text = greenCompositon.ToString(),
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			//Label to store color value
			blueLabel = new Label
			{
				Text = blueCompositon.ToString(),
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			//Warning label if value of red = 0 or 255
			warnRedLabel = new Label
			{
				Text = " ",
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				TextColor = Color.Red

			};

			//Warning label if value of green = 0 or 255
			warnGreenLabel = new Label
			{
				Text = " ",
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				TextColor = Color.Red
			};

			//Warning label if value of blue = 0 or 255
			warnBlueLabel = new Label
			{
				Text = " ",
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				TextColor = Color.Red
			};

			//Display HSL value on start of application
			HSLLabel = new Label()
			{
				Text = "HSL Value:- " + String.Format("{0:F2}, {1:F2}, {2:F2}",
														 currentColor.Hue,
														 currentColor.Saturation,
														   currentColor.Luminosity),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
			};

			//Display RGB value on start of application
			RGBLabel = new Label()
			{
				Text = "RGB Value:- " + String.Format("{0:X2}-{1:X2}-{2:X2}",
														 (int)(255 * currentColor.R),
														 (int)(255 * currentColor.G),
													   (int)(255 * currentColor.B)),

				VerticalOptions = LayoutOptions.CenterAndExpand,
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
			};


			//Button to increment color value
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

			//Method to trigger button event
			redButtonAdd.Clicked += onButtonClicked;

			//Button to decrement color value
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

			//Method to trigger button event
			redButtonMinus.Clicked += onButtonClicked;

			//Button to increment color value
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

			//Method to trigger button event
			greenButtonAdd.Clicked += onButtonClicked;


			//Button to decrement color value
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

			//Method to trigger button event
			greenButtonMinus.Clicked += onButtonClicked;


			//Button to increment color value
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

			//Method to trigger button event
			blueButtonAdd.Clicked += onButtonClicked;

			//Button to decrement color value
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

			//Method to trigger button event
			blueButtonMinus.Clicked += onButtonClicked;

			//BoxView to display current color composition based on RGB values selected
			currentBoxView = new BoxView
			{
				Color = Color.FromRgb(redCompositon, greenCompositon, blueCompositon),
				WidthRequest = 75,
				HeightRequest = 75,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			//Header as label
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

			//Add title as first child of the main outerStack
			outerStack.Children.Add(title);

			//Arrange buttons, label and warninglabel in redLayout
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
							
							// Horizontal alignment of buttons and label in Stacklayout
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

			//Add redLayout as child of the main outerStack
			outerStack.Children.Add(redLayout);


			//Arrange buttons, label and warninglabel in greenLayout
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
							
							// Horizontal alignment of buttons and label in Stacklayout
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

			//Add greenLayout as child of the main outerStack
			outerStack.Children.Add(greenLayout);

			//Arrange buttons, label and warninglabel in blueLayout
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

							// Horizontal alignment of buttons and label in Stacklayout
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

			//Add blueLayout as child of the main outerStack
			outerStack.Children.Add(blueLayout);

			//Arrange current color BoxView, RGB label and HSL label
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

							// Horizontal alignment of BoxView and labels in Stacklayout
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

			//Add RGBLayout as child of the main outerStack
			outerStack.Children.Add(RGBLayout);

			Content = new ScrollView
			{
				Content = outerStack
			};

		}



		//Method to trigger button event
		void onButtonClicked(object sender, EventArgs args)
		{
			Button button = (Button)sender;

			//Increment/Decrement color value
			addRange(button);

			//Enable buttons if the color value in range
			buttonEnableTrue();

			//Disable button if color value = 0 or 255
			buttonEnableFalse();

			//Add color value to label
			redLabel.Text = String.Format("{0}", redCompositon);
			greenLabel.Text = String.Format("{0}", greenCompositon);
			blueLabel.Text = String.Format("{0}", blueCompositon);

			//Method to set warning if value range = 0 or 255 
			setWarningLabel();

			//Save color value when application goes to sleep
			app.RedComposition = redCompositon;
			app.GreenComposition = greenCompositon;
			app.BlueComposition = blueCompositon;

			//Disaply current color composition
			currentBoxView.Color = Color.FromRgb(redCompositon, greenCompositon, blueCompositon);

			//Disaply RGB Hex value of current color
			RGBLabelMaker(currentBoxView.Color);

			//Display HSL value of current color
			HSLLabelMaker(currentBoxView.Color);


		}



		//Increment/decrement color value based on button click
		public void addRange(Button button)
		{
			if (button == redButtonAdd) { redCompositon += 1; }
			if (button == redButtonMinus) { redCompositon -= 1; }
			if (button == greenButtonAdd) { greenCompositon += 1; }
			if (button == greenButtonMinus) { greenCompositon -= 1; }
			if (button == blueButtonAdd) { blueCompositon += 1; }
			if (button == blueButtonMinus) { blueCompositon -= 1; }
		}


		//Enable button if color value is in range 
		public void buttonEnableTrue()
		{
			redButtonAdd.IsEnabled = true;
			redButtonMinus.IsEnabled = true;
			greenButtonAdd.IsEnabled = true;
			greenButtonMinus.IsEnabled = true;
			blueButtonAdd.IsEnabled = true;
			blueButtonMinus.IsEnabled = true;
		}

		//Disable button if color value = 0 or value = 255
		public void buttonEnableFalse()
		{
			if (redCompositon == 255) { redButtonAdd.IsEnabled = false; }
			if (redCompositon == 0) { redButtonMinus.IsEnabled = false; }
			if (greenCompositon == 255) { greenButtonAdd.IsEnabled = false; }
			if (greenCompositon == 0) { greenButtonMinus.IsEnabled = false; }
			if (blueCompositon == 255) { blueButtonAdd.IsEnabled = false; }
			if (blueCompositon == 0) { blueButtonMinus.IsEnabled = false; }

		}


		//Display warning as label if color value = 0 or value = 255
		public void setWarningLabel()
		{
			//Check red color range
			if (redCompositon == 255) { warnRedLabel.Text = "Maximum Red Range is 255!"; }
			else if (redCompositon == 0) { warnRedLabel.Text = "Minimum Red Range is 0!"; }
			else { warnRedLabel.Text = " "; } // no woarning if color value in range

			//Check green color range
			if (greenCompositon == 255) { warnGreenLabel.Text = "Maximum Green Range is 255!"; }
			else if (greenCompositon == 0) { warnGreenLabel.Text = "Minimum Green Range is 0!"; }
			else { warnGreenLabel.Text = " "; } // no woarning if color value in range

			//Check blue color range
			if (blueCompositon == 255) { warnBlueLabel.Text = "Maximum Blue Range is 255!"; }
			else if (blueCompositon == 0) { warnBlueLabel.Text = "Minimum Blue Range is 0!"; }
			else { warnBlueLabel.Text = " "; } // no woarning if color value in range

		}




		//Set and Display RGB Hex value of current color
		public void RGBLabelMaker(Color currentColor)
		{

			RGBLabel.Text = "RGB Value:- " + String.Format("{0:X2}-{1:X2}-{2:X2}",
														 (int)(255 * currentColor.R),
														 (int)(255 * currentColor.G),
													   (int)(255 * currentColor.B));

		}


		//Set and Display HSL value of current color
		public void HSLLabelMaker(Color currentColor)
		{

			HSLLabel.Text = "HSL Value:- " + String.Format("{0:F2}, {1:F2}, {2:F2}",
														 currentColor.Hue,
														 currentColor.Saturation,
														 currentColor.Luminosity);
		}


	}
}
