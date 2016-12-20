using System;
using System.Collections.Generic;
using System.Linq;
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

namespace mysqldatabase
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	
	
	public partial class MainWindow : Window
	{
		// Load data base
		TestDatabase ddbb = null;

		public MainWindow()
		{
			InitializeComponent();

			// Load data base
			ddbb = TestDatabase.instance;
		}

		private void enter_Click(object sender, RoutedEventArgs e)
		{
			User user = ddbb.checkUser(textLogin.Text, textPass.Password);
			if(user == null)
			{
				// NOT IN DATABASE or PASSWORD INCORRECT
				Console.WriteLine("ERROR!!!!");
			}
			else
			{
				Console.WriteLine("Bienvenido " + user.name);
			}
		}

		private void Window_Closed(object sender, EventArgs e)
		{
			ddbb.close();
		}
	}
}
