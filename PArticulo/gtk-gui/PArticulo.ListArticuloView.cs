
// This file has been generated by the GUI designer. Do not modify.
namespace PArticulo
{
	public partial class ListArticuloView
	{
		private global::Gtk.UIManager UIManager;
		private global::Gtk.Action newAction;
		private global::Gtk.Action editAction;
		private global::Gtk.Action deleteAction;
		private global::Gtk.Action refreshAction;
		private global::Gtk.VBox vbox1;
		private global::Gtk.Toolbar toolbar1;
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::Gtk.TreeView treeView;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget PArticulo.ListArticuloView
			Stetic.BinContainer w1 = global::Stetic.BinContainer.Attach (this);
			this.UIManager = new global::Gtk.UIManager ();
			global::Gtk.ActionGroup w2 = new global::Gtk.ActionGroup ("Default");
			this.newAction = new global::Gtk.Action ("newAction", null, null, "gtk-new");
			w2.Add (this.newAction, null);
			this.editAction = new global::Gtk.Action ("editAction", null, null, "gtk-edit");
			w2.Add (this.editAction, null);
			this.deleteAction = new global::Gtk.Action ("deleteAction", null, null, "gtk-delete");
			w2.Add (this.deleteAction, null);
			this.refreshAction = new global::Gtk.Action ("refreshAction", null, null, "gtk-refresh");
			w2.Add (this.refreshAction, null);
			this.UIManager.InsertActionGroup (w2, 0);
			this.Name = "PArticulo.ListArticuloView";
			// Container child PArticulo.ListArticuloView.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString ("<ui><toolbar name='toolbar1'><toolitem name='newAction' action='newAction'/><toolitem name='editAction' action='editAction'/><toolitem name='deleteAction' action='deleteAction'/><toolitem name='refreshAction' action='refreshAction'/></toolbar></ui>");
			this.toolbar1 = ((global::Gtk.Toolbar)(this.UIManager.GetWidget ("/toolbar1")));
			this.toolbar1.Name = "toolbar1";
			this.toolbar1.ShowArrow = false;
			this.vbox1.Add (this.toolbar1);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.toolbar1]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.treeView = new global::Gtk.TreeView ();
			this.treeView.CanFocus = true;
			this.treeView.Name = "treeView";
			this.GtkScrolledWindow.Add (this.treeView);
			this.vbox1.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.GtkScrolledWindow]));
			w5.Position = 1;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			w1.SetUiManager (UIManager);
			this.Hide ();
			this.newAction.Activated += new global::System.EventHandler (this.OnNewActionActivated);
			this.editAction.Activated += new global::System.EventHandler (this.EditarArticulo);
			this.deleteAction.Activated += new global::System.EventHandler (this.OnDeleteActionActivated);
			this.refreshAction.Activated += new global::System.EventHandler (this.OnRefreshActionActivated);
		}
	}
}
