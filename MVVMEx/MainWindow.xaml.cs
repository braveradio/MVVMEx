using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVMEx
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            //DataContext = new ViewModel();
        }

        #region without vm
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
				return new RelayCommand((obj =>
				{
					Clicks++;
				}));
			}
		}


		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}

		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

	}
}
