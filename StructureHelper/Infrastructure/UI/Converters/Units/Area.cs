using StructureHelperCommon.Infrastructures.Enums;
using StructureHelperCommon.Services.Units;

namespace StructureHelper.Infrastructure.UI.Converters.Units
{
    /// <summary>
    /// Конвертер единиц площади (мм²).
    /// </summary>
    internal class Area : UnitBase
    {
        public override UnitTypes UnitType { get => UnitTypes.Area; }
        public override IUnit CurrentUnit { get => CommonOperation.GetUnit(UnitType, "mm2"); }
        public override string UnitName { get => "Area"; }
    }
}