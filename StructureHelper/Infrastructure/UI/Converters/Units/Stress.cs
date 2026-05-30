using StructureHelperCommon.Infrastructures.Enums;
using StructureHelperCommon.Services.Units;

namespace StructureHelper.Infrastructure.UI.Converters.Units
{
    /// <summary>
    /// Конвертер единиц напряжения (МПа).
    /// </summary>
    internal class Stress : UnitBase
    {
        public override UnitTypes UnitType { get => UnitTypes.Stress; }
        public override IUnit CurrentUnit { get => CommonOperation.GetUnit(UnitType, "MPa"); }
        public override string UnitName { get => "Stress"; }
    }
}