using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace PHolaMySql
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string connectionString =
				"Server=localhost;" +
				"Database=dbprueba;" +
				"User ID=root;" +
				"Password=sistemas";

			MySqlConnection mySqlConnection = new MySqlConnection (connectionString);

			mySqlConnection.Open ();
			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();

			/*mySqlCommand.CommandText = 
				string.Format("INSERT into categoria (nombre) value ('{0}')",DateTime.Now);
			mySqlCommand.ExecuteNonQuery ();*/
			//String reader="";
			mySqlCommand.CommandText = "SELECT * FROM categoria ";
			MySqlDataReader reader =mySqlCommand.ExecuteReader();

			Console.WriteLine ("FielCount = {0}", reader.FieldCount);

			for (int i=0; i<reader.FieldCount; i++) {
				Console.WriteLine(reader.GetName(i));
			}

			while(reader.Read()) {
				string FirstName = (string) reader["nombre"];
				object LastName = reader["id"];
				Console.WriteLine("Name: " +FirstName + " ID: " + LastName);
			}

			//Console.WriteLine (reader);
			reader.Close ();
			mySqlConnection.Close ();
			/*Menu m =*/ new Menu();
			//m.Menu();

		}
	}
}
