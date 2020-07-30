using BadBoys.Data;
using BadBoys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadBoys.Services
{
    public class CrimeService
    {
        private readonly Guid _userid;

        public CrimeService(Guid userId)
        {
            _userid = userId;
        }

        public bool CreateCrime(CrimeCreate model)
        {
            var entity =
                new Crime()
                {
                    id = model.id,
                    CrimeDescription = model.CrimeDescription,
                    CrimeType = model.CrimeType,
                    Penalty = model.Penalty
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Crimes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<Crime> GetCrimes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Crimes
                        .Select(e =>
                            new CrimeList()
                            {
                                CrimeDescription = e.CrimeDescription,
                                CrimeType = e.CrimeType,
                                id = e.id,
                                Penalty = e.Penalty
                            }

                        );
                return query.ToArray();
            }
        }

        public CrimeDetail GetCrimeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Crimes
                        .Single(e => e.id == id);
                return new CrimeDetail()
                {
                    id = entity.id,
                    CrimeDescription = entity.CrimeDescription,
                    CrimeType = entity.CrimeType,
                    Penalty = entity.Penalty
                };
                        
            }
        }
        public bool EditCrime(CrimeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Crimes
                        .Single(e => e.id == model.id);
                entity.CrimeDescription = model.CrimeDescription;
                entity.CrimeType = model.CrimeType;
                entity.Penalty = model.Penalty;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCrime(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Crimes
                        .Single(e => e.id == id);
                ctx.Crimes.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
