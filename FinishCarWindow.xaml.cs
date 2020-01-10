using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for FinishCarWindow.xaml
    /// </summary>
    public partial class FinishCarWindow : Window {

        CarData localCarData;
        public bool RecordSaved { get; set; }

        public FinishCarWindow(CarData carData) {

            InitializeComponent();

            localCarData = carData;

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


            nameTB.Text = localCarData.ClientName;
            surnameTB.Text = localCarData.ClientSurname;
            phoneTB.Text = localCarData.ClientPhone;
            modelTB.Text = localCarData.CarModel;
            carNRTB.Text = localCarData.CarNR;
            carIDTB.Text = localCarData.CarID;
            enginePowerTB.Text = localCarData.EnginePower.ToString(); //fix this not showing properly
            makeCB.SelectedIndex = localCarData.CarMake - 1;
            fuelTypeCB.SelectedIndex = localCarData.FuelType - 1;
            enginePowerTB.Text = localCarData.EnginePower.ToString();
            engineVolumeCB.Text = localCarData.EngineVol.ToString();


            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            acceptanceDateCB.SelectedDate = dtDateTime.AddSeconds(localCarData.TimeAdded).ToLocalTime();

        }

        private void save_Click(object sender, RoutedEventArgs e) {

            ////TODO: save button cant be clicked if form isnt filled

            localCarData.ClientName = nameTB.Text;
            localCarData.ClientSurname = surnameTB.Text;
            localCarData.ClientPhone = phoneTB.Text;
            localCarData.CarModel = modelTB.Text;
            localCarData.CarNR = carNRTB.Text;
            localCarData.CarID = carIDTB.Text;
            localCarData.EnginePower = Int32.Parse(enginePowerTB.Text);

            localCarData.CarMake = makeCB.SelectedIndex + 1;
            localCarData.FuelType = fuelTypeCB.SelectedIndex + 1;

            ////converting date to unix time stap + seconds
            //long unixTime = ((DateTimeOffset)acceptanceDateCB.SelectedDate).ToUnixTimeSeconds();
            //TimeSpan t = (DateTime.Now - DateTime.Today);
            //unixTime += (long)t.TotalSeconds;
            ////Console.WriteLine(unixTime);
            //localCarData.TimeAdded = unixTime;

            //dealing with volume
            localCarData.EngineVol = Int32.Parse(engineVolumeCB.Text);

            localCarData.WorkDescription = workDescriptionTB.Text;
            localCarData.WorkPrice = float.Parse(workPriceTB.Text, CultureInfo.InvariantCulture.NumberFormat);

            //sending to database
            SaveFinishedCar saveFinishedCar = new SaveFinishedCar();
            Saving(saveFinishedCar, localCarData);

            RecordSaved = true;
            this.Close();

        }

        public void Saving(ISaveDB saver, CarData carData) {

            saver.saveToDB(carData);
        }

        private void cancel_Click(object sender, RoutedEventArgs e) {

            RecordSaved = false;
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

        private void WorkPriceTB_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            Regex regex = new Regex("[^0-9 .]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
