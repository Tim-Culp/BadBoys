using BadBoys.Data;
using BadBoys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadBoys.Services
{
    public class OfficerService
    {
        private readonly Guid _userId;

        public OfficerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateOfficer(OfficerCreate model)
        {
            var entity = new Officer()
            {
                OfficerId = _userId, 
                FullName = model.FullName,
                RankOfOfficer = model.RankOfOfficer,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Officers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<OfficerList> ReadOfficers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Officers.Select(e => new OfficerList { FullName = e.FullName, BadgeId = e.BadgeId, RankOfOfficer = e.RankOfOfficer, });
                return query.OrderBy(s => s.FullName).ToArray();
            }
        }

        public OfficerDetail ReadOfficerById(int badgeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Officers.Single(e => e.BadgeId == badgeId);
                return new OfficerDetail
                {
                    BadgeId = entity.BadgeId,
                    FullName = entity.FullName,
                    RankOfOfficer = entity.RankOfOfficer,
                };
            }
        }
        public bool EditOfficer(OfficerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                            ctx
                           .Officers
                           .Single(e => e.BadgeId == model.BadgeId);
                entity.FullName = model.FullName;
                entity.RankOfOfficer = model.RankOfOfficer;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteOfficer(int badgeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Officers
                        .Single(e => e.BadgeId == badgeId);
                ctx.Officers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<OfficerList> ConvertOfficersToListItems(ICollection<Officer> officers)
        {
            var query = officers.Select(
                        e =>
                            new OfficerList
                            { FullName = e.FullName }
                    );
            return query.ToArray();
        }
    }
}
