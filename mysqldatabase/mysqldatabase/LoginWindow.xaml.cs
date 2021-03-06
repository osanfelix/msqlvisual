﻿using System;
using System.Windows;


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
				MessageBox.Show("Error! El usuario o la contraseña es incorrecto!!!!");
			}
			else
			{
				MessageBox.Show("Bienvenido " + user.name);
				Application.Current.Shutdown();
			}
		}

		private void Window_Closed(object sender, EventArgs e)
		{
			ddbb.close();
		}

		private void add_Click(object sender, RoutedEventArgs e)
		{
			new AddUser().Show();

		}
	}
}
