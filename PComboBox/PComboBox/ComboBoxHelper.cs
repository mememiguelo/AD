using System;
using Gtk;
using System.Data;
/****
 * 
 * Este archivo ya no se utiliza , ahora esta funcion se realiza desde SerpisAd
 * Cambios de dia 17 / 11 / 2014
 * 
 ****/
namespace SerpisAd
{
	public class ComboBoxHelper
	{
		public ComboBoxHelper (ComboBox comboBox,object categoriaId, string selectSql)
		{
			//ulong categoriaId = 5;

			//cambiar este archivo a PSerpisAd para que asi pueda ser general y accesible despde otros archivos como PArticulo que el objetivo

			CellRendererText cellRendererText = new CellRendererText ();
			comboBox.PackStart (cellRendererText, false);
			comboBox.AddAttribute (cellRendererText, "text", 1);

			ListStore listStore = new ListStore (typeof(ulong),typeof(string));
			TreeIter initialTreeIter = listStore.AppendValues ((ulong)0, "<sin asignar>");

			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = "select id,nombre from categoria";
			IDataReader dataReader = dbCommand.ExecuteReader ();
			while (dataReader.Read()) {
				object id = dataReader ["id"];
				object nombre = dataReader ["nombre"];
				TreeIter treeIter = listStore.AppendValues (id, nombre);
				if (categoriaId.Equals(id)) {
					initialTreeIter = treeIter;
				}
			}
			dataReader.Close ();

			//		foreach (Categoria categoria in categorias) {
			//			listStore.AppendValues (categoria.Id, categoria.Nombre);
			////			if (categoria.Id == categoriaId) {
			////				initialTreeIter = currentTreeIter;
			////			}
			//		}

			comboBox.Model = listStore;

			comboBox.SetActiveIter (initialTreeIter);

			//		TreeIter currentTreeIter;
			//		listStore.GetIterFirst (out currentTreeIter);
			//		do {
			//			if (categoriaId.Equals(listStore.GetValue(currentTreeIter, 0)) ){
			//				comboBox.SetActiveIter (currentTreeIter);
			//				break;
			//			}
			//		} while (listStore.IterNext (ref currentTreeIter));
			//
		}
	}
}

