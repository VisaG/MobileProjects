using System;
using System.Windows.Input;
using System.Xml.Serialization; using Xamarin.Forms;

namespace DynamicPhotoFrame
{
	public class Image : ViewModelBase
	{
		string title, detail, date, imageFileName, type;
		ImageSource imgSource;

		public Image()
		{
			MoveUpCommand = new Command(() => ImageBody.MoveImageUp(this));
			MoveDownCommand = new Command(() => ImageBody.MoveImageDown(this));
			ViewCommand = new Command(() => ImageBody.ImageViewCommand(this));
			RemoveCommand = new Command(() => ImageBody.ImageRemoveCommand(this));
		}

		public string Title
		{
			set { SetProperty(ref title, value); }
			get { return title; }
		}

		public string Detail
		{
			set { SetProperty(ref detail, value); }
			get { return detail; }
		}

		public string Date
		{
			set { SetProperty(ref date, value); }
			get { return date; }
		}

		public string ImageFileName
		{
			set { SetProperty(ref imageFileName, value); }
			get { return imageFileName; }
		}

		public String Type
		{
			set { SetProperty(ref type, value); }
			get { return type; }
		}

		[XmlIgnore]
		public ImageSource ImgSource
		{
			set { SetProperty(ref imgSource, value); }
			get { return imgSource; }
		}

	 
		[XmlIgnore]
		public ICommand MoveUpCommand { private set; get; }

		[XmlIgnore]
		public ICommand MoveDownCommand { private set; get; }

		[XmlIgnore]
		public ICommand ViewCommand { private set; get; }

		[XmlIgnore]
		public ICommand RemoveCommand { private set; get; }

		[XmlIgnore]
		public ImageBody ImageBody { set; get; }
	}

}

