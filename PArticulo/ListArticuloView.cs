using System;
using System.Data;
using Gtk;
using SerpisAd;

namespace PArticulo
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ListArticuloView : Gtk.Bin
	{
		private ListStore listStore;
		private IDbConnection dbConnection;

		public ListArticuloView ()
		{
			this.Build ();

			dbConnection = App.Instance.DbConnection;
			/*Botones de articulo*/
			deleteAction.Sensitive = false;
			editAction.Sensitive = false;

			treeView.AppendColumn ("ID", new CellRendererText (), "text", 0);
			treeView.AppendColumn ("Nombre", new CellRendererText (), "text", 1);
			treeView.AppendColumn ("Categoria", new CellRendererText (), "text", 2);
			treeView.AppendColumn ("Precio", new CellRendererText (), "text", 3);

			listStore = new ListStore (typeof(string),typeof(string),typeof(string),typeof(string));

			treeView.Model = listStore;

			LecturaArticulos ();

			treeView.Selection.Changed += delegate {
				deleteAction.Sensitive = treeView.Selection.CountSelectedRows() > 0;
				editAction.Sensitive = treeView.Selection.CountSelectedRows() > 0;
			};
		}

		protected void LecturaArticulos(){
			IDbCommand dbCommand = dbConnection.CreateCommand ();
			dbCommand.CommandText = "select a.id, a.nombre, a.precio, c.nombre as categoria from articulo a left join categoria c on (a.categoria = c.id)";
			IDataReader reader = dbCommand.ExecuteReader ();

			while(reader.Read()) {
				string FirstName = (string) reader["nombre"];
				object LastName = reader["id"].ToString();
				object Precio = reader["precio"].ToString();
				object categoria = reader ["categoria"].ToString();

				listStore.AppendValues (LastName, FirstName,categoria,Precio);
			}
			reader.Close ();
		}

		protected void EditarArticulo (object sender, EventArgs e)
		{
			TreeIter treeIter;
			treeView.Selection.GetSelected (out treeIter);
			object id = listStore.GetValue (treeIter, 0);

			ArticuloView articuloView = new ArticuloView (id);
		}

		protected void OnDeleteActionActivated (object sender, EventArgs e)
		{
			//Console.WriteLine ("Accion borrar fila activada");
			TreeIter treeIter;
			treeView.Selection.GetSelected (out treeIter);
			object id = listStore.GetValue (treeIter, 0);

			if (!Confirm ("¿Quieres eliminar la fila?"))
				return;

			IDbCommand dbCommand = dbConnection.CreateCommand ();
			dbCommand.CommandText = string.Format ("DELETE FROM `articulo` WHERE id={0}", id);
			dbCommand.ExecuteNonQuery ();

			listStore.Clear ();
			LecturaArticulos ();
		}

		public bool Confirm(String text){
			MessageDialog mensaje = new MessageDialog (
				this.GetWindow(),
				DialogFlags.Modal,
				MessageType.Question,
				ButtonsType.YesNo,
				text
				);

			ResponseType respuesta = (ResponseType)mensaje.Run ();
			mensaje.Destroy ();

			return respuesta == ResponseType.Yes;

		}

		protected void OnNewActionActivated (object sender, EventArgs e)
		{
			ArticuloView articuloNew = new ArticuloView ();
		}

		protected void OnRefreshActionActivated (object sender, EventArgs e)
		{
			Console.WriteLine ("Name={0} Parent.Name={1} ", Name, Parent.Name); 

			listStore.Clear ();
			LecturaArticulos ();	
		}
	}

	public static class WidgetExtensions {
		public static Window GetWindow(this Widget widget) {
			while (widget.Parent != null)
				widget = widget.Parent;
			return (Window)widget;
		}
	}
}

