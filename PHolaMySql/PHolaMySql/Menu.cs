using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace PHolaMySql
{
	public class Menu
	{
		public Menu (){
			string connectionString =
				"Server=localhost;" +
					"Database=dbprueba;" +
					"User ID=root;" +
					"Password=sistemas";

			MySqlConnection mySqlConnection = new MySqlConnection (connectionString);
			mySqlConnection.Open ();
			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
			String opcion;
			do {
				Console.WriteLine ("");
				Console.WriteLine ("------------------------------------");
				Console.WriteLine ("Menu Base de Datos , selecione una opcion");
				Console.WriteLine ("------------------------------------");
				Console.WriteLine ("1 - Nueva insercion");
				Console.WriteLine ("2 - Modificar linea");
				Console.WriteLine ("3 - Eliminar linea");
				Console.WriteLine ("4 - Ver tabla");
				Console.WriteLine ("0 - Salir");

				opcion = Console.ReadLine ();
				string nombre, resultado, id;
				switch (opcion) {
				case "1":
				//Console.WriteLine ("Opcion 1 seleccionada"); 
					Console.WriteLine ("Inserte nuevo nombre");
					nombre = Console.ReadLine ();
					resultado = InsertarLinea (nombre, mySqlCommand);
					Console.WriteLine (resultado);
					break;
				case "2":
					Console.WriteLine ("Indique el id del nombre que desea editar");
					id = Console.ReadLine ();
					Console.WriteLine ("Inserte el nuevo nombre");
					nombre = Console.ReadLine ();
					resultado = EditarLinea (nombre, id, mySqlCommand);
					Console.WriteLine (resultado);
					break;
				case "3":
					Console.WriteLine ("Indique el id de la linea que desea eliminar"); 
					id = Console.ReadLine ();
					resultado = EliminarLinea (id, mySqlCommand);
					Console.WriteLine (resultado);
					break;
				case "4":
					Console.WriteLine ("Tabla 'Categoria' :");
					VerTabla (mySqlCommand);

					break;
				case "0":
					Console.WriteLine ("Adios!"); 

					break;
				}
			} while(opcion!="0");

			mySqlConnection.Close ();

		}

		public string InsertarLinea (string nombre,MySqlCommand mySqlCommand){
			Console.WriteLine ("Insertando nueva linea");

			mySqlCommand.CommandText = string.Format("INSERT into categoria (nombre) value ('{0}')",nombre);
			int resul = mySqlCommand.ExecuteNonQuery ();
			if (resul==1) {
				return "Operacion Realizada con exito!";
			} else {
				return "Algo ha fallado";
			}


		}

		public string EditarLinea (string nombre,string id,MySqlCommand mySqlCommand){
			Console.WriteLine ("Insertando nueva linea");

			mySqlCommand.CommandText = string.Format("UPDATE categoria SET nombre= ('{0}') WHERE id=('{1}')",nombre,id);
			int resul = mySqlCommand.ExecuteNonQuery ();
			if (resul==1) {
				return "Operacion Realizada con exito!";
			} else {
				return "Algo ha fallado";
			}


		}
		public string EliminarLinea (string id,MySqlCommand mySqlCommand){
			Console.WriteLine ("Insertando nueva linea");

			mySqlCommand.CommandText = string.Format("DELETE FROM `categoria` WHERE id=('{0}')",id);
			int resul = mySqlCommand.ExecuteNonQuery ();
			if (resul==1) {
				return "Operacion Realizada con exito!";
			} else {
				return "Algo ha fallado";
			}


		}
		public string VerTabla(MySqlCommand mySqlCommand){
			mySqlCommand.CommandText = "SELECT * FROM categoria ";
			MySqlDataReader reader =mySqlCommand.ExecuteReader();

			while(reader.Read()) {
				string FirstName = (string) reader["nombre"];
				object LastName = reader["id"];
				Console.WriteLine("Name: " +FirstName + " ID: " + LastName);
			}
			reader.Close ();
			return "HOLA";

		}

	}
}

