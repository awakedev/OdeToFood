using OdeToFood.Core;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurauntData
    {
        IEnumerable<Restauraunt> GetRestaurauntsByName(string name);

        Restauraunt GetById(int id);

        Restauraunt Update(Restauraunt updatedRestauraunt);

        Restauraunt Add(Restauraunt newRestauraunt);

        Restauraunt Delete(int id);

        int GetCountOfRestauraunts();

        int Commit();
    }
}