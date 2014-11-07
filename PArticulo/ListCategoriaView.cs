using System;
using System.Data;
using Gtk;
using SerpisAd;

namespace PArticulo
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ListCategoriaView : Gtk.Bin
	{
		private ListStore listStoreCat;
		private IDbConnection dbConnection;

		public ListCategoriaView ()
		{
			this.Build ();

			deleteAction1.Sensitive = false;
			editAction1.Sensitive = false;

			dbConnection = App.Instance.DbConnection;


			treeviewCat.AppendColumn ("ID", new CellRendererText (), "text", 0);
			treeviewCat.AppendColumn ("Nombre", new CellRendererText (), "text", 1);

			listStoreCat = new ListStore (typeof(string),typeof(string));

			treeviewCat.Model = listStoreCat;

			LecturaCategoria ();

			treeviewCat.Selection.Changed += delegate {
				deleteAction1.Sensitive = treeviewCat.Selection.CountSelectedRows() > 0;
				editAction1.Sensitive = treeviewCat.Selection.CountSelectedRows() > 0;
			};



		}

		protected void LecturaCategoria(){
			IDbCommand dbCommand = dbConnection.CreateCommand ();
			dbCommand.CommandText = "SELECT * FROM categoria ";
			IDataReader reader = dbCommand.ExecuteReader ();

			while(reader.Read()) {
				string FirstName = (string) reader["nombre"];
				object LastName = reader["id"].ToString();
				listStoreCat.AppendValues (LastName, FirstName);
			}
			reader.Close ();
		}

		protected void OnEditActionCategoriaActivated (object sender, EventArgs e)
		{
			TreeIter treeIter;
			treeviewCat.Selection.GetSelected (out treeIter);
			object id = listStoreCat.GetValue (treeIter, 0);

			CategoriaView CategoriaView = new CategoriaView (id);
		}


		protected void OnRefreshActionCategoriaActivated (object sender, EventArgs e)
		{
			listStoreCat.Clear ();
			LecturaCategoria ();
		}

		protected void OnDeleteActionCategoriaActivated (object sender, EventArgs e)
		{
			//Console.WriteLine ("Accion borrar fila activada");
			TreeIter treeIter;
			treeviewCat.Selection.GetSelected (out treeIter);
			object id = listStoreCat.GetValue (treeIter, 0);

//			if (!Confirm ("¿Quieres eliminar la fila?"))
//				return;



			//mySqlConnection.Open();
			IDbCommand dbCommand = dbConnection.CreateCommand ();
			dbCommand.CommandText = string.Format ("DELETE FROM `categoria` WHERE id={0}", id);
			dbCommand.ExecuteNonQuery ();
			//mySqlConnection.Close ();
			listStoreCat.Clear ();
			LecturaCategoria ();
		}
		protected void OnNewActionActivated (object sender, EventArgs e)
		{
			CategoriaView articuloNew = new CategoriaView ();
		}


	}
}

