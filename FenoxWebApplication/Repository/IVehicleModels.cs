using FenoxWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FenoxWebApplication.Repository
{
    interface IVehicleModels
    {
        public List<VehicleModel> GetAllVehicleModels();

        public void AddVehicleModel(VehicleModel vehicleModel);

        public void UpdateVehicleModel(VehicleModel vehicleModel);

        public void DeleteVehicleModel(int id);
    }
}

