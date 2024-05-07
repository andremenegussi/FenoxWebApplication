using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FenoxWebApplication.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public VehicleBrand VehicleBrand { get; set; }
        public List<VehicleBrand> VehicleBrands { get; set; }

        public VehicleModel()
        {
            VehicleBrands = new List<VehicleBrand>();
        }
    }
}
