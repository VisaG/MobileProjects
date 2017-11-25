using System;
using System.IO;
using Xamarin.Forms;
using DynamicPhotoFrame.iOS;

[assembly: Dependency(typeof(SaveAndLoad))]
namespace DynamicPhotoFrame.iOS
{
	public class SaveAndLoad : ISaveAndLoad
	{
		//Device specific save
		public void SaveText(string filename, string text)
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var filePath = Path.Combine(documentsPath, filename);
			System.IO.File.WriteAllText(filePath, text);
		}

		//Device specific load
		public string LoadText(string filename)
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var filePath = Path.Combine(documentsPath, filename);
			return System.IO.File.ReadAllText(filePath);
		}

		//To chk if file exists
		public bool IfExists(string filename)
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var filePath = Path.Combine(documentsPath, filename);
			return (System.IO.File.Exists(filePath));
		}


	}
}
