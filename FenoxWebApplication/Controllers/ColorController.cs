using FenoxWebApplication.Models;
using FenoxWebApplication.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FenoxWebApplication.Controllers
{
    public class ColorController : Controller

    {
        private ColorRepository colorDAO = new ColorRepository();

        // Actions para ColorController
        public IActionResult Index()
        {
            List<Color> colors = colorDAO.GetAllColors();
            return View(colors);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            Console.WriteLine("Cheguei aqui");
            Console.WriteLine("Valor de id: " + id);
          
            Color color = colorDAO.getColor(id);

            // Verifica se a cor foi encontrada
            if (color != null)
            {
                // Retorna a cor para a View de edição
                return View(color);
            }
            else
            {
                // Se a cor não foi encontrada, redireciona para a página de erro
                return RedirectToAction("Error");
            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            Color color = colorDAO.getColor(id);
            return View(color);
           
        }

        public IActionResult ConfirmDelete(int id)
        {
            Console.WriteLine("Valor do ID: " + id);
            colorDAO.DeleteColor(id);
        
            return RedirectToAction("Index"); // Redirecionar para a página de listagem após a exclusão
        }

        [HttpPost]
        public IActionResult Add(Color color)
        {
            Console.WriteLine("Cheguei aqui");
            Console.WriteLine("Valor: " + color.Description);
            Console.WriteLine("Valor: " + color.Status);
            colorDAO.AddColor(color);

            return RedirectToAction("Index");
        }

        public IActionResult Update(Color color)
        {
            Console.WriteLine("Cheguei aqui");
            Console.WriteLine("Description: " + color.Description);
            Console.WriteLine("Status: " + color.Status);
            Console.WriteLine("Id: " + color.Id);
            colorDAO.UpdateColor(color);

            return RedirectToAction("Index");
        }

    }
}
