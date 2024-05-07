using FenoxWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FenoxWebApplication.Repository
{
    interface IVehicleBrand
    {
        public List<VehicleBrand> GetAllVehicleBrands();

        public void AddVehicleBrand(VehicleBrand vehicleBrand);

        public void UpdateVehicleBrand(VehicleBrand vehicleBrand);

        public void DeleteVehicleBrand(int id);
    }
}
