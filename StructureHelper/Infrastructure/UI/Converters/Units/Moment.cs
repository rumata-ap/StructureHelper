using StructureHelperCommon.Infrastructures.Enums;
using StructureHelperCommon.Services.Units;

namespace StructureHelper.Infrastructure.UI.Converters.Units
{
    /// <summary>
    /// Конвертер единиц изгибающего момента (кН·м).
    /// </summary>
    internal class Moment : UnitBase
    {
        public override UnitTypes UnitType { get => UnitTypes.Moment; }
        public override IUnit CurrentUnit { get => CommonOperation.GetUnit(UnitType, "kNm"); }
        public override string UnitName { get => "Moment"; }
    }
}