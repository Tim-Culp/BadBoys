﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadBoys.Models.OfficerCaseModels
{
    public class OfficerCaseCreate
    {
        public int CaseId { get; set; }
        public Guid OfficerId { get; set; }
    }
}
