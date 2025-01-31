﻿using StructureHelper.Infrastructure;
using StructureHelper.Infrastructure.Enums;
using StructureHelper.Windows.CalculationWindows.CalculatorsViews.ForceCalculatorViews;
using StructureHelper.Windows.CalculationWindows.CalculatorsViews.ForceCalculatorViews.ForceResultLogic;
using StructureHelper.Windows.CalculationWindows.ProgressViews;
using StructureHelper.Windows.ViewModels.Calculations.Calculators;
using StructureHelper.Windows.ViewModels.Errors;
using StructureHelperCommon.Infrastructures.Exceptions;
using StructureHelperCommon.Models.Calculators;
using StructureHelperCommon.Models.Loggers;
using StructureHelperLogics.Models.CrossSections;
using StructureHelperLogics.NdmCalculations.Analyses.ByForces;
using StructureHelperLogics.NdmCalculations.Analyses.ByForces.LimitCurve;
using StructureHelperLogics.NdmCalculations.Analyses.Logics;
using StructureHelperLogics.NdmCalculations.Primitives;
using System;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace StructureHelper.Windows.ViewModels.NdmCrossSections
{
    public class AnalysisVewModelLogic : SelectItemVM<ICalculator>
    {
        private ICrossSectionRepository repository;
        private RelayCommand runCommand;
        static readonly CalculatorUpdateStrategy calculatorUpdateStrategy = new();
        private ShowProgressLogic showProgressLogic;
        private InteractionDiagramLogic interactionDiagramLogic;

        public override void AddMethod(object parameter)
        {
            var parameterType = (CalculatorTypes)parameter;
            if (parameterType == CalculatorTypes.ForceCalculator)
            {
                NewItem = new ForceCalculator()
                {
                    Name = "New force calculator",
                    TraceLogger = new ShiftTraceLogger(),
                };
            }
            else if (parameterType == CalculatorTypes.LimitCurveCalculator)
            {
                var inputData = new LimitCurveInputData(repository.Primitives);
                NewItem = new LimitCurvesCalculator()
                {
                    Name = "New interaction diagram calculator",
                    InputData = inputData,
                    TraceLogger = new ShiftTraceLogger(),
                };
            }
            else
            {
                throw new StructureHelperException(ErrorStrings.ObjectTypeIsUnknownObj(parameterType));
            }
            base.AddMethod(parameter);
        }
        public override void EditMethod(object parameter)
        {
            SafetyProcessor.RunSafeProcess(EditCalculator, $"Error of editing: {SelectedItem.Name}");
            base.EditMethod(parameter);
        }

        private void EditCalculator()
        {
            if (SelectedItem is ForceCalculator)
            {
                var calculator = SelectedItem as ForceCalculator;
                EditForceCalculator(calculator);
            }
            else if (SelectedItem is LimitCurvesCalculator)
            {
                var calculator = SelectedItem as LimitCurvesCalculator;
                EditLimitCurveCalculator(calculator);
            }
            else
            {
                throw new StructureHelperException(ErrorStrings.ObjectTypeIsUnknownObj(SelectedItem));
            }
        }

        private void EditLimitCurveCalculator(LimitCurvesCalculator calculator)
        {
            var calculatorCopy = calculator.Clone() as LimitCurvesCalculator;
            var vm = new LimitCurveCalculatorViewModel(calculator, repository.Primitives);
            var wnd = new LimitCurveCalculatorView(vm);
            ShowWindow(calculator, calculatorCopy, wnd);
        }

        private void EditForceCalculator(ForceCalculator calculator)
        {

            var calculatorCopy = (ICalculator)calculator.Clone();
            var vm = new ForceCalculatorViewModel(repository.Primitives, repository.ForceActions, calculator);

            var wnd = new ForceCalculatorView(vm);
            ShowWindow(calculator, calculatorCopy, wnd);
        }

        private static void ShowWindow(ICalculator calculator, ICalculator calculatorCopy, Window wnd)
        {
            wnd.ShowDialog();
            if (wnd.DialogResult == true)
            {
                // to do: update in repository
            }
            else
            {
                calculatorUpdateStrategy.Update(calculator, calculatorCopy);
            }
        }

        public override void DeleteMethod(object parameter)
        {
            var dialogResult = MessageBox.Show("Delete calculator?", "Please, confirm deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                base.DeleteMethod(parameter);
            }      
        }
        public RelayCommand Run
        {
            get
            {
                return runCommand ??
                (
                runCommand = new RelayCommand(o =>
                {
                    SafetyProcessor.RunSafeProcess(RunCalculator, ErrorStrings.ErrorOfExuting + $": {SelectedItem.Name}");
                }, o => SelectedItem != null));
            }
        }

        private void RunCalculator()
        {
            if (SelectedItem is LimitCurvesCalculator calculator)
            {
                if (calculator.TraceLogger is not null) { calculator.TraceLogger.TraceLoggerEntries.Clear(); }
                var inputData = calculator.InputData;
                ShowInteractionDiagramByInputData(calculator);
                if (calculator.TraceLogger is not null)
                {
                    var wnd = new TraceDocumentView(calculator.TraceLogger.TraceLoggerEntries);
                    wnd.ShowDialog();
                }
            }
            else
            {
                SelectedItem.Run();
                var result = SelectedItem.Result;
                if (result.IsValid == false)
                {
                    MessageBox.Show(result.Description, "Check data for analisys", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    ProcessResult();
                }
            }
        }

        private void ShowInteractionDiagramByInputData(LimitCurvesCalculator calculator)
        {
            interactionDiagramLogic = new(calculator.InputData);
            interactionDiagramLogic.TraceLogger = calculator.TraceLogger;
            showProgressLogic = new(interactionDiagramLogic)
            {
                WindowTitle = "Diagram creating...",
                ShowResult = interactionDiagramLogic.ShowWindow
            };
            showProgressLogic.Show();
        }

        private void ProcessResult()
        {
            if (SelectedItem is IForceCalculator)
            {
                var calculator = SelectedItem as ForceCalculator;
                var vm = new ForcesResultsViewModel(calculator);
                var wnd = new ForceResultsView(vm);
                wnd.ShowDialog();
            }
            else
            {
                throw new StructureHelperException(ErrorStrings.ObjectTypeIsUnknownObj(SelectedItem));
            }
        }

        public AnalysisVewModelLogic(ICrossSectionRepository sectionRepository) : base(sectionRepository.CalculatorsList)
        {
            repository = sectionRepository;
        }
    }
}
