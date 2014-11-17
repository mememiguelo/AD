using System;
using Gtk;
using System.Collections.Generic;
using System.Data;
using SerpisAd;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		new ComboBoxHelper(comboBox, (ulong)5,"select id,nombre from categorias");

//		List<Categoria> categorias = new List<Categoria> ();
//		categorias.Add (new Categoria (1, "uno"));
//		categorias.Add (new Categoria (2, "dos"));
//		categorias.Add (new Categoria (3, "tres"));



		propertiesAction.Activated += delegate {

			TreeIter treeIter;
			bool activeIter = comboBox.GetActiveIter (out treeIter);
			object id = activeIter ? comboBox.Model.GetValue (treeIter, 0) : 0;
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
