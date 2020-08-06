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
        private readonly Guid _userId;

        public CaseService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCase(CaseCreate model)
        {
            var entity = new Case()
            {
                OwnerId = _userId,
                DateOfIncident = model.DateOfIncident,
                SuspectId = model.SuspectId,
                CrimeId = model.CrimeId,
                BadgeId = model.BadgeId
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
                        .Where(e => e.OwnerId == _userId)
                        .Select(e => new CaseList
                        {
                            CaseKeyId = e.CaseKeyId,
                            DateOfIncident = e.DateOfIncident,
                            Officer = e.Officer,
                            Suspect = e.Suspect,
                            Crime = e.Crime
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
                        .Single(e => e.CaseKeyId == id && e.OwnerId == _userId);

                return new CaseDetail()
                {
                    CaseKeyId = entity.CaseKeyId,
                    DateOfIncident = entity.DateOfIncident,
                    Officer = entity.Officer,
                    Suspect = entity.Suspect,
                    Crime = entity.Crime
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
                        .Single(e => e.CaseKeyId == model.CaseKeyId && e.OwnerId == _userId);
                entity.DateOfIncident = model.DateOfIncident;
                entity.Officer = model.Officer;
                entity.Suspect = model.Suspect;
                entity.Crime = model.Crime;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCase(int caseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                            .Cases
                            .Single(e => e.CaseKeyId == caseId && e.OwnerId == _userId);
                ctx.Cases.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
