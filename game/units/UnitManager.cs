using Godot;
using EvolveMono.Game.Units;
using System.Collections.Generic;

public class UnitManager : Node
{
    private PackedScene UnitScene = ResourceLoader.Load("res://game/units/Unit.tscn") as PackedScene;

    [Signal]
    public delegate void UnitCreated(Unit unit);

    [Signal]
    public delegate void UnitDeleted(Unit unit);

    private List<Unit> _units = new List<Unit>();
    public List<Unit> Units
    {
        get => _units;
    }

    public Unit CreateUnit()
    {
        Unit unit = UnitScene.Instance() as Unit; 
        _units.Add(unit);
        EmitSignal("UnitCreated", unit);
        return unit;
    }

    public void DeleteUnit(Unit unit)
    {
        _units.Remove(unit);
        EmitSignal("UnitDeleted", unit);
        unit.QueueFree();
    }
}