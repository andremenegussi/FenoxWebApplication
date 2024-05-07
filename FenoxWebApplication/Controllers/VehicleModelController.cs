using FenoxWebApplication.Models;
using FenoxWebApplication.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FenoxWebApplication.Controllers
{
    public class VehicleModelController : Controller
    {
        private VehicleModelRepository vehicleModelDAO = new VehicleModelRepository();

        private VehicleBrandRepository vehicleBrandDAO = new VehicleBrandRepository();

        // Actions para VehicleModelController
        public IActionResult Index()
        {
            List<VehicleModel> vehicleModels = vehicleModelDAO.GetAllVehicleModels();
            return View(vehicleModels);
        }

        public IActionResult Add()
        {
            List<VehicleBrand> vehicleBrands = vehicleBrandDAO.GetAllVehicleBrands();
            VehicleModel vehicleModel = new VehicleModel();
            vehicleModel.VehicleBrands = vehicleBrands;
            Console.WriteLine("Valor de brands: " + vehicleModel.VehicleBrands.Count);
            return View(vehicleBrands);
        }
        
        public IActionResult Edit(int id)
        {
            Console.WriteLine("Cheguei aqui");
            Console.WriteLine("Valor de id: " + id);

            List<VehicleBrand> vehicleBrands = vehicleBrandDAO.GetAllVehicleBrands();
            VehicleModel vehicleModel = vehicleModelDAO.geVehicleModel(id);
            vehicleModel.VehicleBrands = vehicleBrands;

            Console.WriteLine("Valor da lista: " + vehicleModel.VehicleBrands.Count);

            if (vehicleModel != null)
            {
                // Retorna a cor para a View de edição
                return View(vehicleModel);
            }
            else
            {
                // Se a cor não foi encontrada, redireciona para a página de erro 
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            VehicleModel vehicleModel = vehicleModelDAO.geVehicleModel(id);
            return View(vehicleModel);
        }

        public IActionResult ConfirmDelete(int id)
        {
            Console.WriteLine("Valor do ID: " + id);
            vehicleModelDAO.DeleteVehicleModel(id);
       
            return RedirectToAction("Index"); // Redirecionar para a página de listagem após a exclusão
        }

        public IActionResult Update(VehicleModel vehicleModel)
        {
            Console.WriteLine("Cheguei aqui");
            Console.WriteLine("Description: " + vehicleModel.Name);
            Console.WriteLine("Status: " + vehicleModel.Status);
            Console.WriteLine("VehicleBrand.Name: " + vehicleModel.VehicleBrand.Name);
            Console.WriteLine("VehicleBrand.id: " + vehicleModel.VehicleBrand.Id);
            Console.WriteLine("Id: " + vehicleModel.Id);
            vehicleModelDAO.UpdateVehicleModel(vehicleModel);

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Add(VehicleModel vehicleModel)
        {
            Console.WriteLine("Cheguei aqui");
            Console.WriteLine("Valor: " + vehicleModel.Name);
            Console.WriteLine("Valor: " + vehicleModel.Status);
            Console.WriteLine("Valor: " + vehicleModel.VehicleBrand.Id);
            vehicleModelDAO.AddVehicleModel(vehicleModel);

            return RedirectToAction("Index");
        }
    }
}
