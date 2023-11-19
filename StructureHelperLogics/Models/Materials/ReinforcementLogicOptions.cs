﻿using StructureHelperCommon.Infrastructures.Enums;
using StructureHelperCommon.Models.Materials.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructureHelperLogics.Models.Materials
{
    internal class ReinforcementLogicOptions : IMaterialLogicOptions
    {
        public List<IMaterialSafetyFactor> SafetyFactors { get; set; }
        public ILibMaterialEntity MaterialEntity { get; set; }
        public LimitStates LimitState { get; set; }
        public CalcTerms CalcTerm { get; set; }
        public bool WorkInCompression { get; set; }
        public bool WorkInTension { get; set; }
    }
}
