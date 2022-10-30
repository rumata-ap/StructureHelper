﻿using LoaderCalculator;
using LoaderCalculator.Data.Matrix;
using LoaderCalculator.Data.Ndms;
using LoaderCalculator.Data.ResultData;
using LoaderCalculator.Data.SourceData;
using StructureHelper.Services;
using StructureHelper.Services.Primitives;
using StructureHelper.UnitSystem;
using StructureHelper.UnitSystem.Systems;
using StructureHelperLogics.Infrastructures.CommonEnums;
using StructureHelperLogics.Models.Calculations.CalculationProperties;
using StructureHelperLogics.NdmCalculations.Triangulations;
using StructureHelperLogics.Services;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace StructureHelper.Windows.MainWindow
{
    public class MainModel
    {
        private IPrimitiveRepository primitiveRepository;
        private CalculationService calculationService;
        private UnitSystemService unitSystemService;

        public ICalculationProperty CalculationProperty { get; private set; }
        
        public MainModel(IPrimitiveRepository primitiveRepository, CalculationService calculationService, UnitSystemService unitSystemService)
        {
            this.primitiveRepository = primitiveRepository;
            this.calculationService = calculationService;
            this.unitSystemService = unitSystemService;

            CalculationProperty = new CalculationProperty();
        }
        
        public IStrainMatrix Calculate(double mx, double my, double nz)
        {
            var unitSystem = unitSystemService.GetCurrentSystem();
            return calculationService.GetPrimitiveStrainMatrix(primitiveRepository.Primitives.Select(x => x.GetNdmPrimitive(unitSystem)).ToArray(), mx, my, nz);
        }

        public IEnumerable<INdm> GetNdms()
        {
            var unitSystem = unitSystemService.GetCurrentSystem();
            var ndmPrimitives = primitiveRepository.Primitives.Select(x => x.GetNdmPrimitive(unitSystem)).ToArray();

            //Настройки триангуляции, пока опции могут быть только такие
            ITriangulationOptions options = new TriangulationOptions { LimiteState = LimitStates.Collapse, CalcTerm = CalcTerms.ShortTerm };

            //Формируем коллекцию элементарных участков для расчета в библитеке (т.е. выполняем триангуляцию)
            List<INdm> ndmCollection = new List<INdm>();
            ndmCollection.AddRange(Triangulation.GetNdms(ndmPrimitives, options));

            return ndmCollection;
        }

        public ILoaderResults CalculateResult(IEnumerable<INdm> ndmCollection, IForceMatrix forceMatrix)
        {
            var loaderData = new LoaderOptions
            {
                Preconditions = new Preconditions
                {
                    ConditionRate = 0.01,
                    MaxIterationCount = 100,
                    StartForceMatrix = forceMatrix
                },
                NdmCollection = ndmCollection
            };
            var calculator = new Calculator();
            calculator.Run(loaderData, new CancellationToken());
            return calculator.Result;
        }
    }
}
