using FenoxWebApplication.Models;
using FenoxWebApplication.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FenoxWebApplication.Controllers
{
    public class FuelController : Controller
    {
        private FuelRepository fuelDAO = new FuelRepository();

        // Actions para FuelController
        public IActionResult Index()
        {
            List<Models.Fuel> fuels = fuelDAO.GetAllFuels();
            return View(fuels);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {

            Console.WriteLine("Cheguei aqui");
            Console.WriteLine("Valor de id: " + id);

            Fuel fuel = fuelDAO.getFuel(id);

            if (fuel != null)
            {
                // Retorna a cor para a View de edição
                return View(fuel);
            }
            else
            {
                // Se a cor não foi encontrada, redireciona para a página de erro 
                return View();
            }
          
        }

        public IActionResult Delete(int id)
        {
            Fuel fuel = fuelDAO.getFuel(id);
            return View(fuel);

        }

        public IActionResult ConfirmDelete(int id)
        {
            Console.WriteLine("Valor do ID: " + id);
            fuelDAO.DeleteFuel(id);

            return RedirectToAction("Index"); // Redirecionar para a página de listagem após a exclusão
        }

        [HttpPost]
        public IActionResult Add(Fuel fuel)
        {
            Console.WriteLine("Cheguei aqui");
            Console.WriteLine("Valor: " + fuel.Description);
            Console.WriteLine("Valor: " + fuel.Status);
            fuelDAO.AddFuel(fuel);

            return RedirectToAction("Index");
        }

        public IActionResult Update(Fuel fuel)
        {
            Console.WriteLine("Cheguei aqui");
            Console.WriteLine("Description: " + fuel.Description);
            Console.WriteLine("Status: " + fuel.Status);
            Console.WriteLine("Id: " + fuel.Id);
            fuelDAO.UpdateFuel(fuel);

            return RedirectToAction("Index");
        }

    }
}
