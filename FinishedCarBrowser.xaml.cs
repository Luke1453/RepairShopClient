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
    /// Interaction logic for FinishedCarBrowser.xaml
    /// </summary>
    public partial class FinishedCarBrowser : Page {

        List<CarData> finishedCarDatas = new List<CarData>();
        List<CarData> searchFinishedCarDatas = new List<CarData>();

        public FinishedCarBrowser() {

            InitializeComponent();

            finishedCarDatas.Clear();

            DataBaseReader DBreader = new DataBaseReader();
            DBreader.CommandText = "SELECT * FROM FinishedCarRepairRecords";
            DBreader.execCommand();

            while (DBreader.SQLiteDataReader.Read()) {

                CarData carData = new CarData();

                carData.DBId = DBreader.SQLiteDataReader.GetInt32(0);
                carData.ClientName = DBreader.SQLiteDataReader.GetString(1);
                carData.ClientSurname = DBreader.SQLiteDataReader.GetString(2);
                carData.ClientPhone = DBreader.SQLiteDataReader.GetString(3);
                carData.TimeAdded = DBreader.SQLiteDataReader.GetInt32(4); //change formatting
                carData.CarMake = DBreader.SQLiteDataReader.GetInt32(5);    //change formatting
                carData.CarModel = DBreader.SQLiteDataReader.GetString(6);
                carData.CarNR = DBreader.SQLiteDataReader.GetString(7);
                carData.CarID = DBreader.SQLiteDataReader.GetString(8);
                carData.EngineVol = DBreader.SQLiteDataReader.GetInt32(9);
                carData.EnginePower = DBreader.SQLiteDataReader.GetInt32(10);
                carData.FuelType = DBreader.SQLiteDataReader.GetInt32(11); //chage formatting
                carData.WorkDescription = DBreader.SQLiteDataReader.GetString(12);
                carData.WorkPrice = DBreader.SQLiteDataReader.GetFloat(13);

                carData.formatData();

                finishedCarDatas.Add(carData);

            }

            DBreader.closeConnection();
            dataGrid.ItemsSource = finishedCarDatas;


        }

        private void refreshDataGrid() {

            dataGrid.ItemsSource = null;
            finishedCarDatas.Clear();

            DataBaseReader DBreader = new DataBaseReader();
            DBreader.CommandText = "SELECT * FROM FinishedCarRepairRecords";
            DBreader.execCommand();

            while (DBreader.SQLiteDataReader.Read()) {

                CarData carData = new CarData();

                carData.DBId = DBreader.SQLiteDataReader.GetInt32(0);
                carData.ClientName = DBreader.SQLiteDataReader.GetString(1);
                carData.ClientSurname = DBreader.SQLiteDataReader.GetString(2);
                carData.ClientPhone = DBreader.SQLiteDataReader.GetString(3);
                carData.TimeAdded = DBreader.SQLiteDataReader.GetInt32(4);
                carData.CarMake = DBreader.SQLiteDataReader.GetInt32(5);
                carData.CarModel = DBreader.SQLiteDataReader.GetString(6);
                carData.CarNR = DBreader.SQLiteDataReader.GetString(7);
                carData.CarID = DBreader.SQLiteDataReader.GetString(8);
                carData.EngineVol = DBreader.SQLiteDataReader.GetInt32(9);
                carData.EnginePower = DBreader.SQLiteDataReader.GetInt32(10);
                carData.FuelType = DBreader.SQLiteDataReader.GetInt32(11);
                carData.WorkDescription = DBreader.SQLiteDataReader.GetString(12);
                carData.WorkPrice = DBreader.SQLiteDataReader.GetFloat(13);

                carData.formatData();

                finishedCarDatas.Add(carData);

            }

            DBreader.closeConnection();
            dataGrid.ItemsSource = finishedCarDatas;

        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e) {

            if (String.IsNullOrEmpty(((TextBox)sender).Text) || String.IsNullOrWhiteSpace(((TextBox)sender).Text)) {

                dataGrid.ItemsSource = finishedCarDatas;

            }
            else if (((TextBox)sender).Text != null) {

                searchFinishedCarDatas.Clear();

                string query = ((TextBox)sender).Text;

                foreach (CarData car in finishedCarDatas) {

                    if (car.CarNR.Contains(query)) {
                        searchFinishedCarDatas.Add(car);
                    }

                }

                dataGrid.ItemsSource = searchFinishedCarDatas;
            }

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e) {

            PageChanger pageChanger = new PageChanger();
            pageChanger.openMainMenu();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e) {

            if (dataGrid.SelectedItem == null) {
                return;
            }
            else {

                deleteOrder((CarData)dataGrid.SelectedItem);
            }

            this.refreshDataGrid();

        }

        private void deleteOrder(CarData carData) {

            try {

                DataBaseReader DBreader = new DataBaseReader();
                DBreader.SQLiteCommand = DBreader.SQLiteConnection.CreateCommand();
                DBreader.SQLiteCommand.CommandText = "DELETE FROM FinishedCarRepairRecords where id=@id";
                DBreader.SQLiteCommand.Parameters.AddWithValue("@id", carData.DBId);
                DBreader.SQLiteCommand.Prepare();
                DBreader.SQLiteCommand.ExecuteNonQuery();

                DBreader.closeConnection();

            }
            catch (Exception) {

                throw;
            }
        }

    }
}
