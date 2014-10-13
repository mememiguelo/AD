using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnButton3Clicked (object sender, EventArgs e)
	{
		Console.WriteLine ("Has clickado el boton!");
		labelSaludo.LabelProp = "Hola " + entry1.Text;
	}
	
	protected void OnNewActionActivated (object sender, EventArgs e)
	{
		throw new NotImplementedException ();
	}
}
