using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace RepairShopClient {

    class SaveUnfinishedCar : ISaveDB {

        public SQLiteConnection SQLiteConnection;
        public SQLiteCommand SQLiteCommand;

        public void saveToDB(CarData carData) {

            try {
                SQLiteConnection = new SQLiteConnection(Globals.DBsource);
                SQLiteConnection.Open();

                SQLiteCommand = SQLiteConnection.CreateCommand();
                SQLiteCommand.CommandText = "INSERT INTO StartedCarRepairRecords(CustName, CustSurname, CustPhone, AddmitionTime, CarMake, " +
                    "CarModel, CarNR, CarEngineID, EngineVolume, EnginePower, FuelType) " +
                    "VALUES(@name, @surname, @phone, @time, @make, @model, @carNr, @carID, @volume, @power, @fuelType)";

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

                SQLiteCommand.Prepare();
                SQLiteCommand.ExecuteNonQuery();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }

        }
    }
}
