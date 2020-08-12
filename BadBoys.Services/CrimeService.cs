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
                                CrimeId = e.CrimeId,
                                CrimeType = e.CrimeType,
                                CrimeDescription = e.CrimeDescription,
                                Penalty = e.Penalty
                            }

                        );
                return query.ToArray();
            }
        }

        public CrimeDetail GetCrimeByCrimeId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Crimes
                        .Single(e => e.CrimeId == id);
                return new CrimeDetail()
                {
                    CrimeId = entity.CrimeId,
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
                        .Single(e => e.CrimeId == model.CrimeId);
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
                        .Single(e => e.CrimeId == id);
                ctx.Crimes.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
