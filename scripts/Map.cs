using Godot;
using EvolveMono.Scripts.Tiles;
using EvolveMono.Scripts.Hexgrid;

public class Map : Node2D
{

    [Signal]
    public delegate void Select();

    public HexTileMap TileMap;
    public Sprite Hovered;
    public Sprite Selected;

    public override void _Ready()
    {
        TileMap = (HexTileMap) GetNode("HexTileMap");
        Hovered = (Sprite) GetNode("Hovered");
        Selected = (Sprite) GetNode("Selected");
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventMouseMotion eventMouseMotion)
        {
            Hovered.Position = TileMap.MapToWorld(TileMap.WorldToMap(GetGlobalMousePosition()));
        }
        if (@event.IsActionPressed("map_left_click"))
        {
            EmitSignal(nameof(Select));
            Unit unit = Units.UnitT
            Selected.Position = Hovered.Position;
        }
    }

    private Tile GetTile(Vector2 coordinates)
    {
        // Tile tile = new Tile(Terrain.Forest, new Vector2(0, 0));
        return null;
    }
}
