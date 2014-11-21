using System;
using Gtk;
using System.Data;
using MySql.Data.MySqlClient;
using SerpisAd;

namespace PDataSet
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}
