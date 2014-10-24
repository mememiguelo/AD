using System;
using Gtk;
using PNotebook;
public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		ArticuloAction.Activated += delegate {
			addPage (new MyTreeView(), "Artículo");
		};
		CategoriaAction.Activated += delegate {
			addPage (new MyTreeView(), "Categoría");
		};
		notebook1.SwitchPage += delegate {
			onPageChanged();
			//Console.WriteLine("notebook.CurrentPage = {0}", notebook1.CurrentPage);
		};

		notebook1.PageRemoved += delegate {
			Console.WriteLine("notebook1.PageRemoved notebook1.CurrentPage = {0}", notebook1.CurrentPage);
		};
	}

	private void onPageChanged(){
		Console.WriteLine("onPageChanged notebook.CurrentPage = {0}", notebook1.CurrentPage);
	}

	private void addPage (Widget widget, string label) {
		HBox hBox = new HBox ();
		hBox.Add (new Label (label));
		Button button = new Button (new Image(Stock.Cancel, IconSize.Button) );
		hBox.Add (button);
		hBox.ShowAll ();
		notebook1.CurrentPage = notebook1.AppendPage (widget, hBox);
		button.Clicked += delegate {
			widget.Destroy();
			if(notebook1.CurrentPage ==-1)
				onPageChanged();
		};
	}
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}