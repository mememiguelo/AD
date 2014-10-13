using System;
using Gtk;
using System.Data;
using MySql.Data.MySqlClient;

using PCategoria;

public partial class MainWindow: Gtk.Window
{	
	private ListStore listStore;

	/*private string connectionString =
		"Server=localhost;" +
			"Database=dbprueba;" +
			"User ID=root;" +
			"Password=sistemas";
	*/
	private MySqlConnection mySqlConnection;
	///private MySqlCommand mySqlCommand;




	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		deleteAction1.Sensitive = false;
		editAction.Sensitive = false;

		mySqlConnection = App.Instance.MySqlConnection;

		treeView.AppendColumn ("ID", new CellRendererText (), "text", 0);
		treeView.AppendColumn ("Nombre", new CellRendererText (), "text", 1);

		listStore = new ListStore (typeof(string),typeof(string));

		treeView.Model = listStore; // en java treeView.setModel(listStore);

		Lectura ();

		treeView.Selection.Changed += delegate {

			deleteAction1.Sensitive = treeView.Selection.CountSelectedRows() > 0;
			editAction.Sensitive = treeView.Selection.CountSelectedRows() > 0;
			
		};
	}

	private void selectionChanged (object sender, EventArgs e)
	{
		Console.WriteLine ("selectionCanged");
	}

	private void selectionChangedSegundo (object sender, EventArgs e)
	{
		Console.WriteLine ("selectionCangedSegundo");
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnAddActionActivated (object sender, EventArgs e)
	{
		//mySqlConnection.Open();
		MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
		mySqlCommand.CommandText = string.Format("INSERT into categoria (nombre) value ('{0}')",DateTime.Now);
		mySqlCommand.ExecuteNonQuery ();
		//mySqlConnection.Close ();
	}



	protected void OnRefreshActionActivated (object sender, EventArgs e)
	{
		listStore.Clear ();
		Lectura ();	

	}

	protected void Lectura(){
		//mySqlConnection = new MySqlConnection (connectionString);
		MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();

		//mySqlConnection.Open();
		mySqlCommand.CommandText = "SELECT * FROM categoria ";
		MySqlDataReader reader =mySqlCommand.ExecuteReader();

		while(reader.Read()) {
			string FirstName = (string) reader["nombre"];
			object LastName = reader["id"].ToString();
			listStore.AppendValues (LastName, FirstName);
		}
		reader.Close ();
		//mySqlConnection.Close ();
	}

	protected void OnDeleteAction1Activated (object sender, EventArgs e)
	{
		//Console.WriteLine ("Accion borrar fila activada");
		TreeIter treeIter;
		treeView.Selection.GetSelected (out treeIter);
		object id = listStore.GetValue (treeIter, 0);

		if (!Confirm ("¿Quieres eliminar la fila?"))
			return;

		//mySqlConnection.Open();
		MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
		mySqlCommand.CommandText = string.Format ("DELETE FROM `categoria` WHERE id={0}", id);
		mySqlCommand.ExecuteNonQuery ();
		//mySqlConnection.Close ();

	}

	public bool Confirm(String text){
		MessageDialog mensaje = new MessageDialog (
			this,
			DialogFlags.Modal,
			MessageType.Question,
			ButtonsType.YesNo,
			text
			);

		ResponseType respuesta = (ResponseType)mensaje.Run ();
		mensaje.Destroy ();

		return respuesta == ResponseType.Yes;

	}

	protected void OnEditActionActivated (object sender, EventArgs e)
	{
		TreeIter treeIter;
		treeView.Selection.GetSelected (out treeIter);
		object id = listStore.GetValue (treeIter, 0);

		Categoriaview categoriaview = new Categoriaview (id);

	}
}
