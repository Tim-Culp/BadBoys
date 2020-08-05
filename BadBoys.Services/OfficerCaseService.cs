﻿using BadBoys.Data;
using BadBoys.Models;
using BadBoys.Models.OfficerCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadBoys.Services
{
    public class OfficerCaseService
    {
        private readonly Guid _officerId;
        public OfficerCaseService() { }
        public OfficerCaseService(Guid officerId)
        {
            _officerId = officerId;
        }

        public bool CreateOfficerCase(OfficerCaseCreate model)
        {
            var entity =
                new OfficerCase()
                {
                    OfficerId = model.OfficerId,
                    CaseId = model.CaseId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.OfficerCases.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<string> ConvertOfficerCasesToCases(ICollection<OfficerCase> officerCases)
        {
            var query = officerCases.Select(
                        e =>
                            new CaseList
                            {
                                DateOfIncident = e.Case.DateOfIncident,
                                Suspect = e.Case.Suspect,
                                Crime = e.Case.Crime
                            }
                    );
            query.ToArray();
            List<string> caseStrings = new List<string>();

            foreach (CaseList caseList in query)
            {
                caseStrings.Add($"{caseList.DateOfIncident}, (Suspects: {caseList.Suspect}, Crime: {caseList.Crime})");
            }
            return caseStrings;

        }
    }
}
