using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace DynamicPhotoFrame
{

	//Class for retrieving information from xml
	public class ImageViewModel : ViewModelBase
	{

		ImageBody imageBody;

		public ImageViewModel() : this(null)
		{
		}


		public ImageViewModel(IDictionary<string, object> properties)
		{
			// Avoid problems with a null or empty collection.
			ImageBody = new ImageBody();
			ImageBody.Images.Add(new Image());

			//Check to see if file exists
			bool r = DependencyService.Get<ISaveAndLoad>().IfExists("visaPJ3.xml");
			if (r)
			{
				String serializedStr = DependencyService.Get<ISaveAndLoad>().LoadText("visaPJ3.xml");
				using (TextReader reader = new StringReader(serializedStr))
				{
					XmlSerializer serializer = new XmlSerializer(typeof(ImageBody));
					ImageBody = (ImageBody)serializer.Deserialize(reader);
				}
			}
			else {

				//Load from default xml on start of application
			    var assembly = typeof(ImageViewModel).GetTypeInfo().Assembly;
				Stream stream = assembly.GetManifestResourceStream("DynamicPhotoFrame.ImageList.xml");

				StreamReader reader = new StreamReader(stream);
				XmlSerializer xml = new XmlSerializer(typeof(ImageBody));
				ImageBody = xml.Deserialize(reader) as ImageBody;
				stream.Dispose();
			}

			int imageCount = 1;

			foreach (Image i in ImageBody.Images)
			{
				i.ImageBody = ImageBody;
				int item_type = Int32.Parse(i.Type);
				switch (item_type)
				{
					case 1:
						i.ImgSource = ImageSource.FromUri(new Uri(i.ImageFileName));
						break;
					case 2:
						i.ImgSource = ImageSource.FromFile(i.ImageFileName);
						break;
					case 3:
						i.ImgSource = ImageSource.FromResource(i.ImageFileName);
						break;
					case 4:
						String streamId = i.ImageFileName;
						i.ImgSource = ImageSource.FromStream(() =>
						{
							Assembly a = GetType().GetTypeInfo().Assembly;
							Stream s = a.GetManifestResourceStream(streamId);
							return s;
						});
						break;
					default:
						i.ImgSource = i.ImageFileName;
						break;
				}
				imageCount++;
			}
		}


		public ImageBody ImageBody
		{
			protected set { SetProperty(ref imageBody, value); }
			get { return imageBody; }
		}
	} }  
