using StructureHelperCommon.Infrastructures.Enums;
using StructureHelperCommon.Services.Units;

namespace StructureHelper.Infrastructure.UI.Converters.Units
{
    /// <summary>
    /// Конвертер единиц силы (кН).
    /// </summary>
    internal class Force : UnitBase
    {
        public override UnitTypes UnitType { get => UnitTypes.Force; }
        public override IUnit CurrentUnit { get => CommonOperation.GetUnit(UnitType, "kN"); }
        public override string UnitName { get => "Force"; }
    }
}