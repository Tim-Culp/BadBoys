using BadBoys.Data;
using BadBoys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadBoys.Services
{
    public class CaseService
    {
        private readonly Guid _officerId;

        public CaseService(Guid officerId)
        {
            _officerId = officerId;
        }

        public bool CreateCase(CaseCreate model)
        {
            var entity = new Case()
            {
                OfficerId = _officerId,
                DateOfIncident = model.DateOfIncident,
                Suspect = model.Suspect,
                Crime = model.Crime,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cases.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CaseList> GetCases()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Cases
                        .Where(e => e.OfficerId == _officerId)
                        .Select(e => new CaseList
                        {
                            OfficerId = _officerId,
                            DateOfIncident = e.DateOfIncident,
                            Suspect = e.Suspect,
                            Crime = e.Crime,
                        });
                return query.ToArray();
            }
        }
        public CaseDetail GetCaseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cases
                        .Single(e => e.OfficerId == _officerId);

                return new CaseDetail()
                {
                    OfficerId = _officerId,
                    DateOfIncident = entity.DateOfIncident,
                    Suspect = entity.Suspect,
                    Crime = entity.Crime,
                };
            }
        }
        public bool UpdateCase(CaseEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cases
                        .Single(e => e.OfficerId == model.OfficerId);
                entity.DateOfIncident = model.DateOfIncident;
                entity.Suspect = model.Suspect;
                entity.Crime = model.Crime;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCase(int CaseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                            .Cases
                            .Single(e => e.Id == CaseId && e.OfficerId == _officerId);
                ctx.Cases.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
