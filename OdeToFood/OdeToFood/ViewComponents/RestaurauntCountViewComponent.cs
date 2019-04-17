using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.ViewComponents
{
    public class RestaurauntCountViewComponent : ViewComponent
    {
        private readonly IRestaurauntData restaurauntData;

        public RestaurauntCountViewComponent(IRestaurauntData restaurauntData)
        {
            this.restaurauntData = restaurauntData;
        }

        public IViewComponentResult Invoke()
        {
            var count = restaurauntData.GetCountOfRestauraunts();
            return View(count);
        }
    }
}