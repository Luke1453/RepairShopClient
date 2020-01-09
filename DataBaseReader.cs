using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace RepairShopClient {
    class DataBaseReader {

        static private string dataSource = Globals.DBsource;
        public SQLiteConnection SQLiteConnection;
        public SQLiteCommand SQLiteCommand;
        public SQLiteDataReader SQLiteDataReader;

        public string CommandText { get; set; }

        public DataBaseReader() {

            SQLiteConnection = new SQLiteConnection(dataSource);
            SQLiteConnection.Open();
        }

        public void execCommand() {

            SQLiteCommand = SQLiteConnection.CreateCommand();
            SQLiteCommand.CommandText = CommandText;
            SQLiteDataReader = SQLiteCommand.ExecuteReader();

        }

        public void closeConnection() {
            this.SQLiteConnection.Close();
        }

    }
}
