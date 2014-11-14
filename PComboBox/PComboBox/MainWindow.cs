using System;
using Gtk;
using System.Collections.Generic;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		List<Categoria> categorias = new List<Categoria> ();
		categorias.Add (new Categoria (1, "uno"));
		categorias.Add (new Categoria (2, "dos"));
		categorias.Add (new Categoria (3, "tres"));

		int categoriaId = 3;

		CellRendererText cellRendererText = new CellRendererText ();
		comboBox.PackStart (cellRendererText, false);
		comboBox.AddAttribute (cellRendererText, "text", 1);

		ListStore listStore = new ListStore (typeof(int),typeof(string));
		TreeIter initialTreeIter = listStore.AppendValues (0, "<sin asignar>");
//		listStore.AppendValues (1,"Uno");
//		listStore.AppendValues (2,"Dos");
//		listStore.AppendValues (3,"Tres");

		foreach (Categoria categoria in categorias) {
			TreeIter currentTreeIter = listStore.AppendValues (categoria.Id, categoria.Nombre);
			if (categoria.Id == categoriaId) {
				initialTreeIter = currentTreeIter;
			}
		}

		comboBox.Model = listStore;

		comboBox.SetActiveIter (initialTreeIter);

		propertiesAction.Activated += delegate {

			TreeIter treeIter;
			bool activeIter = comboBox.GetActiveIter (out treeIter);
			object id = activeIter ? listStore.GetValue (treeIter, 0) : 0;
			Console.WriteLine ("id={0}", id);

		};

	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}

public class Categoria {

	public Categoria (int id, string nombre){
		Id = id;
		Nombre = nombre;
	}
	public int Id { get; set;}
	public string Nombre { get; set;}
}
