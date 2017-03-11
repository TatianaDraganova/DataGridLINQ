using System;
using System.Collections.Generic;
using System.Configuration;
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


namespace DataGridLINQ
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void ShowMustGoOn_Click(object sender, RoutedEventArgs e)
		{
			var constr = ConfigurationManager.ConnectionStrings["constr"].ToString();
			var dbContext = new DataGridLINQDataContext(constr);
			var result = from ticket in dbContext.Tickets
				select new
				{
					ticket.FirstName,
					ticket.SecondName,
					Source = ticket.City.Name,
				};
			dataGrid.ItemsSource = result;
		}
		}
}
