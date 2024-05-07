using System;
using FenoxWebApplication.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FenoxWebApplication.Repository
{
    interface IFuel
    {
        public List<Fuel> GetAllFuels();

        public void AddFuel(Fuel fuel);

        public void UpdateFuel(Fuel fuel);

        public void DeleteFuel(int id);
    }
  
}

