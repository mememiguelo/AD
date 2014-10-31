using System;
using System.Data;
using SerpisAd;

namespace PArticulo
{
	public partial class ArticuloView : Gtk.Window
	{
		private object id;
		public ArticuloView () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			saveAction.Sensitive = false;
		}

		public ArticuloView(object id) : this() {
			saveAction.Sensitive = true;
			addAction.Sensitive = false;
			this.id = id;
			IDbCommand dbCommand =
				App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = String.Format (
				"select * from articulo where id={0}", id
				);
			IDataReader dataReader = dbCommand.ExecuteReader ();
			dataReader.Read ();
			entryNombre.Text = dataReader ["nombre"].ToString ();
			entryCategoria.Text = dataReader ["categoria"].ToString ();
			entryPrecio.Text = dataReader ["precio"].ToString ().Replace(',', '.');
			dataReader.Close ();
			/* *** Cargamos la lista de categorias en el combobox ***
			IDbCommand dbCommand2 =
				App.Instance.DbConnection.CreateCommand ();
			dbCommand2.CommandText = String.Format (
				"select * from categoria", id
				);
			IDataReader dataReader2= dbCommand2.ExecuteReader ();
			int sum = 0;
			while(dataReader2.Read ()) {
				string FirstName = (string) dataReader2["nombre"];
				combobox3.InsertText (sum, FirstName);
				sum++;
			}

			dataReader.Close ();*/
		}
		protected void OnSaveActionActivated (object sender, EventArgs e)
		{
			IDbCommand dbCommand =
				App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = String.Format (
				"update articulo set nombre=@nombre, categoria=@categoria, precio=@precio where id={0}", id
				);
			dbCommand.AddParameter ("nombre",entryNombre.Text);
			dbCommand.AddParameter ("categoria",entryCategoria.Text);
			dbCommand.AddParameter ("precio",entryPrecio.Text.Replace(',', '.'));

			dbCommand.ExecuteNonQuery ();
			Destroy ();
		}
		protected void OnAddActionActivated (object sender, EventArgs e)
		{
			IDbCommand dbCommand =
				App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = String.Format (
				"INSERT INTO `articulo` (nombre,categoria,precio) VALUES (@nombre,@categoria,@precio)");
			dbCommand.AddParameter ("nombre",entryNombre.Text);
			dbCommand.AddParameter ("categoria",entryCategoria.Text);
			dbCommand.AddParameter ("precio",entryPrecio.Text.Replace(',', '.'));

			dbCommand.ExecuteNonQuery ();
			Destroy ();
		}

	}
}

