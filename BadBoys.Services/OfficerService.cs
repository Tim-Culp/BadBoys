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
        private readonly Guid _officerId;

        public OfficerService(Guid officerId)
        {
            _officerId = officerId;
        }

        public bool CreateOfficer(OfficerCreate model)
        {
            var entity = new Officer()
            {
                FullName = model.FullName,
                RankOfOfficer = model.RankOfOfficer,
                OfficerId = _officerId
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
                var query = ctx.Officers.Select(e => new OfficerList { FullName = e.FullName, OfficerId = e.OfficerId });
                return query.OrderBy(s => s.FullName).ToArray();
            }
        }

        public OfficerDetail ReadOfficerById(Guid OfficerId)
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
                var entity = ctx.Officers.Single(e => e.OfficerId == OfficerId);
                return new OfficerDetail
                {
                    OfficerKeyId = entity.OfficerKeyId,
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
                           .Single(e => e.OfficerId == model.OfficerId);
                entity.FullName = model.FullName;
                entity.RankOfOfficer = model.RankOfOfficer;
               // entity.CurrentCase = model.CurrentCase;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteOfficer(Guid OfficerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Officers
                        .Single(e => e.OfficerId == _officerId);
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
