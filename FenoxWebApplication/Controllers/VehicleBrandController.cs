using FenoxWebApplication.Models;
using FenoxWebApplication.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FenoxWebApplication.Controllers
{
    public class VehicleBrandController : Controller
    {
        private VehicleBrandRepository vehicleBrandDAO = new VehicleBrandRepository();
        // Actions para VehicleBrandController
        public IActionResult Index()
        {
            List<VehicleBrand> vehicleBrands = vehicleBrandDAO.GetAllVehicleBrands();
            return View(vehicleBrands);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            Console.WriteLine("Cheguei aqui");
            Console.WriteLine("Valor de id: " + id);

            VehicleBrand vehicleBrand = vehicleBrandDAO.getVehicleBrand(id);

            Console.WriteLine("Retorno: " + vehicleBrand.Name);

            if (vehicleBrand != null)
            {
                // Retorna a cor para a View de edição
                return View(vehicleBrand);
            }
            else
            {
                // Se a cor não foi encontrada, redireciona para a página de erro 
                return View();
            }

        }

        public IActionResult Delete(int id)
        {
            VehicleBrand vehicleBrand = vehicleBrandDAO.getVehicleBrand(id);
            return View(vehicleBrand);

        }

        public IActionResult ConfirmDelete(int id)
        {
            Console.WriteLine("Valor do ID: " + id);
            vehicleBrandDAO.DeleteVehicleBrand(id);

            return RedirectToAction("Index"); // Redirecionar para a página de listagem após a exclusão
        }


        [HttpPost]
        public IActionResult Add(VehicleBrand vehicleBrand)
        {
            Console.WriteLine("Cheguei aqui");
            Console.WriteLine("Valor: " + vehicleBrand.Name);
            Console.WriteLine("Valor: " + vehicleBrand.Status);
            vehicleBrandDAO.AddVehicleBrand(vehicleBrand);

            return RedirectToAction("Index");
        }

        public IActionResult Update(VehicleBrand vehicleBrand)
        {
            Console.WriteLine("Cheguei aqui");
            Console.WriteLine("Description: " + vehicleBrand.Name);
            Console.WriteLine("Status: " + vehicleBrand.Status);
            Console.WriteLine("Id: " + vehicleBrand.Id);
            vehicleBrandDAO.UpdateVehicleBrand(vehicleBrand);

            return RedirectToAction("Index");
        }


    }
}
