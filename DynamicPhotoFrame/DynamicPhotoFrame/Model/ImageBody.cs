using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;


namespace DynamicPhotoFrame
{

	public class ImageBody : ViewModelBase
	{
		App app = Application.Current as App;
		ObservableCollection<Image> images = new ObservableCollection<Image>();

		public ObservableCollection<Image> Images
		{
			set { SetProperty(ref images, value); }
			get { return images; }
		}

		public void MoveImageUp(Image image)
		{
			if (Images.IndexOf(image) > 0)
			{
				Images.Move(Images.IndexOf(image), (Images.IndexOf(image) - 1));
				string s = ConversionExt.SerializeObject(this);
				ConversionExt.Commit("visaPJ3.xml", s);
				app.RefreshImage = 1;
			}
		}

		public void MoveImageDown(Image image)
		{
			if ((Images.IndexOf(image) != (Images.Count - 1)))
			{
				Images.Move(Images.IndexOf(image), (Images.IndexOf(image) + 1));
				string s = ConversionExt.SerializeObject(this);
				ConversionExt.Commit("visaPJ3.xml", s);
				app.RefreshImage = 1;
			}

		}

		public void ImageViewCommand(Image image)
		{
			Application.Current.MainPage.Navigation.PushModalAsync(new ImageDetailPage(image));
		}

		public void ImageRemoveCommand(Image image)
		{
			Images.Remove(image);
			string s = ConversionExt.SerializeObject(this);
			ConversionExt.Commit("visaPJ3.xml", s);
			app.RefreshImage = 1;
		}

	} } 
