using System;

using Xamarin.Forms;

namespace SimplePalette
{
	public class MainPage : ContentPage
	{


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

		private double width = 0;
		private double height = 0;




		public MainPage()
		{
			Padding = new Thickness(5, Device.OnPlatform(20, 0, 0), 5, 5);

			Label title = new Label
			{
				Text = "Choose RGB Composition",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};

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

			HSLLabel = new Label
			{

				VerticalOptions = LayoutOptions.CenterAndExpand,
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
			};

			RGBLabel = new Label
			{

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
			redButtonAdd.Clicked += redCompButtonClicked;



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
			redButtonMinus.Clicked += redCompButtonClicked;

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
			greenButtonAdd.Clicked += greenCompButtonClicked;



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

			greenButtonMinus.Clicked += greenCompButtonClicked;

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
			blueButtonAdd.Clicked += blueCompButtonClicked;

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
			blueButtonMinus.Clicked += blueCompButtonClicked;

			currentBoxView = new BoxView
			{
				Color = Color.FromRgb(redCompositon, greenCompositon, blueCompositon),
				WidthRequest = 75,
				HeightRequest = 75,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			Content = new StackLayout
			{
				Children = {

					title,

					new StackLayout
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

							warnRedLabel,

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

							warnGreenLabel,

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

							warnBlueLabel,

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


					}

				}

			};


		}

		void redCompButtonClicked(object sender, EventArgs args)
		{
			Button button = (Button)sender;

			if (button == redButtonAdd)
			{

				if (redCompositon == 255)
				{
					warnRedLabel.Text = "Maximum Red Range is 255!";
					redLabel.Text = String.Format("{0}", redCompositon);
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
					redLabel.Text = String.Format("{0}", redCompositon);
					redButtonMinus.IsEnabled = false;

				}
				else {
					redCompositon -= 1;
					redLabel.Text = String.Format("{0}", redCompositon);
					warnRedLabel.Text = " ";
					redButtonAdd.IsEnabled = true;

				}


			}

			currentBoxView.Color = Color.FromRgb(redCompositon, greenCompositon, blueCompositon);

			currentColor = Color.FromRgb(redCompositon, greenCompositon, blueCompositon);

			RGBLabel.Text = "RGB Value:- " + String.Format("{0:X2}-{1:X2}-{2:X2}",
														 (int)(255 * currentColor.R),
														 (int)(255 * currentColor.G),
										               (int)(255 * currentColor.B));
			
			HSLLabel.Text = "HSL Value:- " + String.Format("{0:F2}, {1:F2}, {2:F2}",
														 currentColor.Hue,
														 currentColor.Saturation,
														   currentColor.Luminosity);


		}

		void greenCompButtonClicked(object sender, EventArgs args)
		{
			Button buttonGreen = (Button)sender;

			if (buttonGreen == greenButtonAdd)
			{

				if (greenCompositon == 255)
				{
					warnGreenLabel.Text = "Maximum Green Range is 255!";
					greenButtonAdd.IsEnabled = false;

				}
				else 
				{
					greenCompositon += 1;
					warnGreenLabel.Text = " ";
					greenButtonMinus.IsEnabled = true;
					
				}


			}
			else if (buttonGreen == greenButtonMinus)
			{


				if (greenCompositon == 0)
				{
					warnGreenLabel.Text = "Minimum Green Range is 0!";
					greenButtonMinus.IsEnabled = false;

				}
				else 
				{
					greenCompositon -= 1;
					warnGreenLabel.Text = " ";
					greenButtonAdd.IsEnabled = true;

				}


			}

			currentBoxView.Color = Color.FromRgb(redCompositon, greenCompositon, blueCompositon);

			currentColor = Color.FromRgb(redCompositon, greenCompositon, blueCompositon);

			RGBLabel.Text = "RGB Value:- " + String.Format("{0:X2}-{1:X2}-{2:X2}",
														 (int)(255 * currentColor.R),
														 (int)(255 * currentColor.G),
													   (int)(255 * currentColor.B));

			HSLLabel.Text = "HSL Value:- " + String.Format("{0:F2}, {1:F2}, {2:F2}",
														 currentColor.Hue,
														 currentColor.Saturation,
														   currentColor.Luminosity);

		}

		void blueCompButtonClicked(object sender, EventArgs args)
		{
			Button buttonBlue = (Button)sender;

			if (buttonBlue == blueButtonAdd)
			{

				if (blueCompositon == 255)
				{
					warnBlueLabel.Text = "Maximum Blue Range is 255!";

					blueButtonAdd.IsEnabled = false;

				}
				else 
				{
					blueCompositon += 1;

					warnBlueLabel.Text = " ";
					blueButtonMinus.IsEnabled = true;
				}


			}
			else if (buttonBlue == blueButtonMinus)
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

			currentBoxView.Color = Color.FromRgb(redCompositon, greenCompositon, blueCompositon);

			currentColor = Color.FromRgb(redCompositon, greenCompositon, blueCompositon);

			RGBLabel.Text = "RGB Value:- " + String.Format("{0:X2}-{1:X2}-{2:X2}",
														 (int)(255 * currentColor.R),
														 (int)(255 * currentColor.G),
													   (int)(255 * currentColor.B));

			HSLLabel.Text = "HSL Value:- " + String.Format("{0:F2}, {1:F2}, {2:F2}",
														 currentColor.Hue,
														 currentColor.Saturation,
														 currentColor.Luminosity);

		}


		protected override void OnSizeAllocated(double width, double height)
		{
			base.OnSizeAllocated(width, height);
			if (width != this.width || height != this.height)
			{
				this.width = width;
				this.height = height;
				System.Diagnostics.Debug.WriteLine("hello");
			}
		}


	}

}

