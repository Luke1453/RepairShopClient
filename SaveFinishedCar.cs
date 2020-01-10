using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace RepairShopClient {

    class SaveFinishedCar : ISaveDB {

        public SQLiteConnection SQLiteConnection;
        public SQLiteCommand SQLiteCommand;

        public void saveToDB(CarData carData) {

            try {
                SQLiteConnection = new SQLiteConnection(Globals.DBsource);
                SQLiteConnection.Open();

                SQLiteCommand = SQLiteConnection.CreateCommand();
                SQLiteCommand.CommandText = "INSERT INTO FinishedCarRepairRecords(CustName, CustSurname, CustPhone, AddmitionTime, CarMake, " +
                    "CarModel, CarNR, CarEngineID, EngineVolume, EnginePower, FuelType, WorkDescription, WorkPrice) " +
                    "VALUES(@name, @surname, @phone, @time, @make, @model, @carNr, @carID, @volume, @power, @fuelType, @workDescription, @workPrice)";

                SQLiteCommand.Parameters.AddWithValue("@name", carData.ClientName);
                SQLiteCommand.Parameters.AddWithValue("@surname", carData.ClientSurname);
                SQLiteCommand.Parameters.AddWithValue("@phone", carData.ClientPhone);
                SQLiteCommand.Parameters.AddWithValue("@time", carData.TimeAdded);
                SQLiteCommand.Parameters.AddWithValue("@make", carData.CarMake);
                SQLiteCommand.Parameters.AddWithValue("@model", carData.CarModel);
                SQLiteCommand.Parameters.AddWithValue("@carNr", carData.CarNR);
                SQLiteCommand.Parameters.AddWithValue("@carID", carData.CarID);
                SQLiteCommand.Parameters.AddWithValue("@volume", carData.EngineVol);
                SQLiteCommand.Parameters.AddWithValue("@power", carData.EnginePower);
                SQLiteCommand.Parameters.AddWithValue("@fuelType", carData.FuelType);
                SQLiteCommand.Parameters.AddWithValue("@workDescription", carData.WorkDescription);
                SQLiteCommand.Parameters.AddWithValue("@workPrice", carData.WorkPrice);


                SQLiteCommand.Prepare();
                SQLiteCommand.ExecuteNonQuery();
                SQLiteConnection.Close();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }

        }
    }
}
