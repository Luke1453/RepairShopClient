using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShopClient {
    public interface ISaveDB {

        void saveToDB(CarData carData);
    }
}
