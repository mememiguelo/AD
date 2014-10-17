//using MySql.Data.MySqlClient;
using System;
using System.Data;
using SerpisAd;

namespace PCategoria

{
	public partial class Categoriaview : Gtk.Window
	{
		private object id;
		public Categoriaview () : base(Gtk.WindowType.Toplevel)	{
			this.Build ();
		}

		public Categoriaview(object id) : this() {
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
//			IDbDataParameter dbDataParameter = dbCommand.CreateParameter ();
//			dbDataParameter.ParameterName = "nombre";
//			dbDataParameter.Value = entryNombre.Text;
//			dbCommand.Parameters.Add (dbDataParameter);

//			DbCommandExtensions.AddParameter (dbCommand, "nombre", entryNombre.Text);
			dbCommand.AddParameter ("nombre",entryNombre.Text);

			dbCommand.ExecuteNonQuery ();
			Destroy ();
		}
	}
}