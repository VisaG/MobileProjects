using System;

using System.ComponentModel;

using System.Runtime.CompilerServices;



namespace DynamicPhotoFrame
{
	//INotifyPropertyChange for binding context set for Main Photo Page
	public class MainPhotoModel : INotifyPropertyChanged
	{

		public decimal _timeSet;


		public decimal Timeset
		{
			get
			{
				_timeSet = Convert.ToInt32(_timeSet);
				return _timeSet;
			}
			set
			{
				if (_timeSet != value)
				{

					_timeSet = value;
					_timeSet = Convert.ToInt32(_timeSet);

					RaisePropertyChanged();

				}
			}


		}


		//Ensure that the timeINterval is between valid ranges
		public event PropertyChangedEventHandler PropertyChanged = delegate { };

		public void RaisePropertyChanged([CallerMemberName] string propName = "")
		{
			if (!string.IsNullOrEmpty(propName) && (_timeSet >= 1 || _timeSet <= 60))
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propName));


			}


		}


	}




}
