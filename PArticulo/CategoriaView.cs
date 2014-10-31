//using MySql.Data.MySqlClient;
using System;
using System.Data;
using SerpisAd;

namespace PArticulo

{
	public partial class CategoriaView : Gtk.Window
	{
		private object id;
		public CategoriaView () : base(Gtk.WindowType.Toplevel)	{
			this.Build ();
			saveAction.Sensitive = false;
		}

		public CategoriaView(object id) : this() {
			saveAction.Sensitive = true;
			addAction1.Sensitive = false;
			this.id = id;
			IDbCommand dbCommand =
				App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = String.Format (
				"select * from categoria where id={0}", id
				);
			IDataReader dataReader = dbCommand.ExecuteReader ();
			dataReader.Read ();
			entryNombre.Text = dataReader ["nombre"].ToString ();
			dataReader.Close ();
		}

		protected void OnSaveActionActivated (object sender, EventArgs e)
		{
			IDbCommand dbCommand =
				App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = String.Format (
				"update categoria set nombre=@nombre where id={0}", id
				);
			dbCommand.AddParameter ("nombre",entryNombre.Text);

			dbCommand.ExecuteNonQuery ();
			Destroy ();
		}
		protected void OnAddActionActivated (object sender, EventArgs e)
		{
			IDbCommand dbCommand =
				App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = String.Format (
				"INSERT INTO `categoria` (nombre) VALUES (@nombre)");
			dbCommand.AddParameter ("nombre",entryNombre.Text);

			dbCommand.ExecuteNonQuery ();
			Destroy ();
		}


	}
}
