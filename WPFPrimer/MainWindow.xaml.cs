using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFPrimer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public ObservableCollection<Osoba> Osobe = new ObservableCollection<Osoba>();

		public MainWindow()
		{
			InitializeComponent();
			DataContext = new Osoba();
			BindingGroup = new BindingGroup();
			dg.ItemsSource = Osobe;
		}

		private void Unos(object sender, RoutedEventArgs e)
		{
			BindingGroup.CommitEdit();
			if (DataContext is Osoba o)
			{
				if (!Osobe.Contains(o))
				{
					Osobe.Add(o);
				}
				DataContext = new Osoba();
			}
		}

		private void Brisanje(object o, RoutedEventArgs zklj)
		{
			Osobe.Remove(dg.SelectedItem as Osoba);
		}

		private void Promena(object sender, SelectionChangedEventArgs e)
		{
			if (dg.SelectedItem != null)
			{
				DataContext = dg.SelectedItem;
			}else
			{
				DataContext = new Osoba();
			}
		}

		private void NoviProzor(object sender, RoutedEventArgs e)
		{
			DrugiProzor dp = new DrugiProzor();
			dp.Owner = this;
			dp.ShowDialog();
			MessageBox.Show(dp.DataContext.ToString());
		}
	}
}
