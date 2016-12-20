using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace mysqldatabase
{
	class TestDatabase
	{
		// Singletone
		protected static TestDatabase _instance = null;

		public static TestDatabase instance
		{
			get
			{
				if (_instance == null)
					_instance = new TestDatabase();
				return _instance;
			}
		}

		// ATTRIBUTES
		protected string connStr;
		protected MySqlConnection connection = null;
		protected string serverName = null;
		protected string serverUser = null;
		protected uint serverPort = 3306;

		protected TestDatabase()
		{
			// Create connection to MySql database
			connStr = "server=10.0.0.7;user=admin;database=test;port=3306;password=admintest;";
			connection = new MySqlConnection(connStr);
			try
			{
				Console.WriteLine("Connecting to MySQL...");
				connection.Open();
				// Perform database operations
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			connection.Close();
			Console.WriteLine("Done.");
		}

		public IList<User> getUsers()
		{
			// TODO
			return null;
		}

		public bool addUser(User newUser)
		{
			// TODO
			return false;
		}

		public User checkPass(string username, string password)
		{
			// If user exists returns user from database
			// TODO
			return null;
		}

		// INTERNAL METHODS
		protected User getUser(string username)
		{
			// If user exists returns user from database
			// TODO
			return null;
		}


	}

	public class User
	{
		String name;
		String pass;	// MD5 password
	}
}
