using EvolveMono.Game.Units;
using System.Collections.Generic;

public static class UnitManager
{
    private static List<Unit> _units = new List<Unit>();
    public static List<Unit> Units
    {
        get => _units;
    }

    public static Unit CreateUnit(UnitType unitType)
    {
        Unit newUnit = unitType.packedScene.Instance() as Unit;
        _units.Add(newUnit);
        return newUnit;
    }
}