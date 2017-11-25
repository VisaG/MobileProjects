using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace DynamicPhotoFrame
{
	//Interaface for device specific class to save and load file
	public interface ISaveAndLoad
	{
		void SaveText(string filename, string text);
		string LoadText(string filename);
		bool IfExists(string filename);
	}
}
