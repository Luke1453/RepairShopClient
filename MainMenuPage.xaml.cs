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
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page {

        PageChanger pageChanger = new PageChanger();

        public MainMenuPage() {
            InitializeComponent();
        }

        private void newRecordClick(object sender, RoutedEventArgs e) {

            AddCarWindow addCarWindow = new AddCarWindow();
            addCarWindow.ShowDialog();
        }

        private void unfinishedCarBrowserClick(object sender, RoutedEventArgs e) {

            pageChanger.openUnfinishedCarBrowser();

        }

    }
}
