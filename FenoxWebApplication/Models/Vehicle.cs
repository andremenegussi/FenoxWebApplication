using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FenoxWebApplication.Models
{
    public class Vehicle
    {
        public string PlateNumber { get; set; }
        public string Renavam { get; set; }
        public string ChassisNumber { get; set; }
        public string MotorNumber { get; set; }
        public int YearManufacture { get; set; }
        public bool Status { get; set; }
        public string VehicleBrand { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleColor { get; set; }
        public string VehicleFuelType { get; set; }

    }
}
