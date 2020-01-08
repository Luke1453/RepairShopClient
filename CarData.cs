using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShopClient {
    public class CarData {

        //raw data for database
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string ClientPhone { get; set; }
        public long TimeAdded { get; set; }
        public int CarMake { get; set; }
        public string CarModel { get; set; }
        public string CarNR { get; set; }
        public string CarID { get; set; }
        public int EngineVol { get; set; }
        public int EnginePower { get; set; }
        public int FuelType { get; set; }

        //data for showing
        public string CarMakeString { get; set; }
        public string FuelTypeString { get; set; }
        //public DateTime TimeAddedFrormatted { get; set; }

        //TODO: finish vars to make universal

        public void formatData() {

            //carmakestring
            try {
                DataBaseReader DBreader = new DataBaseReader();
                DBreader.SQLiteCommand = DBreader.SQLiteConnection.CreateCommand();
                DBreader.SQLiteCommand.CommandText = "SELECT Brand from CarBrands WHERE ID=@id";
                DBreader.SQLiteCommand.Parameters.AddWithValue("@id", this.CarMake);
                DBreader.SQLiteCommand.Prepare();
                DBreader.SQLiteDataReader = DBreader.SQLiteCommand.ExecuteReader();

                DBreader.SQLiteDataReader.Read();
                this.CarMakeString = DBreader.SQLiteDataReader.GetString(0);


            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
    }
}
