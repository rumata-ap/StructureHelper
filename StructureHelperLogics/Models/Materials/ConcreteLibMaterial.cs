﻿using StructureHelperCommon.Infrastructures.Enums;
using StructureHelperCommon.Infrastructures.Settings;
using StructureHelperCommon.Models.Materials.Libraries;
using LMBuilders = LoaderCalculator.Data.Materials.MaterialBuilders;
using LMLogic = LoaderCalculator.Data.Materials.MaterialBuilders.MaterialLogics;
using LM = LoaderCalculator.Data.Materials;
using LoaderCalculator.Data.Materials;
using StructureHelperCommon.Infrastructures.Exceptions;
using StructureHelperCommon.Models.Materials;

namespace StructureHelperLogics.Models.Materials
{
    public class ConcreteLibMaterial : IConcreteLibMaterial
    {
        const MaterialTypes materialType = MaterialTypes.Concrete;
        private readonly List<IMaterialLogic> materialLogics;
        private LMBuilders.ConcreteOptions lmOptions;
        private IMaterialOptionLogic optionLogic;
        private IFactorLogic factorLogic => new FactorLogic(SafetyFactors);
        private LMLogic.ITrueStrengthLogic strengthLogic;
        /// <inheritdoc/>
        public ILibMaterialEntity MaterialEntity { get; set; }
        /// <inheritdoc/>
        public List<IMaterialSafetyFactor> SafetyFactors { get; }
        /// <inheritdoc/>
        public bool TensionForULS { get ; set; }
        /// <inheritdoc/>
        public bool TensionForSLS { get; set; }
        /// <summary>
        /// Humidity of concrete
        /// </summary>
        public double RelativeHumidity { get; set; }
        /// <inheritdoc/>
        public IMaterialLogic MaterialLogic { get; set; }
        /// <inheritdoc/>
        public List<IMaterialLogic> MaterialLogics => materialLogics;
        public ConcreteLibMaterial()
        {
            materialLogics = ProgramSetting.MaterialLogics.Where(x => x.MaterialType == materialType).ToList();
            MaterialLogic = materialLogics.First();
            SafetyFactors = new List<IMaterialSafetyFactor>();
            lmOptions = new LMBuilders.ConcreteOptions();
            SafetyFactors.AddRange(PartialCoefficientFactory.GetDefaultConcreteSafetyFactors(ProgramSetting.CodeType));
            TensionForULS = false;
            TensionForSLS = true;
            RelativeHumidity = 0.55d;
        }       

        public object Clone()
        {
            var newItem = new ConcreteLibMaterial();
            var updateStrategy = new ConcreteLibUpdateStrategy();
            updateStrategy.Update(newItem, this);
            return newItem;
        }



        public (double Compressive, double Tensile) GetStrength(LimitStates limitState, CalcTerms calcTerm)
        {
            strengthLogic = new LMLogic.TrueStrengthConcreteLogicSP63_2018(MaterialEntity.MainStrength);
            var strength = strengthLogic.GetTrueStrength();
            double compressionFactor = 1d;
            double tensionFactor = 1d;
            if (limitState == LimitStates.ULS)
            {
                compressionFactor /= 1.3d;
                tensionFactor /= 1.5d;
                var factors = factorLogic.GetTotalFactor(limitState, calcTerm);
                compressionFactor *= factors.Compressive;
                tensionFactor *= factors.Tensile;
            }
            return (strength.Compressive * compressionFactor, strength.Tensile * tensionFactor);
        }

        public IMaterial GetCrackedLoaderMaterial(LimitStates limitState, CalcTerms calcTerm)
        {
            ConcreteLogicOptions options = SetOptions(limitState, calcTerm);
            options.WorkInTension = false;
            MaterialLogic.Options = options;
            var material = MaterialLogic.GetLoaderMaterial();
            return material;
        }

        public IMaterial GetLoaderMaterial(LimitStates limitState, CalcTerms calcTerm)
        {
            ConcreteLogicOptions options = SetOptions(limitState, calcTerm);
            MaterialLogic.Options = options;
            var material = MaterialLogic.GetLoaderMaterial();
            return material;
        }

        private ConcreteLogicOptions SetOptions(LimitStates limitState, CalcTerms calcTerm)
        {
            var options = new ConcreteLogicOptions();
            options.SafetyFactors = SafetyFactors;
            options.MaterialEntity = MaterialEntity;
            options.LimitState = limitState;
            options.CalcTerm = calcTerm;
            if (limitState == LimitStates.ULS)
            {
                if (TensionForULS == true)
                {
                    options.WorkInTension = true;
                }
                else
                {
                    options.WorkInTension = false;
                }
            }
            else if (limitState == LimitStates.SLS)
            {
                if (TensionForSLS == true)
                {
                    options.WorkInTension = true;
                }
                else
                {
                    options.WorkInTension = false;
                }
            }
            else
            {
                throw new StructureHelperException(ErrorStrings.ObjectTypeIsUnknownObj(limitState));
            }
            options.RelativeHumidity = RelativeHumidity;
            return options;
        }
    }
}
