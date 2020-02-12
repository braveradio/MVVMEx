using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMEx
{
    class ViewModel : INotifyPropertyChanged
    {

		private int _Clicks;
		public int Clicks
		{
			get { return _Clicks; }
			set
			{
				_Clicks = value;
				OnPropertyChanged();
			}
		}

		public ViewModel()
		{
			//var person = new Person() { Name = "Joe" };
		}

		private Person _person = new Person() { Name = "Man" };
		public Person person 
		{
			get { return _person; }
			set
			{
				_person = value;
				//OnPropertyChanged();
			} 
		} 

        #region ctor
  //      public ViewModel()
		//{
		//	Task.Factory.StartNew(() =>
		//	{
		//		while (true)
		//		{
		//			Task.Delay(1000).Wait();

		//			Clicks++;
		//		}
		//	});
		//}
        #endregion

		public ICommand ClickAdd
		{
			get
			{
				return new RelayCommand((obj) => 
				{
					//_person.Name = $"{new Random().Next(1, 5)}";
					_person.Name = $"Man {new Random().Next(1, 5)}";
				});
			}
		}


        public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}

		public event PropertyChangedEventHandler PropertyChanged;
    }
}
