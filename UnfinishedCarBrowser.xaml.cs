﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for UnfinishedCarBrowser.xaml
    /// </summary>
    public partial class UnfinishedCarBrowser : Page {

        List<CarData> carDatas= new List<CarData>();
       
        public UnfinishedCarBrowser() {

            InitializeComponent();
            
            DataBaseReader DBreader = new DataBaseReader();
            DBreader.CommandText = "SELECT * FROM StartedCarRepairRecords";
            DBreader.execCommand();

            while (DBreader.SQLiteDataReader.Read()) {

                CarData carData = new CarData();

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

                carData.formatData();

                carDatas.Add(carData);

            }

            dataGrid.ItemsSource = carDatas;

        }

    }
}