using System;
using Gtk;
using System.Data;
using SerpisAd;

using PArticulo;

public partial class MainWindow: Gtk.Window
{	
//	private ListStore listStore;
//	private ListStore listStoreCat;
//	private IDbConnection dbConnection;
//
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();


		/*Botones de articulo*/
//		deleteAction.Sensitive = false;
//		editAction.Sensitive = false;
		/*Botones de categoria*/
//		deleteAction1.Sensitive = false;
//		editAction1.Sensitive = false;

//		dbConnection = App.Instance.DbConnection;

//		treeView.AppendColumn ("ID", new CellRendererText (), "text", 0);
//		treeView.AppendColumn ("Nombre", new CellRendererText (), "text", 1);
//		treeView.AppendColumn ("Precio", new CellRendererText (), "text", 2);

//		treeviewCat.AppendColumn ("ID", new CellRendererText (), "text", 0);
//		treeviewCat.AppendColumn ("Nombre", new CellRendererText (), "text", 1);

//		listStore = new ListStore (typeof(string),typeof(string),typeof(string));
//		listStoreCat = new ListStore (typeof(string),typeof(string));

//		treeView.Model = listStore;
//		treeviewCat.Model = listStoreCat;

//		LecturaArticulos ();
//		LecturaCategoria ();

//		treeView.Selection.Changed += delegate {
//			deleteAction.Sensitive = treeView.Selection.CountSelectedRows() > 0;
//			editAction.Sensitive = treeView.Selection.CountSelectedRows() > 0;
//		};
//		treeviewCat.Selection.Changed += delegate {
//			deleteAction1.Sensitive = treeviewCat.Selection.CountSelectedRows() > 0;
//			editAction1.Sensitive = treeviewCat.Selection.CountSelectedRows() > 0;
//		};

	}

//	protected void LecturaArticulos(){
//		IDbCommand dbCommand = dbConnection.CreateCommand ();
//		dbCommand.CommandText = "SELECT * FROM articulo ";
//		IDataReader reader = dbCommand.ExecuteReader ();
//
//		while(reader.Read()) {
//			string FirstName = (string) reader["nombre"];
//			object LastName = reader["id"].ToString();
//			object Precio = reader["precio"].ToString().Replace(',', '.');
//			listStore.AppendValues (LastName, FirstName,Precio);
//		}
//		reader.Close ();
//	}

//	protected void LecturaCategoria(){
//		IDbCommand dbCommand = dbConnection.CreateCommand ();
//		dbCommand.CommandText = "SELECT * FROM categoria ";
//		IDataReader reader = dbCommand.ExecuteReader ();
//
//		while(reader.Read()) {
//			string FirstName = (string) reader["nombre"];
//			object LastName = reader["id"].ToString();
//			listStoreCat.AppendValues (LastName, FirstName);
//		}
//		reader.Close ();
//	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
//	protected void OnEditActionActivated (object sender, EventArgs e)
//	{
//		TreeIter treeIter;
//		treeView.Selection.GetSelected (out treeIter);
//		object id = listStore.GetValue (treeIter, 0);
//
//		ArticuloView articuloView = new ArticuloView (id);
//
//	}
//
//	protected void OnEditAction1Activated (object sender, EventArgs e)
//	{
//		TreeIter treeIter;
//		treeviewCat.Selection.GetSelected (out treeIter);
//		object id = listStoreCat.GetValue (treeIter, 0);
//
//		CategoriaView CategoriaView = new CategoriaView (id);
//	}

//	protected void OnDeleteActionActivated (object sender, EventArgs e)
//	{
//		//Console.WriteLine ("Accion borrar fila activada");
//		TreeIter treeIter;
//		treeView.Selection.GetSelected (out treeIter);
//		object id = listStore.GetValue (treeIter, 0);
//
//		if (!Confirm ("¿Quieres eliminar la fila?"))
//			return;
//
//		IDbCommand dbCommand = dbConnection.CreateCommand ();
//		dbCommand.CommandText = string.Format ("DELETE FROM `articulo` WHERE id={0}", id);
//		dbCommand.ExecuteNonQuery ();
//
//		listStore.Clear ();
//		LecturaArticulos ();
//	}

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
//	protected void OnNewActionActivated (object sender, EventArgs e)
//	{
//		ArticuloView articuloNew = new ArticuloView ();
//	}
	
//	protected void OnRefreshActionActivated (object sender, EventArgs e)
//	{
//		listStore.Clear ();
//		LecturaArticulos ();	
//	}
//	protected void OnNewAction1Activated (object sender, EventArgs e)
//	{
//		CategoriaView CategoriaView = new CategoriaView ();
//	}

//	protected void OnRefreshAction1Activated (object sender, EventArgs e)
//	{
//		listStoreCat.Clear ();
//		LecturaCategoria ();
//	}

//	protected void OnDeleteAction1Activated (object sender, EventArgs e)
//	{
//		//Console.WriteLine ("Accion borrar fila activada");
//		TreeIter treeIter;
//		treeviewCat.Selection.GetSelected (out treeIter);
//		object id = listStoreCat.GetValue (treeIter, 0);
//
//		if (!Confirm ("¿Quieres eliminar la fila?"))
//			return;
//
//
//
//		//mySqlConnection.Open();
//		IDbCommand dbCommand = dbConnection.CreateCommand ();
//		dbCommand.CommandText = string.Format ("DELETE FROM `categoria` WHERE id={0}", id);
//		dbCommand.ExecuteNonQuery ();
//		//mySqlConnection.Close ();
//		listStore.Clear ();
//		LecturaCategoria ();
//	}
//

}
