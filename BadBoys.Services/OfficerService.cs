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

        public OfficerDetail ReadOfficerById(int BadgeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                /*var officerCaseService = new CaseService(OfficerKeyId);
                if (ctx.Officers.Count() < 1)
                {
                    return new OfficerDetail()
                    {
                        OfficerId = new Guid(),
                        RankOfOfficer = OfficerRank.Lieutenant,
                        FullName = ""
                    };
                }*/
                var entity = ctx.Officers.Single(e => e.BadgeId == BadgeId);
                return new OfficerDetail
                {
                    BadgeId = entity.BadgeId,
                    FullName = entity.FullName,
                    RankOfOfficer = entity.RankOfOfficer,
                   // CurrentCase = entity.CurrentCase
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
               // entity.CurrentCase = model.CurrentCase;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteOfficer(int BadgeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Officers
                        .Single(e => e.BadgeId == BadgeId);
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
