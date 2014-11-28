using System;
using Gtk;
using System.Reflection;
using PReflection;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		//showInfo (typeof(Categoria));

		//showInfo (typeof(Articulo));

		//Type type = typeof(MainWindow);
		Assembly assembly = Assembly.GetExecutingAssembly ();
		foreach (Type type in assembly.GetTypes()) {
			if (type.IsDefined (typeof(EntityAttribute), true)) {
				EntityAttribute entityAttribute = 
					(EntityAttribute)Attribute.GetCustomAttribute (type, typeof(EntityAttribute));
				Console.WriteLine ("type.Name={0} entityAttribute.TableName={1}", type.Name,entityAttribute.TableName);
			}
		}
		//assembly.

		Categoria categoria = new Categoria (22, "Luis");

		showValues (categoria);
	}

	private void showValues(object obj){
		Type type = obj.GetType();
		FieldInfo[] fields = type.GetFields (BindingFlags.Instance | BindingFlags.NonPublic);
		foreach (FieldInfo field in fields) {
			object value = field.GetValue (obj);
			Console.WriteLine ("nombre={0,-20} \t PropertyType={1}",field.Name , value);
		}
	}

	private void showInfo(Type type){
		//Type type = typeof(Categoria);
		Console.WriteLine ("Nombre={0}", type.Name);

		PropertyInfo[] properties = type.GetProperties (); 

		foreach (PropertyInfo property in properties) {
			Console.WriteLine ("nombre={0,-20} \t PropertyType={1}",property.Name , property.PropertyType);
		}

		FieldInfo[] fields = type.GetFields (BindingFlags.Instance | BindingFlags.NonPublic);
		foreach (FieldInfo field in fields) {
			Console.WriteLine ("nombre={0,-20} \t PropertyType={1}",field.Name , field.FieldType);
		}
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
