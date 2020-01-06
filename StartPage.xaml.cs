using System;
using System.Collections.Generic;
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

namespace RepairShopClient {
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Page {
        public StartPage() {
            InitializeComponent();
        }

        public void startButton(object Sender, RoutedEventArgs e) {

            Console.WriteLine("startButton");
        }

        private void addItems(object sender, RoutedEventArgs e) {

            Console.WriteLine("AddItems");
            //var addItemPage = new AddItemPage();
            //((MainWindow)System.Windows.Application.Current.MainWindow).mainFrame.Content = addItemPage;
        }

    }
}
