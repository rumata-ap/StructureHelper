using StructureHelperCommon.Infrastructures.Enums;
using StructureHelperCommon.Services.Units;

namespace StructureHelper.Infrastructure.UI.Converters.Units
{
    /// <summary>
    /// Конвертер единиц кривизны (1/мм).
    /// </summary>
    internal class Curvature : UnitBase
    {
        public override UnitTypes UnitType { get => UnitTypes.Curvature; }
        public override IUnit CurrentUnit { get => CommonOperation.GetUnit(UnitType, "1/mm"); }
        public override string UnitName { get => "Curvature"; }
    }
}