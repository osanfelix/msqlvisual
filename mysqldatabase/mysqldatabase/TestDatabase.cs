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
			connStr = "server=internetserver.no-ip.org;user=admin;database=test;port=3306;password=admintest;";
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
			try
			{
				string sql = "iNSERT INTO user (name, password) VALUES (@nombre, @pass)";
				MySqlCommand cmd = new MySqlCommand(sql, connection);
				cmd.Parameters.AddWithValue("@nombre", newUser.name);
				cmd.Parameters.AddWithValue("@pass", newUser.pass);
				cmd.ExecuteNonQuery();

				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
				return false;
				
			}
		}

		public User checkUser(string username, string password)
		{
			// If user exists returns user from database
			// TODO
			string sql = "SELECT * from user WHERE name = @name";
			MySqlCommand cmd = new MySqlCommand(sql, connection);
			cmd.Parameters.AddWithValue("@name", username);
			MySqlDataReader rdr = cmd.ExecuteReader();
			if (rdr.Read())
			{
				User dataUser = new User((string)rdr["name"], (string)rdr["pass"]);
				rdr.Close();
				return dataUser.checkPassword(password) ? dataUser : null;
			}
			rdr.Close();
			return null;
		}

		public void close()
		{
			connection.Close();
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
		String _name;
		String _pass;	// MD5 password

		public User(string name, string pass)
		{
			_name = name;
			_pass = pass;   // TODO MD5 HASH
		}

		public string name {get{return _name;}}
		public string pass { get { return _pass; } }

		public bool save()
		{
			// TODO
			TestDatabase.instance.addUser(this);
			return true;
		}
		public bool checkPassword(string plainPass)
		{
			return plainPass == _pass;
		}
	}
}
