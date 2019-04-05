using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OdeToFood.Core
{
    public class Restauraunt
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}