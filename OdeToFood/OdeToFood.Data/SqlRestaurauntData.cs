using System.Collections.Generic;
using OdeToFood.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Data
{
    public class SqlRestaurauntData : IRestaurauntData
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurauntData(OdeToFoodDbContext db)
        {
            this.db = db;
        }

        public Restauraunt Add(Restauraunt newRestauraunt)
        {
            db.Add(newRestauraunt);
            return newRestauraunt;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restauraunt Delete(int id)
        {
            var restauraunt = GetById(id);

            if (restauraunt != null)
            {
                db.Restauraunts.Remove(restauraunt);
            }
            return restauraunt;
        }

        public Restauraunt GetById(int id)
        {
            return db.Restauraunts.Find(id);
        }

        public int GetCountOfRestauraunts()
        {
            return db.Restauraunts.Count();
        }

        public IEnumerable<Restauraunt> GetRestaurauntsByName(string name)
        {
            var query = from r in db.Restauraunts
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Restauraunt Update(Restauraunt updatedRestauraunt)
        {
            var entity = db.Restauraunts.Attach(updatedRestauraunt);

            entity.State = EntityState.Modified;
            return updatedRestauraunt;
        }
    }
}