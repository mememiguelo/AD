using System;
using Gtk;
using System.Data;
using SerpisAd;

public partial class MainWindow: Gtk.Window
{	
	private ListStore listStore;
	private IDbConnection dbConnection;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		deleteAction.Sensitive = false;
		editAction.Sensitive = false;

		dbConnection = App.Instance.DbConnection;

		treeView.AppendColumn ("ID", new CellRendererText (), "text", 0);
		treeView.AppendColumn ("Nombre", new CellRendererText (), "text", 1);
		treeView.AppendColumn ("Precio", new CellRendererText (), "text", 2);

		listStore = new ListStore (typeof(string),typeof(string),typeof(string));

		treeView.Model = listStore;

		Lectura ();

		treeView.Selection.Changed += delegate {

			deleteAction.Sensitive = treeView.Selection.CountSelectedRows() > 0;
			editAction.Sensitive = treeView.Selection.CountSelectedRows() > 0;

		};

	}

	protected void Lectura(){
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = "SELECT * FROM articulo ";
		IDataReader reader = dbCommand.ExecuteReader ();

		while(reader.Read()) {
			string FirstName = (string) reader["nombre"];
			object LastName = reader["id"].ToString();
			object Precio = reader["precio"].ToString();
			listStore.AppendValues (LastName, FirstName,Precio);
		}
		reader.Close ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
