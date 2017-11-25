using System;
using System.IO;
using Xamarin.Forms;
using DynamicPhotoFrame.Droid;

[assembly: Dependency(typeof(SaveAndLoad))]
namespace DynamicPhotoFrame.Droid
{
	//Device specific function for save file
	public class SaveAndLoad : ISaveAndLoad
	{
		public void SaveText(string filename, string text)
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var filePath = Path.Combine(documentsPath, filename);
			System.IO.File.WriteAllText(filePath, text);
		}

		//Device specific for load file
		public string LoadText(string filename)
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var filePath = Path.Combine(documentsPath, filename);
			return System.IO.File.ReadAllText(filePath);
		}

		//Device specific check if file exists
		public bool IfExists(string filename)
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var filePath = Path.Combine(documentsPath, filename);
			return (System.IO.File.Exists(filePath));
		}


	}
}
