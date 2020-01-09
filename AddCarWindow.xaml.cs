using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace RepairShopClient {
    /// <summary>
    /// Interaction logic for AddCarWindow.xaml
    /// </summary>
    public partial class AddCarWindow : Window {

        public AddCarWindow() {

            InitializeComponent();

            //sett todays date in datapicker
            acceptanceDateCB.SelectedDate = DateTime.Today;

            //populate car brand combobox
            DataBaseReader DBreader = new DataBaseReader {
                CommandText = "SELECT Brand FROM CarBrands"
            };
            DBreader.execCommand();

            while (DBreader.SQLiteDataReader.Read()) {
                makeCB.Items.Add(DBreader.SQLiteDataReader.GetString(0));
            }

            DBreader.closeConnection();


            //populate fuel type combo box
            DBreader = new DataBaseReader {
                CommandText = "SELECT FuelType FROM FuelType"
            };
            DBreader.execCommand();

            while (DBreader.SQLiteDataReader.Read()) {
                fuelTypeCB.Items.Add(DBreader.SQLiteDataReader.GetString(0));
            }

            DBreader.closeConnection();
            

        }

        private void save_Click(object sender, RoutedEventArgs e) {

            //TODO: save button cant be clicked if form isnt filled

            CarData carData = new CarData();

            carData.ClientName = nameTB.Text;
            carData.ClientSurname = surnameTB.Text;
            carData.ClientPhone = phoneTB.Text;
            carData.CarModel = modelTB.Text;
            carData.CarNR = carNRTB.Text;
            carData.CarID = carIDTB.Text;
            carData.EnginePower = Int32.Parse(enginePowerTB.Text);

            carData.CarMake = makeCB.SelectedIndex + 1;
            carData.FuelType = fuelTypeCB.SelectedIndex + 1;

            //converting date to unix time stap + seconds
            long unixTime= ((DateTimeOffset)acceptanceDateCB.SelectedDate).ToUnixTimeSeconds();
            TimeSpan t = (DateTime.Now - DateTime.Today);
            unixTime += (long)t.TotalSeconds;
                //Console.WriteLine(unixTime);
            carData.TimeAdded = unixTime;

            //dealing with volume
            carData.EngineVol = Int32.Parse(engineVolumeCB.Text);

            //sending to database
            SaveUnfinishedCar saveUnfinishedCar = new SaveUnfinishedCar();
            Saving(saveUnfinishedCar, carData);

            this.Close();

        }

        public void Saving(ISaveDB saver, CarData carData) {

            saver.saveToDB(carData);
        }

        private void cancel_Click(object sender, RoutedEventArgs e) {

            this.Close();
        }

        private void phoneTB_PreviewTextInput(object sender, TextCompositionEventArgs e) {

            Regex regex = new Regex("[^0-9 ()+-]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void enginePowerTB_PreviewTextInput(object sender, TextCompositionEventArgs e) {

            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void engineVolumeCB_PreviewTextInput(object sender, TextCompositionEventArgs e) {

            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

        }

    }
}
