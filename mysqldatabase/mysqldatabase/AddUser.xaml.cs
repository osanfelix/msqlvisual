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
using System.Windows.Shapes;

namespace mysqldatabase
{
	/// <summary>
	/// Interaction logic for AddUser.xaml
	/// </summary>
	public partial class AddUser : Window
	{
		public AddUser()
		{
			InitializeComponent();
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			TestDatabase ddbb = TestDatabase.instance;

			// Check texts
			if(textName.Text.Length == 0 || passwordBox.Password.Length == 0)
			{
				MessageBox.Show("Rellena el nombre y/o contraseña");
			}
			else
			{
				if (!ddbb.addUser(new User(textName.Text, passwordBox.Password)))
				{

					MessageBox.Show("Error! El usuario " + textName.Text + " ya existe");
				}
				else
				{
					MessageBox.Show("Usuario " + textName.Text + " dado de alta correctamente");
					Close();
				}
			}
		}
	}
}
