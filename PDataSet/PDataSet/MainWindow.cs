using System;
using Gtk;
using System.Data;
using SerpisAd;
using MySql.Data.MySqlClient;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		MySqlConnection mySqlConnection = new MySqlConnection (
			"DataSource=localhost;Database=dbprueba;User ID=root;Password=sistemas"
			);
		mySqlConnection.Open ();

		String sql = "select * from articulo ";

		MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sql,mySqlConnection);

		DataSet dataSet = new DataSet ();
		mySqlDataAdapter.Fill (dataSet);

		show (dataSet);

		DataTable dataTable = dataSet.Tables [0];
		DataRow dataRow = dataTable.Rows [0];
		dataRow ["nombre"] = DateTime.Now.ToString ();

		new MySqlCommandBuilder (mySqlDataAdapter);
		mySqlDataAdapter.Update (dataSet);

		//mySqlDataAdapter


	}

	private void show(DataSet dataSet){
		DataTable dataTable = dataSet.Tables [0];

		foreach (DataColumn dataColumn in dataTable.Columns) {
			Console.WriteLine (dataColumn.ColumnName);
		}

		foreach (DataRow dataRow in dataTable.Rows) {
			foreach (DataColumn dataColumn in dataTable.Columns) {
				Console.WriteLine ("{0}={1}",dataColumn.ColumnName, dataRow[dataColumn]);
			}
		}
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
