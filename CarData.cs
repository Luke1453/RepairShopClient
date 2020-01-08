using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShopClient {
    public class CarData {

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

        //TODO: finish vars to make universal
    }
}
