using System;
using System.IO;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace DynamicPhotoFrame
{
	//Read and commit changes
	public static class ConversionExt
	{
		public static string SerializeObject<T>(this T toSerialize)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			StringWriter textWriter = new StringWriter();
			xmlSerializer.Serialize(textWriter, toSerialize);
			return textWriter.ToString();
		}

		async public static void Commit(string path, string s)
		{
			DependencyService.Get<ISaveAndLoad>().SaveText(path, s);
		}

	}
}
