using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShopClient {
    class PageChanger {

        public void openUnfinishedCarBrowser() {

            UnfinishedCarBrowser unfinishedCarBrowser = new UnfinishedCarBrowser();
            ((MainWindow)System.Windows.Application.Current.MainWindow).mainFrame.Content = unfinishedCarBrowser;

        }

        public void openFinishedCarBrowser() {

            FinishedCarBrowser finishedCarBrowser = new FinishedCarBrowser();
            ((MainWindow)System.Windows.Application.Current.MainWindow).mainFrame.Content = finishedCarBrowser;

        }

        public void openMainMenu() {
            MainMenuPage mainMenuPage = new MainMenuPage();
            ((MainWindow)System.Windows.Application.Current.MainWindow).mainFrame.Content = mainMenuPage;
        }

    }
}
