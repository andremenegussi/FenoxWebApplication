using FenoxWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FenoxWebApplication.Repository
{
    interface IColor
    {
        public List<Color> GetAllColors();

        public Color getColor(int id);

        public void AddColor(Color color);

        public void UpdateColor(Color color);

        public void DeleteColor();
    }
}
