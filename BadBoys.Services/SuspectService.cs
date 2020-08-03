using BadBoys.Data;
using BadBoys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadBoys.Services
{
    public class SuspectService
    {
        private readonly Guid _userId;

        public SuspectService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSuspect(SuspectCreate model)
        {
            var entity =
                new Suspect()
                {
                    Name = model.Name,
                    Height = model.Height,
                    Weight = model.Weight,
                    DateBooked = model.DateBooked
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Suspects.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SuspectListItem> GetSuspects()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Suspects.Select
                    (e => new SuspectListItem
                    {
                        SuspectId = e.SuspectId,
                        Name = e.Name,
                        DateBooked = e.DateBooked
                    }
                        );

                return query.ToArray();
            }
        }

        public SuspectDetail GetSuspectById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Suspects.Single
                    (e => e.SuspectId == id);
                return
                    new SuspectDetail
                    {
                        SuspectId = entity.SuspectId,
                        Name = entity.Name,
                        Height = entity.Height,
                        Weight = entity.Weight,
                        PriorConviction = entity.PriorConviction,
                        DateBooked = entity.DateBooked
                    };
            }
        }

        public bool UpdateSuspect(SuspectEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Suspects.Single
                    (e => e.SuspectId == model.SuspectId);

                entity.Name = model.Name;
                entity.Height = model.Height;
                entity.Weight = model.Weight;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSuspect(int suspectId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Suspects.Single
                    (e => e.SuspectId == suspectId);

                ctx.Suspects.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
